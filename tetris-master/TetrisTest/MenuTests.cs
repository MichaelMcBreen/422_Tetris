using System;
using System.Windows.Forms;
using tetris;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
            m.fakeInput(Microsoft.Xna.Framework.Input.Keys.Down);
            m.testInput();
			Assert.IsTrue(currentstate != m.ReturnState(), "Down arrow Test");
		}
	}
}
