using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSAL_CA1_Yr2.Classes
{
    class PanelLabels
    {
        SeatDoubleLinkedList seatList = new SeatDoubleLinkedList();

        public int[] convertStringToInt(string split, TextBox s)
        {
            string[] stringArray = s.Text.Split(split);
            int[] intArray = Array.ConvertAll(stringArray, s => int.Parse(s));
            return intArray;
        }
        public void changeLabelColor(Panel panelSeats)
        {
            List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();
            foreach (Label label in labels)
            {
                if (label.BackColor == Color.LightBlue)
                {
                    label.BackColor = Color.White;
                }
                if(label.BackColor != Color.White)
                {
                    label.BackColor = Color.DarkGray;
                }
            }
        }//end of changeLabelColor


    }
}
