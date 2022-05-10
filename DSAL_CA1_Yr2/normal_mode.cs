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
        PanelLabels panelLabels = new PanelLabels();
        int[] counterArray = { 0, 0, 0, 0 };
        bool personA = false;
        bool personB = false;
        bool personC = false;
        bool personD = false;

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
            */
        }//end of normal_mode_load



        private void btnGenerate_Click(object sender, EventArgs e)
        {    
            try
            {
                int rowSpace = 0;
                int prevRowSpace = 0;
                int colSpace = 0;
                int prevColSpace = 0;

                int row = int.Parse(tbNoOfRow.Text);
                int seatsPerRow = int.Parse(tbSeatsPerRow.Text);
                int[] rowDivider = panelLabels.convertStringToInt(",", tbRowDivider);
                int[] colDivider = panelLabels.convertStringToInt(",", tbColumnDivider);


                for(int i = 1;i <= row; i++)
                {
                    for (int j = 1;j <= seatsPerRow; j++)
                    {
                        for(int n = 0; n < rowDivider.Length; n++)//check for row divider
                        {
                            if(rowDivider[n] == i)//row divider
                            {
                                rowSpace = (150 + prevRowSpace);
                                break;
                            }
                            else// no divider
                            {
                                rowSpace = (70 + prevRowSpace);
                            }
                        }//End for loop
                        
                        for(int k = 0; k < colDivider.Length; k++)//col divider
                        {
                            if(colDivider[k] == j)
                            {
                                colSpace = (150 + prevColSpace);
                                break;
                            }
                            else
                            {
                                colSpace = (70 + prevColSpace);
                            }
                            
                        }//end for loop

                        GenerateSeat(i, j, rowSpace, colSpace,this.panelSeats);
                        prevColSpace = colSpace;

                    }//end for loop
                    
                    prevRowSpace = rowSpace;//add row space
                    prevColSpace = 0;//add col space
                }//end for loop

            }
            catch(FormatException ex)
            {
                labelMessage.Text = ex.Message.ToString();
            }
            catch(Exception ex) { labelMessage.Text = ex.ToString(); }
        }//end of btnGenerate_Click

        private void person_Click(object sender, EventArgs e)
        {
            try
            {
                int maxSeat = int.Parse(tbMaxSeat.Text);
                Button button = (Button)sender;

                Boolean[] personArray = { personA, personB, personC, personD };

                if (button.Text == "Person A Booking")
                {
                    personA = true;
                    personB = false;
                    personC = false;
                    personD = false;
                }
                else if (button.Text == "Person B Booking")
                {
                    personA = false;
                    personB = true;
                    personC = false;
                    personD = false;
                }
                else if (button.Text == "Person C Booking")
                {
                    personA = false;
                    personB = false;
                    personC = true;
                    personD = false;
                }
                else
                {
                    personA = false;
                    personB = false;
                    personC = false;
                    personD = true;
                }

                disableUponButton();
                panelLabels.changeLabelColor(panelSeats);
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Please input max seats!!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

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

        public void labelSeat_Click(object sender, EventArgs e)
        {
            Color color = Color.White;//set color to white
            Label label = (Label)sender;//label that is clicked
            SeatInfo seatInfo = (SeatInfo)label.Tag;//tag label
            //MessageBox.Show(String.Format("Row{0} Column{1}",seatInfo.Row,seatInfo.Column));

            //get person and color Array
            Boolean[] personArray = getPersonArray();
            Color[] colorArray = getColorArray();

            Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            Seat rightSeat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
            Seat leftSeat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);

            int maxSeat = int.Parse(tbMaxSeat.Text);

                for (int i = 0; i < personArray.Length; i++)
                {
                    if (personArray[i] == true)
                    {
                            color = colorArray[i];//set color

                            //chose seat
                            if (label.BackColor == Color.White)
                            {
                                if (counterArray[i] < maxSeat)
                                {
                                    //if left or right seat is null
                                    if (leftSeat == null || rightSeat == null)
                                    {
                                        //none chosen
                                        if (counterArray[i] == 0)
                                        {
                                            counterArray[i]++;
                                            seat.BookStatus = true;
                                            label.BackColor = color;
                                    
                                        }
                                        //left or right seat bookstatus = true
                                        else if ((leftSeat != null && leftSeat.BookStatus == true) || (rightSeat != null && rightSeat.BookStatus == true))
                                        {
                                            counterArray[i]++;
                                            seat.BookStatus = true;
                                            label.BackColor = color;
                                    
                                        }//end else if 
                                    }
                                    //left or right seats are not null
                                    else if (leftSeat.BookStatus || rightSeat.BookStatus || counterArray[i] == 0)
                                    {
                                        counterArray[i]++;
                                        seat.BookStatus = true;
                                        label.BackColor = color;
                                    
                                    }//end else if
                                }//end if
                            else
                            {
                                MessageBox.Show("Unable to add more seats!!!");
                            }
                            }//end if
                             //delete seat
                            else if (label.BackColor == colorArray[i])
                            {
                                //left or right seat is null
                                if (leftSeat == null || rightSeat == null)
                                {
                                    counterArray[i]--;
                                    seat.BookStatus = false;
                                    label.BackColor = Color.White;

                                }
                                else if (!(rightSeat.BookStatus && leftSeat.BookStatus))
                                {
                                    counterArray[i]--;
                                    seat.BookStatus = false;
                                    label.BackColor = Color.White;

                                }//end else if

                            }//end else if
                        
                        
                    }//end if
                    
                }//end of forloop

        }//end of labelSeat_Click
        public Boolean[] getPersonArray()
        {
            Boolean[] personArray = { personA, personB, personC, personD };
            return personArray;
        }

        public Color[] getColorArray()
        {
            Color[] colorArray = { btnA.BackColor, btnB.BackColor, btnC.BackColor, btnD.BackColor};
            return colorArray;
        }

        public void disableUponButton()
        {
            tbNoOfRow.Enabled = false;
            tbSeatsPerRow.Enabled = false;
            tbRowDivider.Enabled = false;
            tbColumnDivider.Enabled = false;
            tbMaxSeat.Enabled = false;

            btnGenerate.Enabled = false;
            
        }
    }//end of normal_mode
}
