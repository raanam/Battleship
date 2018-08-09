using Models = Battleship.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Test
{
    [TestClass]
    public class TestAttackBattleship
    {
        [TestMethod]
        public void Should_Accept_Hit_At_Valid_Position()
        {
            var board = new Models.Board();

            var battleship1 = new Models.Battleship(5);
            board.AddBattleship(battleship1,
                                Models.BattleshipOrientation.Horizontal,
                                new System.Drawing.Point(0, 3));

            var wasHit = board.TakeAttack(new System.Drawing.Point(2, 3));
            Assert.AreEqual(true, wasHit);
        }

        [TestMethod]
        public void Should_Not_Accept_Hit_At_InValid_Position()
        {
            var board = new Models.Board();

            var battleship1 = new Models.Battleship(5);
            board.AddBattleship(battleship1,
                                Models.BattleshipOrientation.Horizontal,
                                new System.Drawing.Point(3, 3));

            var wasHit = board.TakeAttack(new System.Drawing.Point(2, 3));
            Assert.AreEqual(false, wasHit);
        }

        [TestMethod]
        public void Ship_Should_Sink_If_All_Positions_hit()
        {
            var board = new Models.Board();

            var battleship1 = new Models.Battleship(3);
            board.AddBattleship(battleship1,
                                Models.BattleshipOrientation.Horizontal,
                                new System.Drawing.Point(3, 3));

            board.TakeAttack(new System.Drawing.Point(3, 3));
            board.TakeAttack(new System.Drawing.Point(4, 3));
            board.TakeAttack(new System.Drawing.Point(5, 3));

            Assert.AreEqual(true, battleship1.IsSunk);
        }

        [TestMethod]
        public void Ship_Should_Not_Sink_Unless_All_Positions_Are_hit()
        {
            var board = new Models.Board();

            var battleship1 = new Models.Battleship(4);
            board.AddBattleship(battleship1,
                                Models.BattleshipOrientation.Horizontal,
                                new System.Drawing.Point(3, 3));

            board.TakeAttack(new System.Drawing.Point(3, 3));
            board.TakeAttack(new System.Drawing.Point(3, 4));
            board.TakeAttack(new System.Drawing.Point(3, 5));

            Assert.AreEqual(false, battleship1.IsSunk);
        }

        [TestMethod]
        public void Should_Not_Win_Unless_All_Ships_Are_Sunk()
        {
            var board = new Models.Board();

            var battleship1 = new Models.Battleship(3);
            board.AddBattleship(battleship1,
                                Models.BattleshipOrientation.Horizontal,
                                new System.Drawing.Point(3, 3));

            board.TakeAttack(new System.Drawing.Point(3, 3));
            board.TakeAttack(new System.Drawing.Point(4, 3));
            board.TakeAttack(new System.Drawing.Point(5, 3));

            var battleship2 = new Models.Battleship(3);
            board.AddBattleship(battleship2,
                                Models.BattleshipOrientation.Vertical,
                                new System.Drawing.Point(0, 0));

            board.TakeAttack(new System.Drawing.Point(0, 0));
            board.TakeAttack(new System.Drawing.Point(0, 1));

            Assert.AreEqual(false, board.Won());
        }

        [TestMethod]
        public void Should_Win_When_All_Ships_Are_Sunk()
        {
            var board = new Models.Board();

            var battleship1 = new Models.Battleship(3);
            board.AddBattleship(battleship1,
                                Models.BattleshipOrientation.Horizontal,
                                new System.Drawing.Point(3, 3));

            board.TakeAttack(new System.Drawing.Point(3, 3));
            board.TakeAttack(new System.Drawing.Point(4, 3));
            board.TakeAttack(new System.Drawing.Point(5, 3));

            var battleship2 = new Models.Battleship(3);
            board.AddBattleship(battleship2,
                                Models.BattleshipOrientation.Vertical,
                                new System.Drawing.Point(0, 0));

            board.TakeAttack(new System.Drawing.Point(0, 0));
            board.TakeAttack(new System.Drawing.Point(0, 1));
            board.TakeAttack(new System.Drawing.Point(0, 2));

            Assert.AreEqual(true, board.Won());
        }
    }
}
