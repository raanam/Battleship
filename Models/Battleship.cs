using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public class Battleship
    {
        public int Size { get; private set; }

        public List<int> HitPositions { get; private set; }

        public Battleship(int size)
        {
            if (size < 0)
            {
                throw new ValidationException("Size of battleship cannot be less than zero");
            }

            this.Size = size;
            this.HitPositions = new List<int>();
        }

        public bool IsSunk
        {
            get
            {
                return this.HitPositions.Count == this.Size;
            }
        }

        public void AcceptHit(int position)
        {
            if (position > this.Size || position < 0)
            {
                throw new ValidationException("Invalid hit position");
            }

            if (this.HitPositions.Contains(position) == false)
            {
                this.HitPositions.Add(position);
            }
        }
    }
}
