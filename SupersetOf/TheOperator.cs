using System;
using System.Collections.Generic;
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
			var differences = new List<Difference>();
			CompareRecursively(supersetDir, subsetDir, differences, ct);
			return differences;
		}

		private static void CompareRecursively(string supersetDir, string subsetDir, List<Difference> differences, CancellationToken ct)
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
					CompareFiles(supersetFile, subsetFile, differences);
				}

				var subDirectories = Directory.GetDirectories(subsetDir);
				foreach (var subDir in subDirectories.Select(x => Path.GetFileName(x)))
				{
					ct.ThrowIfCancellationRequested();

					var supsersetSubDir = Path.Combine(supersetDir, subDir);
					var subsetSubDir = Path.Combine(subsetDir, subDir);
					CompareRecursively(supsersetSubDir, subsetSubDir, differences, ct);
				}
			}
			catch
			{
				differences.Add(new Difference(subsetDir, DifferenceType.Exception));
			}
		}

		private static void CompareFiles(string supersetFile, string subsetFile, List<Difference> differences)
		{
			if (!File.Exists(supersetFile))
			{
				differences.Add(new Difference(subsetFile, DifferenceType.MissingInSuperset));
				return;
			}

			try
			{
				if (!FilesAreEqual(new FileInfo(supersetFile), new FileInfo(subsetFile)))
				{
					differences.Add(new Difference(subsetFile, DifferenceType.ContentDifferent));
				}
			}
			catch
			{
				differences.Add(new Difference(subsetFile, DifferenceType.Exception));
			}
		}

		static bool FilesAreEqual(FileInfo first, FileInfo second)
		{
			if (first.Length != second.Length)
				return false;

			const int BYTES_TO_READ = 4096;

			int iterations = (int)Math.Ceiling((double)first.Length / BYTES_TO_READ);

			using (FileStream fs1 = first.OpenRead())
			using (FileStream fs2 = second.OpenRead())
			{
				byte[] one = new byte[BYTES_TO_READ];
				byte[] two = new byte[BYTES_TO_READ];

				for (int i = 0; i < iterations; i++)
				{
					fs1.Read(one, 0, BYTES_TO_READ);
					fs2.Read(two, 0, BYTES_TO_READ);

					if (!one.SequenceEqual(two))
						return false;
				}
			}

			return true;
		}
	}

	class Difference
	{
		string FileName { get; }
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
