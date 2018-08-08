using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();

            var battleship1 = new Battleship.Models.Battleship(5);
            board.AddBattleship(battleship1, BattleshipOrientation.Horizontal, new System.Drawing.Point(0,0));

            var battleship2 = new Battleship.Models.Battleship(3);
            board.AddBattleship(battleship2, BattleshipOrientation.Vertical, new System.Drawing.Point(0, 1));

            var battleship3 = new Battleship.Models.Battleship(5);
            board.AddBattleship(battleship3, BattleshipOrientation.Horizontal, new System.Drawing.Point(4, 0));

            Console.WriteLine(board.ToString());

        }
    }
}
