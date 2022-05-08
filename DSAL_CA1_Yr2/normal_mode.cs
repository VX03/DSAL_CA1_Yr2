using DSAL_CA1_Yr2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAL_CA1_Yr2
{
    public partial class normal_mode : Form
    {
        SeatDoubleLinkedList seatList = new SeatDoubleLinkedList();
        public normal_mode()
        {
            InitializeComponent();
        }

        private void normal_mode_Load(object sender, EventArgs e)
        {
            /*
            Seat s = new Seat();
            s.Row = 1;
            s.Column = 1;
            seatList.InsertAtEnd(s);
            
            s = new Seat();
            s.Row = 1;
            s.Column = 2;
            seatList.InsertAtEnd(s);

            s = new Seat();
            s.Row = 1;
            s.Column = 3;
            seatList.InsertAtEnd(s);

            labelMessage.Text = "DoubleLinkedList has been built";

            Label labelSeat = new Label();
            labelSeat.Text = "A1";
            labelSeat.Location = new Point(50, 50);
            labelSeat.Size = new Size(60, 60);
            labelSeat.TextAlign = ContentAlignment.MiddleCenter;
            labelSeat.BorderStyle = BorderStyle.FixedSingle;
            labelSeat.BackColor = Color.LightBlue;
            labelSeat.Font = new Font("Calibri",14,FontStyle.Bold);
            labelSeat.ForeColor = Color.Black;

            labelSeat.Tag = new SeatInfo() {Row = 1, Column = 1 };
            this.panelSeats.Controls.Add(labelSeat);
            */
        }//end of normal_mode_load



        private void btnGenerate_Click(object sender, EventArgs e)
        {
            /*
            Seat s = new Seat();
            s.Row = 1;
            s.Column = 1;
            seatList.InsertAtEnd(s);
            Label labelSeat = new Label();
            labelSeat.Text = s.ComputeSeatLabel();
            labelSeat.Location = new Point(((60*s.Column)+(50*(s.Column-1))), 50);
            labelSeat.Size = new Size(60, 60);
            labelSeat.TextAlign = ContentAlignment.MiddleCenter;
            labelSeat.BorderStyle = BorderStyle.FixedSingle;
            labelSeat.BackColor = Color.LightBlue;
            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
            labelSeat.ForeColor = Color.Black;
            labelSeat.Tag = new SeatInfo() { Row = s.Row, Column = s.Column };
            labelSeat.Click += new EventHandler(labelSeat_Click);
            this.panelSeats.Controls.Add(labelSeat);

            s = new Seat();
            s.Row = 1;
            s.Column = 2;
            seatList.InsertAtEnd(s);
            labelSeat = new Label();
            labelSeat.Text = s.ComputeSeatLabel();
            labelSeat.Location = new Point(((60 * s.Column) + (50 * (s.Column - 1))), 50);
            labelSeat.Size = new Size(60, 60);
            labelSeat.TextAlign = ContentAlignment.MiddleCenter;
            labelSeat.BorderStyle = BorderStyle.FixedSingle;
            labelSeat.BackColor = Color.LightBlue;
            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
            labelSeat.ForeColor = Color.Black;
            labelSeat.Tag = new SeatInfo() { Row = s.Row, Column = s.Column };
            labelSeat.Click += new EventHandler(labelSeat_Click);
            this.panelSeats.Controls.Add(labelSeat);

            s = new Seat();
            s.Row = 1;
            s.Column = 3;
            seatList.InsertAtEnd(s);
            labelSeat = new Label();
            labelSeat.Text = s.ComputeSeatLabel();
            labelSeat.Location = new Point(((60 * s.Column) + (50 * (s.Column - 1))), 50);
            labelSeat.Size = new Size(60, 60);
            labelSeat.TextAlign = ContentAlignment.MiddleCenter;
            labelSeat.BorderStyle = BorderStyle.FixedSingle;
            labelSeat.BackColor = Color.LightBlue;
            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
            labelSeat.ForeColor = Color.Black;
            labelSeat.Tag = new SeatInfo() { Row = s.Row, Column = s.Column };
            labelSeat.Click += new EventHandler(labelSeat_Click);
            this.panelSeats.Controls.Add(labelSeat);
            */
            
            try
            {
                int space = 0;
                int prevSpace = 0;
                int row = int.Parse(tbNoOfRow.Text);
                int seatsPerRow = int.Parse(tbSeatsPerRow.Text);
                int[] rowDivider = convertStringToInt(",", tbRowDivider);
                //int[] colDivider = convertStringToInt(",", tbColumnDivider);


                for(int i = 1;i <= row; i++)
                {
                    for(int j = 1;j <= seatsPerRow; j++)
                    {
                        for(int n = 0; n < rowDivider.Length; n++)//check for row divider
                        {
                            if(rowDivider[n] == i)//row divider
                            {
                                space = (150 + prevSpace);
                                break;
                            }
                            else// no divider
                            {
                                space = (70 + prevSpace);
                            }
                        }//End for loop
                        
                        GenerateSeat(i, j, space);

                    }//end for loop
                     prevSpace = space;
                }//end for loop
            }
            catch(FormatException ex)
            {
                labelMessage.Text = ex.Message.ToString();
            }
            catch(Exception ex) { labelMessage.Text = ex.ToString(); }
        }//end of btnGenerate_Click

        private void GenerateSeat(int i, int j, int rowSpace)
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
           labelSeat.Location = new Point(((60 * s.Column) + (10 * (s.Column - 1))), rowSpace);
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
           this.panelSeats.Controls.Add(labelSeat);
        }//End of generate seat
        private int[] convertStringToInt(string split,TextBox s)
        {
            string[] stringArray = s.Text.Split(split);
            int[] intArray = Array.ConvertAll(stringArray, s => int.Parse(s));
            return intArray;
        }
        private void labelSeat_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            SeatInfo seatInfo = (SeatInfo)label.Tag;
            //MessageBox.Show(String.Format("Row{0} Column{1}",seatInfo.Row,seatInfo.Column));
            Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);

            if(seat.BookStatus == false)
            {
                seat.BookStatus = true;
                label.BackColor = Color.LightGreen;
            }
            else
            {
                seat.BookStatus = false;
                label.BackColor = Color.LightBlue; 
            }


        }//end of labelSeat_Click

        class SeatInfo
        {
            public int Row { get; set; }
            public int Column { get; set; }
        }//end of seatInfo

    }//end of normal_mode
}
