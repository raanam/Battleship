using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Battleship.Commons;

namespace Battleship.Models
{
    public class Board
    {
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        private List<Battleship> battleships;
        public IEnumerable<Battleship> Battleships
        {
            get
            {
                return battleships.AsEnumerable();
            }
        }

        // Co-ordinates from 0,0 to 9,9 for 10 x 10 Grid.
        private List<Point> OccupiedCells;

        private Dictionary<Battleship, List<Point>> BattleshipPositions;

        public Board()
        {
            this.Rows = 10;
            this.Columns = 10;
            this.battleships = new List<Battleship>();
            this.OccupiedCells = new List<Point>();
            this.BattleshipPositions = new Dictionary<Battleship, List<Point>>();
        }

        public List<Point> GetBattleshipPositions(Battleship battleship)
        {
            return this.BattleshipPositions.ContainsKey(battleship) ?
                    this.BattleshipPositions[battleship] : null;
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
                    nextPosition.X = startPosition.X + index;
                    nextPosition.Y = startPosition.Y;
                }
                else
                {
                    nextPosition.X = startPosition.X;
                    nextPosition.Y = startPosition.Y + index;
                }

                if (OccupiedCells.Contains(nextPosition) == true)
                {
                    throw new PositionConflictException("Battleship cannot be placed here as position is already occupied");
                }

                pointsOccupiedByShip.Add(nextPosition);
            }

            this.battleships.Add(battleship);
            this.OccupiedCells.AddRange(pointsOccupiedByShip);
            this.BattleshipPositions.Add(battleship, pointsOccupiedByShip);
        }

        public bool TakeAttack(System.Drawing.Point position)
        {
            // Find battleship at position.
            var battleshipAtPosition = this.
                                       BattleshipPositions.
                                       Where(eachMap => eachMap.Value.Contains(position)).
                                       Select(eachMap => eachMap.Key).
                                       FirstOrDefault();

            if (battleshipAtPosition == null)
            {
                return false;
            }

            var hitPosition = this.BattleshipPositions[battleshipAtPosition].IndexOf(position);
            battleshipAtPosition.AcceptHit(hitPosition);
            return true;
        }

        public bool Won()
        {
            return !this.Battleships.Where(eachShip => eachShip.IsSunk == false).Any();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int x = 0, y = 0; y < this.Rows; x++)
            {
                if (this.OccupiedCells.Contains(new Point(x, y)) == true)
                {
                    sb.Append($" X ");
                }
                else
                {
                    sb.Append(" O ");
                }

                if (x == 9)
                {
                    y++;
                    x = -1;
                    sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }
    }
}
