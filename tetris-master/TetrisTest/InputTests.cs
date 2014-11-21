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
    public class InputTests
    {
        [TestMethod]
        public void PressDown()
        {
            KBInput input = new KBInput();
            Microsoft.Xna.Framework.Input.Keys[] test = new Microsoft.Xna.Framework.Input.Keys[1];
            test[0] = Microsoft.Xna.Framework.Input.Keys.Down;
            input.setKeyPress(test);
            Assert.IsTrue(input.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down, true));
        }
    }
}
