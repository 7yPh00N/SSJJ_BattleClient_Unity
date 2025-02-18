using System;

namespace Accessibility
{
	// Token: 0x02000002 RID: 2
	public interface IAccessible
	{
		// Token: 0x06000001 RID: 1
		void accDoDefaultAction(object childID);

		// Token: 0x06000002 RID: 2
		object accHitTest(int xLeft, int yTop);

		// Token: 0x06000003 RID: 3
		void accLocation(out int pxLeft, out int pyTop, out int pcxWidth, out int pcyHeight, object childID);

		// Token: 0x06000004 RID: 4
		object accNavigate(int navDir, object childID);

		// Token: 0x06000005 RID: 5
		void accSelect(int flagsSelect, object childID);

		// Token: 0x06000006 RID: 6
		object get_accChild(object childID);

		// Token: 0x06000007 RID: 7
		string get_accDefaultAction(object childID);

		// Token: 0x06000008 RID: 8
		string get_accDescription(object childID);

		// Token: 0x06000009 RID: 9
		string get_accHelp(object childID);

		// Token: 0x0600000A RID: 10
		int get_accHelpTopic(out string pszHelpFile, object childID);

		// Token: 0x0600000B RID: 11
		string get_accKeyboardShortcut(object childID);

		// Token: 0x0600000C RID: 12
		string get_accName(object childID);

		// Token: 0x0600000D RID: 13
		object get_accRole(object childID);

		// Token: 0x0600000E RID: 14
		object get_accState(object childID);

		// Token: 0x0600000F RID: 15
		string get_accValue(object childID);

		// Token: 0x06000010 RID: 16
		void set_accName(object childID, string newName);

		// Token: 0x06000011 RID: 17
		void set_accValue(object childID, string newValue);

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000012 RID: 18
		int accChildCount { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000013 RID: 19
		object accFocus { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000014 RID: 20
		object accParent { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000015 RID: 21
		object accSelection { get; }
	}
}
