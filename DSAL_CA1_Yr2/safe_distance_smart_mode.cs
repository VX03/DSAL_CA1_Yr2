using DSAL_CA1_Yr2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSAL_CA1_Yr2
{
    public partial class safe_distance_smart_mode : Form
    {
        private SeatDoubleLinkedList seatList = new SeatDoubleLinkedList();
        private List<SeatDoubleLinkedList> seatListArray = new List<SeatDoubleLinkedList>{ new SeatDoubleLinkedList { Counter = 0, PersonChosen = false},
                                             new SeatDoubleLinkedList { Counter = 0, PersonChosen = false},
                                             new SeatDoubleLinkedList { Counter = 0, PersonChosen = false},
                                             new SeatDoubleLinkedList { Counter = 0, PersonChosen = false},
                                             new SeatDoubleLinkedList()
                                            };

        string[] bookingPersonArray = { "A", "B", "C", "D" };
        bool bookSeats = false;
        public safe_distance_smart_mode()
        {
            InitializeComponent();
        }
        private void safe_distance_smart_mode_FormClosing(object sender, EventArgs e)
        {
            ((ParentForm)this.MdiParent).smartMode = null;
        }
        private void btnSeatLayout_Click(object sender, EventArgs e)
        {
            try
            {
                generate();
            }catch (Exception ex)
            {

            }
        }

        public void generate()
        {
            try
            {
                int rowSpace = 0;
                int prevRowSpace = 0;
                int colSpace = 0;
                int prevColSpace = 0;

                int row = int.Parse(numRow.Text);
                int seatsPerRow = int.Parse(numCol.Text);
                int[] rowDivider = { 5 };
                int[] colDivider = { 5 };


                for (int i = 1; i <= row; i++)
                {
                    for (int j = 1; j <= seatsPerRow; j++)
                    {
                        for (int n = 0; n < rowDivider.Length; n++)//check for row divider
                        {
                            if (rowDivider[n] + 1 == i)//row divider
                            {
                                rowSpace = (150 + prevRowSpace);
                                break;
                            }
                            else// no divider
                            {
                                rowSpace = (70 + prevRowSpace);
                            }
                        }//End for loop

                        for (int k = 0; k < colDivider.Length; k++)//col divider
                        {
                            if (colDivider[k] + 1 == j)
                            {
                                colSpace = (150 + prevColSpace);
                                break;
                            }
                            else
                            {
                                colSpace = (70 + prevColSpace);
                            }

                        }//end for loop

                        GenerateSeat(i, j, rowSpace, colSpace, this.panelSeats);
                        prevColSpace = colSpace;

                    }//end for loop

                    prevRowSpace = rowSpace;//add row space
                    prevColSpace = 0;//add col space
                }//end for loop

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }//end of generate
        public void GenerateSeat(int i, int j, int rowSpace, int colSpace, Panel panelSeats)
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
        public Color[] getColorArray()
        {
            Color[] colorArray = { btnA.BackColor, btnB.BackColor, btnC.BackColor, btnD.BackColor };
            return colorArray;
        }//end of getColorArray

        public void labelSeat_Click(object sender, EventArgs e) { }
        public void delSeatandLabel()
        {
            List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();
            foreach (SeatDoubleLinkedList seatDoubleLinkedListItem in seatListArray)
            {
                foreach (Label label in labels)
                {
                    SeatInfo seatInfo = (SeatInfo)label.Tag;
                    Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                    seatList.DeleteSeat(seat);
                }
            }

            foreach (Label seatLabel in labels)
            {
                panelSeats.Controls.Remove(seatLabel);
            }
        }//end of delSeatandLabel

        
    }
}
