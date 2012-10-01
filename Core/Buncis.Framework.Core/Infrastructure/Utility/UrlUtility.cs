namespace Buncis.Framework.Core.Infrastructure.Utility
{
	public static class UrlUtility
	{
		public static int Scramble(int clean)
		{
			var calculated = (clean * 7) + 12;
			return calculated;
		}

		public static int Translate(int scrambled)
		{
			if (scrambled <= 0)
			{
				return scrambled;
			}

			var clean = (scrambled - 12) / 7;
			return clean;
		}

		public static string CleanTitle(string rawTitle)
		{
			var clean = rawTitle.Replace(" ", "-");
			clean = clean.Replace("'", "-");
			clean = clean.Replace(",", "-");
			clean = clean.Replace(".", "");
			clean = clean.Replace("\"", "-");
			clean = clean.Replace("\\", "-");
			clean = clean.Replace("/", "-");
			clean = clean.Replace(":", "-");

			clean = clean.Replace("--", "-");
			clean = clean.Replace("---", "-");
			clean = clean.Replace("----", "-");
			clean = clean.Replace("-----", "-");

			clean = clean.TrimStart('-');
			clean = clean.TrimEnd('-');

			return clean;
		}
	}
}
