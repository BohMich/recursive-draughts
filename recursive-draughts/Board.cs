using System;
using System.Collections.Generic;
using System.Text;

namespace recursive_draughts
{
    public class Board : IBoard
    {
        private IField[,] _fields;

        public Board()
        {
            _fields = new Field[10, 10];
        }
        public void GenerateNewBoard()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    var field = new Field();
                    field.X = x;
                    field.Y = y;

                    _fields[x, y] = field;
                }
            }
        }
        public IField[,] Fields
        {
            get { return _fields; }
        }

        public bool IsLoaded()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (_fields[x, y] == null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
