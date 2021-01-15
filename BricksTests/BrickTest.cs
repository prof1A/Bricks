using System;
using NUnit.Framework;
using Bricks.Classes;
using System.Collections.Generic;
using System.Linq;

namespace BricksTests
{
    [TestFixture]
    public class BrickTest
    {
        [Test]
        public void WinField()
        {
            var menu = new MenuFunction();

            Brick[] bricks = new Brick[16];

            for (int i = 0; i < bricks.Length; i++)
            {

                if (i == bricks.Length - 1)
                {
                    Brick brickk = new Brick("*");

                    bricks[i] = brickk;
                }
                else
                {
                    Brick brick = new Brick(Convert.ToString(i + 1));

                    bricks[i] = brick;
                }
            }

            Assert.AreEqual(true, menu.Win(bricks));
        }

        [Test]
        public void LastBricks()
        {

            GameHistory gameHistory = new GameHistory();

            Brick[] brick1 = new Brick[16];

            for (int i = 0; i < brick1.Length; i++)
            {

                if (i == brick1.Length - 1)
                {
                    Brick brickk = new Brick("*");

                    brick1[i] = brickk;
                }
                else
                {
                    Brick brick = new Brick(Convert.ToString(i + 1));

                    brick1[i] = brick;
                }
            }

            Brick[] brick2 = new Brick[16];

            for (int i = 0; i < brick2.Length; i++)
            {

                if (i == brick2.Length - 1)
                {
                    Brick brickk = new Brick("*");

                    brick2[i] = brickk;
                }
                else
                {
                    Brick brick = new Brick(Convert.ToString(i + 1));

                    brick2[i] = brick;
                }
            }

            Brick[] brick3 = new Brick[16];

            for (int i = 0; i < brick3.Length; i++)
            {

                if (i == brick3.Length - 1)
                {
                    Brick brickk = new Brick("*");

                    brick3[i] = brickk;
                }
                else
                {
                    Brick brick = new Brick(Convert.ToString(i + 1));

                    brick3[i] = brick;
                }

                gameHistory.History.Push(brick1);

                gameHistory.History.Push(brick2);

                gameHistory.History.Push(brick3);

                Assert.AreEqual(brick3, gameHistory.History.Pop());
            }
        }

        [Test]
        public void ContainsNumberOfField()
        {
            var menu = new MenuFunction();

            int[] bricks = new int[15];

            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i] = i + 1;
            }

            Assert.AreEqual(true, menu.Contains(bricks.ToList(),3));
        }
    }
}