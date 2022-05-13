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



        public int[] convertStringToInt(string split, TextBox s)
        {
            string[] stringArray = s.Text.Split(split);
            int[] intArray = Array.ConvertAll(stringArray, s => int.Parse(s));
            return intArray;
        }


    }
}
