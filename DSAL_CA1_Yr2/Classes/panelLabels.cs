using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSAL_CA1_Yr2.Classes
{
    public class PanelLabels
    {
        int counter = 0;
        bool personChosen = false;
        Color color;

        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }

        public bool PersonChosen
        {
            get { return personChosen; }
            set { personChosen = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }


        public int[] convertStringToInt(string split, TextBox s)
        {
            string[] stringArray = s.Text.Split(split);
            int[] intArray = Array.ConvertAll(stringArray, s => int.Parse(s));
            return intArray;
        }


    }
}
