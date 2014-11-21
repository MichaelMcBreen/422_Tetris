using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;

using tetris;

namespace TetrisTest
{
    [TestClass]
    public class FieldTests
    {

        [TestMethod]
        public void InitWithValidWidthHeight()
        {
            Field field = new Field(10, 20);


            Assert.IsTrue(field.fieldWidth == (10 + 2), "Field created with incorrect width.");
            Assert.IsTrue(field.fieldHeight == (20 + Globals.PADDING + 1), "Field created with invalid height.");
        }
        [TestMethod]
        public void InitWithValidWidthInvalidHeight()
        {
            Field field = new Field(4, -1);

            Assert.IsTrue(field.fieldWidth == (4 + 2), "Field created with incorrect width.");
            Assert.IsFalse(field.fieldHeight == (-1 + Globals.PADDING + 1) , "Field created with invalid height.");


        }
        [TestMethod]
        public void InitWithValidHeightInvalidWidth()
        {
            Field field = new Field(-1, -1);

            Assert.IsFalse(field.fieldWidth == (-1 + 2), "Field created with invalid width.");
            Assert.IsFalse(field.fieldHeight == (-1 + Globals.PADDING + 1), "Field freated with invalid height.");

        }

        [TestMethod]
        public void InitWithInvalidWidthHeight()
        {
            Field field = new Field(4, -1);

            Assert.IsTrue(field.fieldWidth == (4 + 2), "Field created with invalid width.");
            Assert.IsFalse(field.fieldHeight == (-1 + Globals.PADDING + 1), "Field freated with invalid height.");
        }

        [TestMethod]
        public void CheckPieceValidShapeLocation()
        {
            Field field = new Field(10, 20);

            int[,] shape = new int[4, 4];
            Tetronimo tetronimo = new Tetronimo(1);
            Globals.coords coords = new Globals.coords();
            coords.x = 5;
            coords.y = 0;
            Assert.IsTrue(field.checkPiece(tetronimo.shape, coords), "Valid Shape and location");
        }
        [TestMethod]
        public void CheckPieceValidShapeInvalidLocation()
        {
            Field field = new Field(10, 20);

            int[,] shape = new int[4, 4];
            Tetronimo tetronimo = new Tetronimo(1);
            Globals.coords coords = new Globals.coords();
            coords.x = -5;
            coords.y = -1;
            Assert.IsFalse(field.checkPiece(tetronimo.shape, coords), "Valid Shape and Invalid location");
        }
    }
}
