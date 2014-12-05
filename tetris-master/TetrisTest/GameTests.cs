using System;
using tetris;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTest
{
	[TestClass]
	public class GameTests
	{
		[TestMethod]
		public void CheckGame()
		{
			Game1 g = new Game1();
			Assert.IsTrue(Globals.graphics != null);
			Assert.IsTrue(Globals.content != null);
			Assert.IsTrue(Globals.graphics != null);
			Assert.IsTrue(Globals.content.RootDirectory == "Content");
			Assert.IsTrue(Globals.graphics.PreferredBackBufferHeight == 768);
			Assert.IsTrue(Globals.graphics.PreferredBackBufferWidth == 1024);
		}
		[TestMethod]
		public void CheckInitialize()
		{
			Game1 g = new Game1();
			g.init();
			List<string> pausedItems = new List<string>();
			pausedItems.Add("PAUSED");
			pausedItems.Add("Continue Game");
			pausedItems.Add("Exit Game");
			foreach (string s in pausedItems)
			{
				Assert.IsTrue(g.getPausedItems().Contains(s), "Paused item test");
			}
			List<string> mainMenuItems = new List<string>();
			mainMenuItems.Add("A Game of Blocks and Lines");
			mainMenuItems.Add("New Game");
			mainMenuItems.Add("Exit Game");
			foreach (string s in mainMenuItems)
			{
				Assert.IsTrue(g.getMainMenuItems().Contains(s), "Main Menu item test");
			}
			List<string> gameOverItems = new List<string>();
			gameOverItems.Add("Game Over!");
			gameOverItems.Add("New Game");
			gameOverItems.Add("Exit Game");
			foreach (string s in gameOverItems)
			{
				Assert.IsTrue(g.getGameOverItems().Contains(s), "Paused item test");
			}
			List<string> instructionItems = new List<string>();
			instructionItems.Add("Up - Rotate Clockwise");
			instructionItems.Add("Left/Right - Move Piece");
			instructionItems.Add("Down - Move Down (Soft Drop)");
			instructionItems.Add("Space - Hard Drop");
			instructionItems.Add("X - Rotate Counter-Clockwise");
			instructionItems.Add("C - Hold Piece");
			instructionItems.Add("Esc - Pause");
			foreach (string s in instructionItems)
			{
				Assert.IsTrue(g.getInstructionItems().Contains(s), "Paused item test");
			}
			Globals.coords next = new Globals.coords();

			Globals.coords held = new Globals.coords();
			next.x = 350;
			next.y = 55;
			held.x = 350;
			held.y = 225;
			Assert.IsTrue(g.getNextLocation().x.Equals(next.x));
			Assert.IsTrue(g.getNextLocation().y.Equals(next.y));
			Assert.IsTrue(g.getHeldLocation().x.Equals(held.x));
			Assert.IsTrue(g.getHeldLocation().y.Equals(held.y));
		}

        [TestMethod]
		public void MovePieceDownValid()
        {
            Game1 g = new Game1();
            g.init();
            Assert.IsTrue(g.ValidMoveTest(direction.DOWN, 1, 1, 1));
        }

        [TestMethod]
        public void MovePieceLeftValid()
        {
            Game1 g = new Game1();
            g.init();
            Assert.IsTrue(g.ValidMoveTest(direction.LEFT, 1, 1, 1));
        }
        [TestMethod]
        public void MovePieceLeftInValid()
        {
            Game1 g = new Game1();
            g.init();
            Assert.IsFalse(g.ValidMoveTest(direction.LEFT, 0, 1, 1));
        }
	}
}
