using System;
using System.Windows.Forms;
using tetris;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTest
{
	[TestClass]
	public class MenuTests
	{
		[TestMethod]
		public void CheckMenuItems()
		{
			List<string> items = new List<string>();
			items.Add("one");
			items.Add("two");
			items.Add("three");
			tetris.Menu m = new tetris.Menu(items);
			foreach(string s in items){
				Assert.IsTrue(m.ReturnItems().Contains(s), "Menu item test");
			}
		}
		[TestMethod]
		public void CheckMenuState()
		{
			List<string> items = new List<string>();
			items.Add("PAUSED");
			items.Add("Continue Game");
			items.Add("Exit Game");
			tetris.Menu m = new tetris.Menu(items);
			int currentstate = m.ReturnState();
			SendKeys.SendWait("{DOWN}");
			Assert.IsTrue(currentstate != m.ReturnState(), "Down arrow Test");
		}
	}
}
