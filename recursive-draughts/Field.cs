﻿using System;
using System.Collections.Generic;
using System.Text;

namespace recursive_draughts
{
    public class Field
    {
        private int x;
        private int y;

        public Field()
        {

        }
        public int X
        {
            get { return x; }
            set
            {
                if (value >= 0 && value <= 9)
                {
                    x = value;
                }
                else throw new Exception();
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value >= 0 && value <= 9)
                {
                    y = value;
                }
                else throw new Exception();
            }
        }
    }
}