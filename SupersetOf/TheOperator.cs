using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SupersetOf
{
	class TheOperator
	{
		public static List<Difference> Operate(string supersetDir, string subsetDir, CancellationToken ct)
		{
			// TODO could make the API so that the UI thread can query the status and differences while the operation is still underway.
			var differences = new List<Difference>();
			var Operator = new TheOperator();
			Operator.CompareRecursively(supersetDir, subsetDir, differences, ct);
			return differences;
		}

		private void CompareRecursively(string supersetDir, string subsetDir, List<Difference> differences, CancellationToken ct)
		{
			if (!Directory.Exists(supersetDir))
			{
				differences.Add(new Difference(subsetDir, DifferenceType.MissingInSuperset));
			}

			try
			{
				var files = Directory.GetFiles(subsetDir);
				foreach (var file in files.Select(x => Path.GetFileName(x)))
				{
					ct.ThrowIfCancellationRequested();

					var supersetFile = Path.Combine(supersetDir, file);
					var subsetFile = Path.Combine(subsetDir, file);
					this.CompareFiles(supersetFile, subsetFile, differences);
				}

				var subDirectories = Directory.GetDirectories(subsetDir);
				foreach (var subDir in subDirectories.Select(x => Path.GetFileName(x)))
				{
					ct.ThrowIfCancellationRequested();

					var supsersetSubDir = Path.Combine(supersetDir, subDir);
					var subsetSubDir = Path.Combine(subsetDir, subDir);
					this.CompareRecursively(supsersetSubDir, subsetSubDir, differences, ct);
				}
			}
			catch
			{
				differences.Add(new Difference(subsetDir, DifferenceType.Exception));
			}
		}

		private void CompareFiles(string supersetFile, string subsetFile, List<Difference> differences)
		{
			if (!File.Exists(supersetFile))
			{
				differences.Add(new Difference(subsetFile, DifferenceType.MissingInSuperset));
				return;
			}

			try
			{
				if (!this.FilesAreEqual(new FileInfo(supersetFile), new FileInfo(subsetFile)))
				{
					differences.Add(new Difference(subsetFile, DifferenceType.ContentDifferent));
				}
			}
			catch
			{
				differences.Add(new Difference(subsetFile, DifferenceType.Exception));
			}
		}

		// For actual file comparison
		const int BYTES_PER_CHUNK = 4096 * 1024;
		private readonly byte[] CompareBuffer1 = new byte[BYTES_PER_CHUNK];
		private readonly byte[] CompareBuffer2 = new byte[BYTES_PER_CHUNK];

		private bool FilesAreEqual(FileInfo first, FileInfo second)
		{
			if (first.Length != second.Length) return false;

			int iterations = (int)Math.Ceiling((double)first.Length / BYTES_PER_CHUNK);

			using (FileStream fs1 = first.OpenRead())
			using (FileStream fs2 = second.OpenRead())
			{
				for (int i = 0; i < iterations; i++)
				{
					var t1 = fs1.ReadAsync(this.CompareBuffer1, 0, BYTES_PER_CHUNK);
					var t2 = fs2.ReadAsync(this.CompareBuffer2, 0, BYTES_PER_CHUNK);

					Task.WaitAll(t1, t2);

					int read_1 = t1.Result;
					int read_2 = t2.Result;
					if (read_1 != read_2) throw new Exception($"Read {read_1} bytes from file \"{first.Name}\", but {read_2} bytes from \"{second.Name}\".");

					bool equal = UnsafeCompare(this.CompareBuffer1, this.CompareBuffer2, read_1);
					if (!equal)
					{
						return false;
					}
				}
			}

			return true;
		}

		// Copyright (c) 2008-2013 Hafthor Stefansson
		// Distributed under the MIT/X11 software license
		// Ref: http://www.opensource.org/licenses/mit-license.php.
		private static unsafe bool UnsafeCompare(byte[] a1, byte[] a2, int length)
		{
			// This is taken from some stackoverflow answer, changed so that the length is not inferred from the arrays.
			// Also, note that this does 8-byte comparisons, which is efficient on 64 bit, but is probably not optimal on 32 bit.
			// Normally I'd use Debug.Assert here, but since this is actually doing unsafe stuff, I'd rather throw for sure.
			if (a1 == null) throw new ArgumentNullException(nameof(a1));
			if (a2 == null) throw new ArgumentNullException(nameof(a2));
			if (a1.Length < length) throw new ArgumentOutOfRangeException(nameof(a1));
			if (a2.Length < length) throw new ArgumentOutOfRangeException(nameof(a2));
			if (a1 == a2) return true;
			
			fixed (byte* p1 = a1, p2 = a2)
			{
				byte* x1 = p1, x2 = p2;
				int l = length;
				for (int i = 0; i < l / 8; i++, x1 += 8, x2 += 8)
				{
					if (*((long*)x1) != *((long*)x2)) return false;
				}
				// Tail:
				if ((l & 4) != 0) { if (*((int*)x1) != *((int*)x2)) return false; x1 += 4; x2 += 4; }
				if ((l & 2) != 0) { if (*((short*)x1) != *((short*)x2)) return false; x1 += 2; x2 += 2; }
				if ((l & 1) != 0) if (*((byte*)x1) != *((byte*)x2)) return false;
				return true;
			}
		}
	}

	struct Difference
	{
		public string FileName { get; }
		public DifferenceType Type { get; }

		public Difference(string fileName, DifferenceType differenceType)
		{
			this.FileName = fileName;
			this.Type = differenceType;
		}

		public override string ToString()
		{
			return String.Format("{0}: {1}", this.Type, this.FileName);
		}
	}

	enum DifferenceType
	{
		MissingInSuperset,
		ContentDifferent,
		Exception
	}
}
