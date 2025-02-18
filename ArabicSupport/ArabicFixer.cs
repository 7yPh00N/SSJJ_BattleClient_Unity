using System;

namespace ArabicSupport
{
	// Token: 0x02000002 RID: 2
	public class ArabicFixer
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static string Fix(string str)
		{
			return ArabicFixer.Fix(str, false, true);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000206C File Offset: 0x0000026C
		public static string Fix(string str, bool showTashkeel, bool useHinduNumbers)
		{
			ArabicFixerTool.showTashkeel = showTashkeel;
			ArabicFixerTool.useHinduNumbers = useHinduNumbers;
			if (str.Contains("\n"))
			{
				str = str.Replace("\n", Environment.NewLine);
			}
			string result;
			if (str.Contains(Environment.NewLine))
			{
				string[] separator = new string[] { Environment.NewLine };
				string[] array = str.Split(separator, StringSplitOptions.None);
				if (array.Length == 0)
				{
					result = ArabicFixerTool.FixLine(str);
				}
				else if (array.Length == 1)
				{
					result = ArabicFixerTool.FixLine(str);
				}
				else
				{
					string text = ArabicFixerTool.FixLine(array[0]);
					int i = 1;
					if (array.Length > 1)
					{
						while (i < array.Length)
						{
							text = text + Environment.NewLine + ArabicFixerTool.FixLine(array[i]);
							i++;
						}
					}
					result = text;
				}
			}
			else
			{
				result = ArabicFixerTool.FixLine(str);
			}
			return result;
		}
	}
}
