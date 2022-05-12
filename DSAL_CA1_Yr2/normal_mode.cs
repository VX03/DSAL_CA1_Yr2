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
        SeatDoubleLinkedList seatListA = new SeatDoubleLinkedList();
        SeatDoubleLinkedList seatListB = new SeatDoubleLinkedList();
        SeatDoubleLinkedList seatListC = new SeatDoubleLinkedList();
        SeatDoubleLinkedList seatListD = new SeatDoubleLinkedList();

        
        PanelLabels panelLabels = new PanelLabels();
        int[] counterArray = { 0, 0, 0, 0 };
        string[] bookingPersonArray = { "A", "B", "C", "D" };
        bool personA = false;
        bool personB = false;
        bool personC = false;
        bool personD = false;
        bool bookSeats = false;
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
            generate();
        }//end of btnGenerate_Click

        private void person_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();

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

                disableRowAndColUponButton();
                tbMaxSeat.Enabled = true;

                trueFalseEditor(false);
                bookSeats = true;

                changeLabelColorAndCanBook();

                Boolean[] personArray = getPersonArray();
                Color[] colorArray = getColorArray();


                for (int i = 0; i < personArray.Length; i++)
                {
                    if (personArray[i] == true)
                    {
                        foreach (Label label in labels)
                        {
                            SeatInfo si = (SeatInfo)label.Tag;
                            Seat seat = seatList.SearchByRowAndColumn(si.Row, si.Column);
                            if (seat.BookingPerson == bookingPersonArray[i])
                            {
                                label.BackColor = colorArray[i];
                            }
                            labelMessage.Text = "Person " + bookingPersonArray[i] + " is booking now.";
                        }
                    }//end forloop

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }//end of person_Click

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
            //get person and color Array
            Boolean[] personArray = getPersonArray();
            Color[] colorArray = getColorArray();
            SeatDoubleLinkedList[] doubleLinkedListArray = {seatListA,seatListB,seatListC,seatListD};

            Color color = Color.White;//set color to white
            Label label = (Label)sender;//label that is clicked
            SeatInfo seatInfo = (SeatInfo)label.Tag;//tag label

            Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            Seat rightSeat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
            Seat leftSeat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);

            if (rbDisable.Enabled == true && rbDisable.Checked == true)
            {
                seat.CanBook = false;
                label.BackColor = Color.DarkBlue;
                return;
            }
            else if (rbEnable.Enabled == true && rbEnable.Checked == true)
            {
                seat.CanBook = true;
                label.BackColor = Color.White;
                return;
            }

            if (bookSeats == false)
            {
                MessageBox.Show("Click on person button");
                return;
            }
            try
            {
                int maxSeat = int.Parse(tbMaxSeat.Text);

                    tbMaxSeat.Enabled = false;

                    for (int i = 0; i < personArray.Length; i++)
                    {

                        if (personArray[i] == true)
                        {
                            color = colorArray[i];//set color
                            if(maxSeat < counterArray[i])
                            {
                                MessageBox.Show("Re-Enter max seats again");
                                return;
                            }
                            //chose seat
                            if (label.BackColor == Color.White)
                            {
                                //limit the number of seats
                                if (counterArray[i] < maxSeat)
                                {
                                //if left or right seat is null
                                if (leftSeat == null || rightSeat == null)
                                {
                                    //there is a different person seating at the side
                                    if (!((leftSeat != null && leftSeat.BookingPerson == bookingPersonArray[i]) || (rightSeat != null && rightSeat.BookingPerson == bookingPersonArray[i]) || counterArray[i] == 0))
                                    {
                                        MessageBox.Show("Unable to book seat!!!");
                                        return;
                                    }
                                    //none chosen
                                    else if (counterArray[i] == 0 && ((leftSeat != null && leftSeat.BookingPerson == null) || (rightSeat != null && rightSeat.BookingPerson == null)))
                                    {
                                        counterArray[i]++;
                                        seat.BookStatus = true;
                                        seat.BookingPerson = bookingPersonArray[i];
                                        doubleLinkedListArray[i].InsertAtEnd(seat);
                                        label.BackColor = color;
                                        return;
                                    }

                                    //left or right seat
                                    else if ((leftSeat != null && leftSeat.BookingPerson == bookingPersonArray[i]) || (rightSeat != null && rightSeat.BookingPerson == bookingPersonArray[i]))
                                    {
                                        counterArray[i]++;
                                        seat.BookStatus = true;
                                        seat.BookingPerson = bookingPersonArray[i];
                                        doubleLinkedListArray[i].InsertAtEnd(seat);
                                        label.BackColor = color;
                                        return;
                                    }//end else if 
                                    else if (!(leftSeat != null && leftSeat.BookingPerson == bookingPersonArray[i]) || (rightSeat != null && rightSeat.BookingPerson == bookingPersonArray[i]))
                                    {
                                        MessageBox.Show("Unable to choose seat");
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("You may only book adjacent seats!!!");
                                        return;
                                    }
                                }//end of if for null seats

                                //for non-null seats
                                else if (counterArray[i] == 0 && leftSeat.BookingPerson == null && rightSeat.BookingPerson == null)
                                {
                                    counterArray[i]++;
                                    seat.BookStatus = true;
                                    seat.BookingPerson = bookingPersonArray[i];
                                    doubleLinkedListArray[i].InsertAtEnd(seat);
                                    label.BackColor = color;
                                    return;
                                }//end else if
                                 
                                //left or right seats are not null
                                else if (leftSeat.BookingPerson == bookingPersonArray[i] && rightSeat.BookingPerson == null || rightSeat.BookingPerson == bookingPersonArray[i] && leftSeat.BookingPerson == null)
                                {
                                    counterArray[i]++;
                                    seat.BookStatus = true;
                                    seat.BookingPerson = bookingPersonArray[i];
                                    doubleLinkedListArray[i].InsertAtEnd(seat);
                                    label.BackColor = color;
                                    return;
                                 }//end else if

                                     //there is a different person seating at the side
                                else if (!(leftSeat.BookingPerson == bookingPersonArray[i] || rightSeat.BookingPerson == bookingPersonArray[i]))
                                {
                                    MessageBox.Show("Unable to book seat");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("You may only book adjacent seats!!!");
                                    return;
                                }
                            } //end if
                            else
                            {
                                MessageBox.Show("Unable to add more seats!!!");
                                return;
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
                                seat.BookingPerson = null;
                                doubleLinkedListArray[i].DeleteSeat(seat);
                                label.BackColor = Color.White;
                                return;
                            }
                            else if (!(rightSeat.BookStatus && leftSeat.BookStatus))
                            {
                                counterArray[i]--;
                                seat.BookStatus = false;
                                seat.BookingPerson = null;
                                doubleLinkedListArray[i].DeleteSeat(seat);
                                label.BackColor = Color.White;
                                return;

                            }//end else if

                        }//end else if
                        else
                        {
                            MessageBox.Show("Unable to Choose seat");
                        }

                        }//end if

                    }//end of forloop

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please input max seats!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }//end of labelSeat_Click

        public void generate()
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
        public Boolean[] getPersonArray()
        {
            Boolean[] personArray = { personA, personB, personC, personD };
            return personArray;
        }//end of getPersonArray

        public Color[] getColorArray()
        {
            Color[] colorArray = { btnA.BackColor, btnB.BackColor, btnC.BackColor, btnD.BackColor};
            return colorArray;
        }//end of getColorArray

        public void disableRowAndColUponButton()
        {
            tbNoOfRow.Enabled = false;
            tbSeatsPerRow.Enabled = false;
            tbRowDivider.Enabled = false;
            tbColumnDivider.Enabled = false;
            tbMaxSeat.Enabled = false;

            btnGenerate.Enabled = false;
            
        }//end of disableRowAndColUponButton

        private void btnResetSimulation_Click(object sender, EventArgs e)
        {
            panelSeats.Controls.Clear();
            generate();

            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            trueFalseEditor(false);
            btnEditorMode.Enabled = true;
            btnEditorMode.Text = "Enter Editor Mode";
            labelMessage.Text = "Simulation has resetted";
        }//end of btnResetSimulation_Click

        private void btnEditorMode_Click(object sender, EventArgs e)
        {
            if (btnEditorMode.Text == "Enter Editor Mode")
            {
                trueFalseEditor(true);
                btnEditorMode.Text = "Exit Editor Mode";
            }
            else
            {
                trueFalseEditor(false);
                btnEditorMode.Enabled = true;
                btnEditorMode.Text = "Enter Editor Mode";
            }

        }//end of btnEditorMode_Click

        private void trueFalseEditor(Boolean input)
        {
            rbEnable.Enabled = input;
            rbDisable.Enabled = input;
            btnEnableAll.Enabled = input;
            btnDisableAll.Enabled = input;
            btnEditorMode.Enabled = input;
        }//end of trueFalseEditor

        private void btnEnableDisableAll_Click(object sender, EventArgs e)
        {
            bool enableDisable = false;
            Button button = (Button)sender;

            if(button.Text == "Enable All")
            {
                enableDisable = true;
            }

            List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();

            foreach (Label label in labels)
            {
                SeatInfo si = (SeatInfo)label.Tag;
                Seat seat = seatList.SearchByRowAndColumn(si.Row, si.Column);
                if (enableDisable)
                { 
                    seat.CanBook = true;
                    label.BackColor = Color.White;
                }
                else
                {
                    seat.CanBook = false;
                    label.BackColor = Color.DarkBlue;
                }
            }
        }//End of btnEnableDisableAll_Click

        public void changeLabelColorAndCanBook()
        {
            List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();
            foreach (Label label in labels)
            {
                SeatInfo si = (SeatInfo)label.Tag;
                Seat seat = seatList.SearchByRowAndColumn(si.Row, si.Column);

                if (label.BackColor == Color.LightBlue)
                {
                    seat.CanBook = true;
                    label.BackColor = Color.White;
                }
                else if (label.BackColor != Color.White)
                {
                    seat.CanBook = false;
                    if (label.BackColor != Color.DarkBlue)
                    {
                        label.BackColor = Color.DarkGray;
                    }
                }
            }
        }//end of changeLabelColorAndCanBook

        private void btnEndSimulation_Click(object sender, EventArgs e)
        {
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();

            foreach(Label label in labels)
            {
                if(label.BackColor != Color.White && label.BackColor != Color.DarkBlue)
                {
                    label.BackColor = Color.DarkGray;
                }
                label.Click -= new EventHandler(labelSeat_Click);
                label.Click += new EventHandler(endSimulationLabelEventHandler);
            }
            MessageBox.Show("Simulation has ended");
            labelMessage.Text = "Simulation ended";
        }//End of btnEndSimulation_Click

        private void endSimulationLabelEventHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Simulation has ended.");
        }//end of endSimulationLabelEventHandler

        
    }//end of normal_mode
}
