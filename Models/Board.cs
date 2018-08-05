using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Battleship.Models
{
    public class Board
    {
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public IEnumerable<Battleship> Battleships { get; private set; }

        // Co-ordinates from 0,0 to 9,9 for 10 x 10 Grid.
        private List<Point> OccupiedCells;

        private Dictionary<Battleship, List<Point>> BattleshipPositions;

        public Board()
        {
            this.Rows = 10;
            this.Columns = 10;
            this.Battleships = new List<Battleship>();
            this.OccupiedCells = new List<Point>();
            this.BattleshipPositions = new Dictionary<Battleship, List<Point>>();
        }

        public void AddBattleship(Battleship battleship,
                                  BattleshipOrientation orientation,
                                  System.Drawing.Point startPosition)
        {
            if (battleship == null || startPosition == null)
            {
                throw new ValidationException("Battleship and start position is required");
            }

            List<Point> pointsOccupiedByShip = new List<Point>();
            for (int index = 0; index < battleship.Size; index++)
            {
                var nextPosition = new Point();
                if (orientation == BattleshipOrientation.Horizontal)
                {
                    nextPosition.X = startPosition.X;
                    nextPosition.Y = startPosition.Y + index;
                }
                else
                {
                    nextPosition.X = startPosition.X + index;
                    nextPosition.Y = startPosition.Y;
                }

                if (OccupiedCells.Contains(nextPosition) == true)
                {
                    throw new ValidationException("Battleship cannot be placed here as position is already occupied");
                }

                pointsOccupiedByShip.Add(nextPosition);
            }

            this.OccupiedCells.AddRange(pointsOccupiedByShip);
            this.BattleshipPositions.Add(battleship, pointsOccupiedByShip);
        }

        public bool TakeAttack(System.Drawing.Point position)
        {
            throw new NotImplementedException();
        }
    }
}
