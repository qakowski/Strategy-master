using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class TCell
    {
        private List<Tuple<int, int>> _offsets = new List<Tuple<int, int>>()
        {
            new Tuple<int, int>(-1, -1),
            new Tuple<int, int>(0, -1),
            new Tuple<int, int>(1, -1),
            new Tuple<int, int>(0, 1),
            new Tuple<int, int>(1, 1),
            new Tuple<int, int>(-1, 1),
            new Tuple<int, int>(-1, 0),
            new Tuple<int, int>(1, 0)
        };

        public TGame Game;
        public int X;
        public int Y;
        public TPiece Piece;
        public TCell Parent;
        public List<TCell> Neighbours
        {
            get
            {
                var neighbours = new List<TCell>();
                foreach(var value in _offsets)
                {
                    var x = X + value.Item1;
                    var y = Y + value.Item2;
                    if(x >= 0 && y >= 0 && x < Game.Map.Width && y < Game.Map.Height)
                    {
                        neighbours.Add(Game.Cells[y, x]);
                    }
                }
                return neighbours;
            }
        }
    }
}
