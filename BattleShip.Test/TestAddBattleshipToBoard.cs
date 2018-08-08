using System;
using System.Drawing;
using Battleship.Commons;
using Battleship.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShip.Test
{
    [TestClass]
    public class TestAddBattleshipToBoard
    {
        [TestClass]
        public class AddShipTests
        {
            [TestMethod]
            public void Should_Add_Battleship_On_Board_Horizontal_Orientation()
            {
                var board = new Board();

                var battleship1 = new Battleship.Models.Battleship(5);
                board.AddBattleship(battleship1, BattleshipOrientation.Horizontal, new Point(0, 0));

                var positions = board.GetBattleshipPositions(battleship1);

                Assert.IsNotNull(positions);
                Assert.AreEqual(5, positions.Count);
                for (int i = 0; i < 5; i++)
                {
                    Assert.AreEqual(true, positions.Contains(new Point(i, 0)));
                }

                var battleship2 = new Battleship.Models.Battleship(5);
                board.AddBattleship(battleship2, BattleshipOrientation.Horizontal, new Point(5, 0));

                positions = board.GetBattleshipPositions(battleship2);

                Assert.IsNotNull(positions);
                Assert.AreEqual(5, positions.Count);
                for (int i = 5; i < 10; i++)
                {
                    Assert.AreEqual(true, positions.Contains(new Point(i, 0)));
                }
            }

            [TestMethod]
            public void Should_Add_Battleship_On_Board_Vertical_Orientation()
            {
                var board = new Board();

                var battleship1 = new Battleship.Models.Battleship(5);
                board.AddBattleship(battleship1, BattleshipOrientation.Vertical, new Point(0, 0));

                var positions = board.GetBattleshipPositions(battleship1);

                Assert.IsNotNull(positions);
                Assert.AreEqual(5, positions.Count);
                for (int i = 0; i < 5; i++)
                {
                    Assert.AreEqual(true, positions.Contains(new Point(0, i)));
                }

                var battleship2 = new Battleship.Models.Battleship(5);
                board.AddBattleship(battleship2, BattleshipOrientation.Vertical, new Point(5, 0));

                positions = board.GetBattleshipPositions(battleship2);

                Assert.IsNotNull(positions);
                Assert.AreEqual(5, positions.Count);
                for (int i = 0; i < 5; i++)
                {
                    Assert.AreEqual(true, positions.Contains(new Point(5, i)));
                }
            }

            [ExpectedException(typeof(PositionConflictException))]
            [TestMethod]
            public void Should_Cannot_Add_Overlapping_Battleships()
            {
                var board = new Board();

                var battleship1 = new Battleship.Models.Battleship(5);
                board.AddBattleship(battleship1, BattleshipOrientation.Horizontal, new Point(2, 1));

                var positions = board.GetBattleshipPositions(battleship1);

                Assert.IsNotNull(positions);
                Assert.AreEqual(5, positions.Count);
                for (int i = 2; i < 7; i++)
                {
                    Assert.AreEqual(true, positions.Contains(new Point(i, 1)));
                }

                var battleship2 = new Battleship.Models.Battleship(3);
                board.AddBattleship(battleship2, BattleshipOrientation.Horizontal, new Point(6, 1));
            }
        }
    }
}
