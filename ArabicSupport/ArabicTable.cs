using System;
using System.Collections.Generic;

// Token: 0x02000006 RID: 6
internal class ArabicTable
{
	// Token: 0x06000005 RID: 5 RVA: 0x0000218C File Offset: 0x0000038C
	private ArabicTable()
	{
		ArabicTable.mapList = new List<ArabicMapping>();
		ArabicTable.mapList.Add(new ArabicMapping(1569, 65152));
		ArabicTable.mapList.Add(new ArabicMapping(1575, 65165));
		ArabicTable.mapList.Add(new ArabicMapping(1571, 65155));
		ArabicTable.mapList.Add(new ArabicMapping(1572, 65157));
		ArabicTable.mapList.Add(new ArabicMapping(1573, 65159));
		ArabicTable.mapList.Add(new ArabicMapping(1609, 65263));
		ArabicTable.mapList.Add(new ArabicMapping(1574, 65161));
		ArabicTable.mapList.Add(new ArabicMapping(1576, 65167));
		ArabicTable.mapList.Add(new ArabicMapping(1578, 65173));
		ArabicTable.mapList.Add(new ArabicMapping(1579, 65177));
		ArabicTable.mapList.Add(new ArabicMapping(1580, 65181));
		ArabicTable.mapList.Add(new ArabicMapping(1581, 65185));
		ArabicTable.mapList.Add(new ArabicMapping(1582, 65189));
		ArabicTable.mapList.Add(new ArabicMapping(1583, 65193));
		ArabicTable.mapList.Add(new ArabicMapping(1584, 65195));
		ArabicTable.mapList.Add(new ArabicMapping(1585, 65197));
		ArabicTable.mapList.Add(new ArabicMapping(1586, 65199));
		ArabicTable.mapList.Add(new ArabicMapping(1587, 65201));
		ArabicTable.mapList.Add(new ArabicMapping(1588, 65205));
		ArabicTable.mapList.Add(new ArabicMapping(1589, 65209));
		ArabicTable.mapList.Add(new ArabicMapping(1590, 65213));
		ArabicTable.mapList.Add(new ArabicMapping(1591, 65217));
		ArabicTable.mapList.Add(new ArabicMapping(1592, 65221));
		ArabicTable.mapList.Add(new ArabicMapping(1593, 65225));
		ArabicTable.mapList.Add(new ArabicMapping(1594, 65229));
		ArabicTable.mapList.Add(new ArabicMapping(1601, 65233));
		ArabicTable.mapList.Add(new ArabicMapping(1602, 65237));
		ArabicTable.mapList.Add(new ArabicMapping(1603, 65241));
		ArabicTable.mapList.Add(new ArabicMapping(1604, 65245));
		ArabicTable.mapList.Add(new ArabicMapping(1605, 65249));
		ArabicTable.mapList.Add(new ArabicMapping(1606, 65253));
		ArabicTable.mapList.Add(new ArabicMapping(1607, 65257));
		ArabicTable.mapList.Add(new ArabicMapping(1608, 65261));
		ArabicTable.mapList.Add(new ArabicMapping(1610, 65265));
		ArabicTable.mapList.Add(new ArabicMapping(1570, 65153));
		ArabicTable.mapList.Add(new ArabicMapping(1577, 65171));
		ArabicTable.mapList.Add(new ArabicMapping(1662, 64342));
		ArabicTable.mapList.Add(new ArabicMapping(1670, 64378));
		ArabicTable.mapList.Add(new ArabicMapping(1688, 64394));
		ArabicTable.mapList.Add(new ArabicMapping(1711, 64402));
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000006 RID: 6 RVA: 0x000025BC File Offset: 0x000007BC
	internal static ArabicTable ArabicMapper
	{
		get
		{
			if (ArabicTable.arabicMapper == null)
			{
				ArabicTable.arabicMapper = new ArabicTable();
			}
			return ArabicTable.arabicMapper;
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000025EC File Offset: 0x000007EC
	internal int Convert(int toBeConverted)
	{
		foreach (ArabicMapping arabicMapping in ArabicTable.mapList)
		{
			if (arabicMapping.from == toBeConverted)
			{
				return arabicMapping.to;
			}
		}
		return toBeConverted;
	}

	// Token: 0x04000055 RID: 85
	private static List<ArabicMapping> mapList;

	// Token: 0x04000056 RID: 86
	private static ArabicTable arabicMapper;
}
