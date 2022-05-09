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

            }
        }//end of changeLabelColor

        public void GenerateSeat(int i, int j, int rowSpace, int colSpace,Panel panelSeats )
        {

            Seat s = new Seat();
            s.Row = i;
            s.Column = j;
            seatList.InsertAtEnd(s);
            Label labelSeat = new Label();
            //compute seat label
            labelSeat.Text = s.ComputeSeatLabel();
            // Location
            //row divider
            //((60 * s.Column) + (10 * (s.Column - 1)))
            labelSeat.Location = new Point(colSpace, rowSpace);
            //Size
            labelSeat.Size = new Size(60, 60);
            //TextAlignment
            labelSeat.TextAlign = ContentAlignment.MiddleCenter;
            //border style
            labelSeat.BorderStyle = BorderStyle.FixedSingle;
            //background color
            labelSeat.BackColor = Color.LightBlue;
            //font 
            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
            //font color
            labelSeat.ForeColor = Color.Black;
            //Tag
            labelSeat.Tag = new SeatInfo() { Row = s.Row, Column = s.Column };
            labelSeat.Click += new EventHandler(labelSeat_Click);
            panelSeats.Controls.Add(labelSeat);
        }//End of generate seat

        public void labelSeat_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            SeatInfo seatInfo = (SeatInfo)label.Tag;
            //MessageBox.Show(String.Format("Row{0} Column{1}",seatInfo.Row,seatInfo.Column));

            Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            Seat rightSeat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
            Seat leftSeat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);

            if (seat.BookStatus == false)
            {
                seat.BookStatus = true;
                label.BackColor = Color.LightGreen;
            }
            else
            {
                seat.BookStatus = false;
                label.BackColor = Color.White;
            }


        }//end of labelSeat_Click

    }
}
