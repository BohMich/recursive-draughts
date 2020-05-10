using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Automation;

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

        public List<IPawn> GetPawns()
        {
            List<IPawn> pawns = new List<IPawn>();

            foreach(IField field in _fields)
            {
                if(field.Pawn != null)
                {
                    pawns.Add(field.Pawn);
                }
            }
            return pawns;
        }
        public void AddPawn(int x, int y, IPawn pawn)
        {
            _fields[x, y].Pawn = pawn;
        }
        public void AddAllPawns(List<IPawn> white, List<IPawn> black)
        {
            var pawnCount = 0;
            var emptyField = true; //position 0x0 is empty
            //build the black team (4 rows 5 each)
            for(int y = 0; y < 4; y++)
            {
                for(int x = 0; x < 10; x++)
                {
                    if(emptyField == false)
                    {
                        //place pawn
                        AddPawn(x, y, black.Find(m => m.Id == pawnCount));

                        //set next id.
                        pawnCount++;

                        emptyField = true;
                    }
                    else
                    {
                        emptyField = false; //switch next iteration will place the pawn.
                    }
                }
            }

            //set white pawns
            pawnCount = 0;
            emptyField = true; //position 0x0 is empty
            //build the black team (4 rows 5 each)
            for (int y = 6; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (emptyField == false)
                    {
                        //place pawn
                        AddPawn(x, y, white.Find(m => m.Id == pawnCount));

                        //set next id.
                        pawnCount++;

                        if (x != 9)  //prevent parallel stacking of pawns
                        {
                            emptyField = true;
                        }
                    }
                    else
                    {
                        emptyField = false; //switch next iteration will place the pawn.
                    }
                }
            }
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
