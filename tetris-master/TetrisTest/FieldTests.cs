using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using tetris;

//Game1.cs
//Written by Scott Porcaro, 2011
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
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
            Assert.IsTrue(field.fieldHeight != (-1 + Globals.PADDING + 1) , "Field created with invalid height.");


        }
        [TestMethod]
        public void InitWithValidHeightInvalidWidth()
        {
            Field field = new Field(-1, -1);

            Assert.IsTrue(field.fieldWidth != (-1 + 2), "Field created with invalid width.");
            Assert.IsTrue(field.fieldHeight != (-1 + Globals.PADDING + 1), "Field freated with invalid height.");

        }

        [TestMethod]
        public void InitWithInvalidWidthHeight()
        {
            Field field = new Field(4, -1);

            Assert.IsTrue(field.fieldWidth != (-1 + 2), "Field created with invalid width.");
            Assert.IsTrue(field.fieldHeight != (-1 + Globals.PADDING + 1), "Field freated with invalid height.");
        }
    }
}
