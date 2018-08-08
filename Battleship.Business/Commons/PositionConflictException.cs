using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Commons
{
    public class PositionConflictException : ValidationException
    {
        public PositionConflictException(string message) : base(message)
        {
        }
    }
}
