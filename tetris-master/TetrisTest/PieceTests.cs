using System;
using tetris;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTest
{
	[TestClass]
	public class PieceTests
	{
		[TestMethod]
		public void HoldPiece()
		{
			Game1 g = new Game1();
			g.DispatchPiece();
			g.DispatchPiece(true);
			Assert.IsTrue(g.getHeldPiece() > -1);
		}
		[TestMethod]
		public void GetHeldPiece()
		{
			Game1 g = new Game1();
			g.DispatchPiece();
			int currentPiece = g.getCurrPiece();
			int newPiece = (currentPiece + 1) % 7;
			g.setHeldPiece(newPiece);
			g.DispatchPiece(true);
			Assert.IsTrue(g.getCurrPiece() == newPiece);
		}

	}
}
