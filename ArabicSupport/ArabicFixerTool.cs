using System;
using System.Collections.Generic;

// Token: 0x02000008 RID: 8
internal class ArabicFixerTool
{
	// Token: 0x06000009 RID: 9 RVA: 0x00002694 File Offset: 0x00000894
	internal static string RemoveTashkeel(string str, out List<TashkeelLocation> tashkeelLocation)
	{
		tashkeelLocation = new List<TashkeelLocation>();
		char[] array = str.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == '\u064b')
			{
				tashkeelLocation.Add(new TashkeelLocation('\u064b', i));
			}
			else if (array[i] == '\u064c')
			{
				tashkeelLocation.Add(new TashkeelLocation('\u064c', i));
			}
			else if (array[i] == '\u064d')
			{
				tashkeelLocation.Add(new TashkeelLocation('\u064d', i));
			}
			else if (array[i] == '\u064e')
			{
				tashkeelLocation.Add(new TashkeelLocation('\u064e', i));
			}
			else if (array[i] == '\u064f')
			{
				tashkeelLocation.Add(new TashkeelLocation('\u064f', i));
			}
			else if (array[i] == '\u0650')
			{
				tashkeelLocation.Add(new TashkeelLocation('\u0650', i));
			}
			else if (array[i] == '\u0651')
			{
				tashkeelLocation.Add(new TashkeelLocation('\u0651', i));
			}
			else if (array[i] == '\u0652')
			{
				tashkeelLocation.Add(new TashkeelLocation('\u0652', i));
			}
			else if (array[i] == '\u0653')
			{
				tashkeelLocation.Add(new TashkeelLocation('\u0653', i));
			}
		}
		string[] array2 = str.Split(new char[] { '\u064b', '\u064c', '\u064d', '\u064e', '\u064f', '\u0650', '\u0651', '\u0652', '\u0653' });
		str = "";
		foreach (string str2 in array2)
		{
			str += str2;
		}
		return str;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002898 File Offset: 0x00000A98
	internal static char[] ReturnTashkeel(char[] letters, List<TashkeelLocation> tashkeelLocation)
	{
		char[] array = new char[letters.Length + tashkeelLocation.Count];
		int num = 0;
		for (int i = 0; i < letters.Length; i++)
		{
			array[num] = letters[i];
			num++;
			foreach (TashkeelLocation tashkeelLocation2 in tashkeelLocation)
			{
				if (tashkeelLocation2.position == num)
				{
					array[num] = tashkeelLocation2.tashkeel;
					num++;
				}
			}
		}
		return array;
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002944 File Offset: 0x00000B44
	internal static string FixLine(string str)
	{
		string str2 = "";
		List<TashkeelLocation> tashkeelLocation;
		string text = ArabicFixerTool.RemoveTashkeel(str, out tashkeelLocation);
		char[] array = text.ToCharArray();
		char[] array2 = text.ToCharArray();
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (char)ArabicTable.ArabicMapper.Convert((int)array[i]);
		}
		for (int i = 0; i < array.Length; i++)
		{
			bool flag = false;
			if (i == 2)
			{
				num = 0;
			}
			if (array[i] == '\udf21')
			{
				num = num;
			}
			if (array[i] == 'ﻝ')
			{
				if (i < array.Length - 1)
				{
					if (array[i + 1] == 'ﺇ')
					{
						array[i] = 'ﻷ';
						array2[i + 1] = char.MaxValue;
						flag = true;
					}
					else if (array[i + 1] == 'ﺍ')
					{
						array[i] = 'ﻹ';
						array2[i + 1] = char.MaxValue;
						flag = true;
					}
					else if (array[i + 1] == 'ﺃ')
					{
						array[i] = 'ﻵ';
						array2[i + 1] = char.MaxValue;
						flag = true;
					}
					else if (array[i + 1] == 'ﺁ')
					{
						array[i] = 'ﻳ';
						array2[i + 1] = char.MaxValue;
						flag = true;
					}
				}
			}
			if (!ArabicFixerTool.IsIgnoredCharacter(array[i]) && array[i] != 'A' && array[i] != 'A')
			{
				if (ArabicFixerTool.IsMiddleLetter(array, i))
				{
					array2[i] = array[i] + '\u0003';
				}
				else if (ArabicFixerTool.IsFinishingLetter(array, i))
				{
					array2[i] = array[i] + '\u0001';
				}
				else if (ArabicFixerTool.IsLeadingLetter(array, i))
				{
					array2[i] = array[i] + '\u0002';
				}
			}
			str2 = str2 + Convert.ToString((int)array[i], 16) + " ";
			if (flag)
			{
				i++;
			}
			if (ArabicFixerTool.useHinduNumbers)
			{
				if (array[i] == '0')
				{
					array2[i] = '٠';
				}
				else if (array[i] == '1')
				{
					array2[i] = '١';
				}
				else if (array[i] == '2')
				{
					array2[i] = '٢';
				}
				else if (array[i] == '3')
				{
					array2[i] = '٣';
				}
				else if (array[i] == '4')
				{
					array2[i] = '٤';
				}
				else if (array[i] == '5')
				{
					array2[i] = '٥';
				}
				else if (array[i] == '6')
				{
					array2[i] = '٦';
				}
				else if (array[i] == '7')
				{
					array2[i] = '٧';
				}
				else if (array[i] == '8')
				{
					array2[i] = '٨';
				}
				else if (array[i] == '9')
				{
					array2[i] = '٩';
				}
			}
		}
		if (ArabicFixerTool.showTashkeel)
		{
			array2 = ArabicFixerTool.ReturnTashkeel(array2, tashkeelLocation);
		}
		List<char> list = new List<char>();
		List<char> list2 = new List<char>();
		for (int i = array2.Length - 1; i >= 0; i--)
		{
			if (char.IsPunctuation(array2[i]) && i > 0 && i < array2.Length - 1 && (char.IsPunctuation(array2[i - 1]) || char.IsPunctuation(array2[i + 1])))
			{
				if (array2[i] == '(')
				{
					list.Add(')');
				}
				else if (array2[i] == ')')
				{
					list.Add('(');
				}
				else if (array2[i] == '<')
				{
					list.Add('>');
				}
				else if (array2[i] == '>')
				{
					list.Add('<');
				}
				else if (array2[i] != '\uffff')
				{
					list.Add(array2[i]);
				}
			}
			else if (array2[i] == ' ' && i > 0 && i < array2.Length - 1 && (char.IsLower(array2[i - 1]) || char.IsUpper(array2[i - 1]) || char.IsNumber(array2[i - 1])) && (char.IsLower(array2[i + 1]) || char.IsUpper(array2[i + 1]) || char.IsNumber(array2[i + 1])))
			{
				list2.Add(array2[i]);
			}
			else if (char.IsNumber(array2[i]) || char.IsLower(array2[i]) || char.IsUpper(array2[i]) || char.IsSymbol(array2[i]) || char.IsPunctuation(array2[i]))
			{
				if (array2[i] == '(')
				{
					list2.Add(')');
				}
				else if (array2[i] == ')')
				{
					list2.Add('(');
				}
				else if (array2[i] == '<')
				{
					list2.Add('>');
				}
				else if (array2[i] == '>')
				{
					list2.Add('<');
				}
				else
				{
					list2.Add(array2[i]);
				}
			}
			else if ((array2[i] >= '\ud800' && array2[i] <= '\udbff') || (array2[i] >= '\udc00' && array2[i] <= '\udfff'))
			{
				list2.Add(array2[i]);
			}
			else
			{
				if (list2.Count > 0)
				{
					for (int j = 0; j < list2.Count; j++)
					{
						list.Add(list2[list2.Count - 1 - j]);
					}
					list2.Clear();
				}
				if (array2[i] != '\uffff')
				{
					list.Add(array2[i]);
				}
			}
		}
		if (list2.Count > 0)
		{
			for (int j = 0; j < list2.Count; j++)
			{
				list.Add(list2[list2.Count - 1 - j]);
			}
			list2.Clear();
		}
		array2 = new char[list.Count];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = list[i];
		}
		str = new string(array2);
		return str;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000030C0 File Offset: 0x000012C0
	internal static bool IsIgnoredCharacter(char ch)
	{
		bool flag = char.IsPunctuation(ch);
		bool flag2 = char.IsNumber(ch);
		bool flag3 = char.IsLower(ch);
		bool flag4 = char.IsUpper(ch);
		bool flag5 = char.IsSymbol(ch);
		bool flag6 = ch == 'ﭖ' || ch == 'ﭺ' || ch == 'ﮊ' || ch == 'ﮒ';
		bool flag7 = (ch <= '\ufeff' && ch >= 'ﹰ') || flag6;
		return flag || flag2 || flag3 || flag4 || flag5 || !flag7 || ch == 'a' || ch == '>' || ch == '<' || ch == '؛';
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00003170 File Offset: 0x00001370
	internal static bool IsLeadingLetter(char[] letters, int index)
	{
		return (index == 0 || letters[index - 1] == ' ' || letters[index - 1] == '*' || letters[index - 1] == 'A' || char.IsPunctuation(letters[index - 1]) || letters[index - 1] == '>' || letters[index - 1] == '<' || letters[index - 1] == 'ﺍ' || letters[index - 1] == 'ﺩ' || letters[index - 1] == 'ﺫ' || letters[index - 1] == 'ﺭ' || letters[index - 1] == 'ﺯ' || letters[index - 1] == 'ﮊ' || letters[index - 1] == 'ﻯ' || letters[index - 1] == 'ﻭ' || letters[index - 1] == 'ﺁ' || letters[index - 1] == 'ﺃ' || letters[index - 1] == 'ﺇ' || letters[index - 1] == 'ﺅ') && letters[index] != ' ' && letters[index] != 'ﺩ' && letters[index] != 'ﺫ' && letters[index] != 'ﺭ' && letters[index] != 'ﺯ' && letters[index] != 'ﮊ' && letters[index] != 'ﺍ' && letters[index] != 'ﺃ' && letters[index] != 'ﺇ' && letters[index] != 'ﻭ' && letters[index] != 'ﺀ' && index < letters.Length - 1 && letters[index + 1] != ' ' && !char.IsPunctuation(letters[index + 1]) && letters[index + 1] != 'ﺀ';
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00003310 File Offset: 0x00001510
	internal static bool IsFinishingLetter(char[] letters, int index)
	{
		return index != 0 && letters[index - 1] != ' ' && letters[index - 1] != '*' && letters[index - 1] != 'A' && letters[index - 1] != 'ﺩ' && letters[index - 1] != 'ﺫ' && letters[index - 1] != 'ﺭ' && letters[index - 1] != 'ﺯ' && letters[index - 1] != 'ﮊ' && letters[index - 1] != 'ﻯ' && letters[index - 1] != 'ﻭ' && letters[index - 1] != 'ﺍ' && letters[index - 1] != 'ﺁ' && letters[index - 1] != 'ﺃ' && letters[index - 1] != 'ﺇ' && letters[index - 1] != 'ﺅ' && letters[index - 1] != 'ﺀ' && !char.IsPunctuation(letters[index - 1]) && letters[index - 1] != '>' && letters[index - 1] != '<' && letters[index] != ' ' && index < letters.Length && letters[index] != 'ﺀ';
	}

	// Token: 0x0600000F RID: 15 RVA: 0x0000343C File Offset: 0x0000163C
	internal static bool IsMiddleLetter(char[] letters, int index)
	{
		if (index != 0 && letters[index] != ' ' && letters[index] != 'ﺍ' && letters[index] != 'ﺩ' && letters[index] != 'ﺫ' && letters[index] != 'ﺭ' && letters[index] != 'ﺯ' && letters[index] != 'ﮊ' && letters[index] != 'ﻯ' && letters[index] != 'ﻭ' && letters[index] != 'ﺁ' && letters[index] != 'ﺃ' && letters[index] != 'ﺇ' && letters[index] != 'ﺅ' && letters[index] != 'ﺀ' && letters[index - 1] != 'ﺍ' && letters[index - 1] != 'ﺩ' && letters[index - 1] != 'ﺫ' && letters[index - 1] != 'ﺭ' && letters[index - 1] != 'ﺯ' && letters[index - 1] != 'ﮊ' && letters[index - 1] != 'ﻯ' && letters[index - 1] != 'ﻭ' && letters[index - 1] != 'ﺁ' && letters[index - 1] != 'ﺃ' && letters[index - 1] != 'ﺇ' && letters[index - 1] != 'ﺅ' && letters[index - 1] != 'ﺀ' && letters[index - 1] != '>' && letters[index - 1] != '<' && letters[index - 1] != ' ' && letters[index - 1] != '*' && !char.IsPunctuation(letters[index - 1]) && index < letters.Length - 1 && letters[index + 1] != ' ' && letters[index + 1] != '\r' && letters[index + 1] != 'A' && letters[index + 1] != '>' && letters[index + 1] != '>' && letters[index + 1] != 'ﺀ')
		{
			try
			{
				if (char.IsPunctuation(letters[index + 1]))
				{
					return false;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	// Token: 0x04000059 RID: 89
	internal static bool showTashkeel = true;

	// Token: 0x0400005A RID: 90
	internal static bool useHinduNumbers = false;
}
