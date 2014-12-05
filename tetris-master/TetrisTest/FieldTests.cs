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

            Tetronimo tetronimo = new Tetronimo(1);
            Globals.coords coords = new Globals.coords();
            coords.x = -5;
            coords.y = -1;
            Assert.IsFalse(field.checkPiece(tetronimo.shape, coords), "Valid Shape and Invalid location");
        }

        [TestMethod]
        public void PlacePieceValidShapeLocation()
        {
            Field field = new Field(10, 20);

            Tetronimo tetronimo = new Tetronimo(1);
            Globals.coords coords = new Globals.coords();
            coords.x = 5;
            coords.y = 0;
            Assert.IsTrue(field.placePiece(tetronimo.shape, coords), "Valid Shape and location");
        }

        [TestMethod]
        public void PlacePieceValidShapeInvalidLocation()
        {
            Field field = new Field(10, 20);

            Tetronimo tetronimo = new Tetronimo(1);
            Globals.coords coords = new Globals.coords();
            coords.x = -5;
            coords.y = -1;
            Assert.IsFalse(field.placePiece(tetronimo.shape, coords), "Valid Shape and Invalid location");
        }

        [TestMethod]
        public void GetHardDropEmptyFieldValidShapeLocation()
        {
            Field field = new Field(10, 20);

            Tetronimo tetronimo = new Tetronimo(1);
            Globals.coords coords = new Globals.coords();
            coords.x = 5;
            coords.y = 0;
            Globals.coords drop_loc = new Globals.coords();
            drop_loc.x = 5;
            drop_loc.y = 20;
            Assert.IsTrue(field.getHardDrop(tetronimo.shape, coords).x == drop_loc.x, "Invalid Hard Drop location. (x)");
            Assert.IsTrue(field.getHardDrop(tetronimo.shape, coords).y == drop_loc.y, "Invalid Hard Drop location. (y)");
        }

        [TestMethod]
        public void GetHardDropEmptyFieldValidShapeInvalidLocation()
        {
            Field field = new Field(10, 20);

            Tetronimo tetronimo = new Tetronimo(1);
            Globals.coords coords = new Globals.coords();
            coords.x = -5;
            coords.y = -1;
            // Should return the same location as it supplies.
            Assert.IsTrue(field.getHardDrop(tetronimo.shape, coords).x == coords.x, "Invalid Hard Drop location. (x)");
            Assert.IsTrue(field.getHardDrop(tetronimo.shape, coords).y == coords.y, "Invalid Hard Drop location. (y)");
        }
    }
}
