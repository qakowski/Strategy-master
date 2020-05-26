using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy
{
    public class THero : TPiece
    {
        public int MaxMoves;
        public int MovesCount;
        public string Name;
        public TPlayer Player;
        private TCell _currentCell;
        public TCell CurrentCell
        {
            get { return _currentCell; }
            set
            {
                if (_currentCell != null)
                    _currentCell.Piece = null;

                _currentCell = value;

                if (_currentCell != null)
                    _currentCell.Piece = this;
            }
        }
        public List<int> Artifacts = new List<int>();
        private TCell _stopCell;
        public List<TCell> Path = new List<TCell>();
        public TCell StopCell
        {
            get { return _stopCell; }
            set
            {
                FindPath(value);
                _stopCell = value;
            }
        }

        private void FindPath(TCell desiredCell)
        {
            var treePath = new List<TCell>();
            treePath.Add(CurrentCell);
            if (desiredCell == CurrentCell)
                return;

            for (var i = 0; i < treePath.Count; i++)
            {
                var cell = treePath[i];
                var neighbours = cell.Neighbours;

                if (cell == desiredCell)
                    break;
                foreach (var neighbour in neighbours)
                {
                    if (neighbour.Piece == null || neighbour == desiredCell)
                    {
                        neighbour.Parent = cell;
                        treePath.Add(neighbour);
                    }
                }
            }
            Path = new List<TCell>();
            var parentCell = desiredCell;
            while (parentCell != null)
            {
                Path.Add(parentCell);
                parentCell = parentCell.Parent;
            }

            Path.Reverse();

            foreach (var cell in treePath)
            {
                cell.Parent = null;
            }
        }
    }
}