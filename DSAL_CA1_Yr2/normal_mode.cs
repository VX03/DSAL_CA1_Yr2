﻿using DSAL_CA1_Yr2.Classes;
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
        List <SeatDoubleLinkedList> seatListArray = new List<SeatDoubleLinkedList>{ new SeatDoubleLinkedList { Counter = 0, PersonChosen = false},
                                             new SeatDoubleLinkedList { Counter = 0, PersonChosen = false },
                                             new SeatDoubleLinkedList { Counter = 0, PersonChosen = false},
                                             new SeatDoubleLinkedList { Counter = 0, PersonChosen = false},
                                             new SeatDoubleLinkedList()
                                            };


        PanelLabels panelLabels = new PanelLabels();

        string[] bookingPersonArray = { "A", "B", "C", "D" };
        bool bookSeats = false;
        public normal_mode()
        {
            InitializeComponent();
        }

        private void normal_mode_Load(object sender, EventArgs e)
        {

            
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
                    for(int i = 0; i < seatListArray.Count-1; i++)
                    {
                        if(i == 0)
                        {
                            seatListArray[i].PersonChosen = true;
                        }
                        else
                        {
                            seatListArray[i].PersonChosen = false;
                        }
                    }
                }
                else if (button.Text == "Person B Booking")
                {
                    for (int i = 0; i < seatListArray.Count-1 ; i++)
                    {
                        if (i == 1)
                        {
                            seatListArray[i].PersonChosen = true;
                        }
                        else
                        {
                            seatListArray[i].PersonChosen = false;
                        }
                    }
                }
                else if (button.Text == "Person C Booking")
                {
                    for (int i = 0; i < seatListArray.Count-1; i++)
                    {
                        if (i == 2)
                        {
                            seatListArray[i].PersonChosen = true;
                        }
                        else
                        {
                            seatListArray[i].PersonChosen = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < seatListArray.Count-1; i++)
                    {
                        if (i == 3)
                        {
                            seatListArray[i].PersonChosen = true;
                        }
                        else
                        {
                            seatListArray[i].PersonChosen = false;
                        }
                    }
                }

                disableRowAndColUponButton();
                tbMaxSeat.Enabled = true;

                trueFalseEditor(false);
                bookSeats = true;

                changeLabelColorAndCanBook();
                Color[] colorArray = getColorArray();

                for (int i = 0; i < bookingPersonArray.Length; i++)
                {
                    if (seatListArray[i].PersonChosen == true)
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
            Color[] colorArray = getColorArray();
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

                    for (int i = 0; i < seatListArray.Count-1; i++)
                    {

                        if (seatListArray[i].PersonChosen == true)
                        {
                            color = colorArray[i];//set color
                            if(maxSeat < seatListArray[i].Counter)
                            {
                                MessageBox.Show("Re-Enter max seats again");
                                return;
                            }
                            //chose seat
                            if (label.BackColor == Color.White)
                            {
                                //limit the number of seats
                                if (seatListArray[i].Counter < maxSeat)
                                {
                                //if left or right seat is null
                                if (leftSeat == null || rightSeat == null)
                                {
                                    //there is a different person seating at the side
                                    if (!((leftSeat != null && leftSeat.BookingPerson == bookingPersonArray[i]) || (rightSeat != null && rightSeat.BookingPerson == bookingPersonArray[i]) || seatListArray[i].Counter == 0))
                                    {
                                        MessageBox.Show("Unable to book seat!!!");
                                        return;
                                    }
                                    //none chosen
                                    else if (seatListArray[i].Counter == 0 && ((leftSeat != null && leftSeat.BookingPerson == null) || (rightSeat != null && rightSeat.BookingPerson == null)))
                                    {
                                        seatListArray[i].Counter = seatListArray[i].Counter+1;
                                        seat.BookStatus = true;
                                        seat.BookingPerson = bookingPersonArray[i];
                                        seatListArray[i].InsertAtEnd(seat);
                                        label.BackColor = color;
                                        return;
                                    }

                                    //left or right seat
                                    else if ((leftSeat != null && leftSeat.BookingPerson == bookingPersonArray[i]) || (rightSeat != null && rightSeat.BookingPerson == bookingPersonArray[i]))
                                    {
                                        seatListArray[i].Counter = seatListArray[i].Counter+1;
                                        seat.BookStatus = true;
                                        seat.BookingPerson = bookingPersonArray[i];
                                        seatListArray[i].InsertAtEnd(seat);
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
                                else if (seatListArray[i].Counter == 0 && leftSeat.BookingPerson == null && rightSeat.BookingPerson == null)
                                {
                                    seatListArray[i].Counter = seatListArray[i].Counter+1;
                                    seat.BookStatus = true;
                                    seat.BookingPerson = bookingPersonArray[i];
                                    seatListArray[i].InsertAtEnd(seat);
                                    label.BackColor = color;
                                    return;
                                }//end else if
                                 
                                //left or right seats are not null
                                else if (leftSeat.BookingPerson == bookingPersonArray[i] && rightSeat.BookingPerson == null || rightSeat.BookingPerson == bookingPersonArray[i] && leftSeat.BookingPerson == null)
                                {
                                    seatListArray[i].Counter = seatListArray[i].Counter+1;
                                    seat.BookStatus = true;
                                    seat.BookingPerson = bookingPersonArray[i];
                                    seatListArray[i].InsertAtEnd(seat);
                                    label.BackColor = color;
                                    return;
                                }//end else if

                                     //there is a different person seating at the side
                                else if (!(leftSeat.BookingPerson == bookingPersonArray[i] && rightSeat.BookingPerson == bookingPersonArray[i]))
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
                                seatListArray[i].Counter = seatListArray[i].Counter-1;
                                seat.BookStatus = false;
                                seat.BookingPerson = null;
                                seatListArray[i].DeleteSeat(seat);
                                label.BackColor = Color.White;
                                return;
                            }
                            else if (!(rightSeat.BookStatus && leftSeat.BookStatus))
                            {
                                seatListArray[i].Counter = seatListArray[i].Counter-1;
                                seat.BookStatus = false;
                                seat.BookingPerson = null;
                                seatListArray[i].DeleteSeat(seat);
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
            List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();
            foreach (SeatDoubleLinkedList seatDoubleLinkedListItem in seatListArray)
            {
                foreach(Label label in labels)
                {
                    SeatInfo seatInfo = (SeatInfo)label.Tag;
                    Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row,seatInfo.Column);
                    seatDoubleLinkedListItem.DeleteSeat(seat);
                    seat.CanBook = true;
                    seat.BookStatus = false;
                    seat.BookingPerson = null;
                }
            }
            for(int i = 0; i < seatListArray.Count-1; i++)
            {
                seatListArray[i].Counter = 0;
            }
            panelSeats.Controls.Clear();
            generate();

            bookSeats = false;
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
            Color[] colorArray = getColorArray();
            bool getColor = false;
            List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();
            foreach (Label label in labels)
            {
                SeatInfo si = (SeatInfo)label.Tag;
                Seat seat = seatList.SearchByRowAndColumn(si.Row, si.Column);
                foreach (Color color in colorArray)
                {
                    if(color == label.BackColor)
                    {
                        getColor = true;
                        label.BackColor= Color.DarkGray;
                    }
                }
                if (label.BackColor == Color.LightBlue || label.BackColor == Color.White)
                {
                    seat.CanBook = true;
                    label.BackColor = Color.White;
                }
                else if (label.BackColor == Color.DarkBlue)
                {
                    seat.CanBook = false;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();
            foreach (Label label in labels)
            {
                SeatInfo si = (SeatInfo)label.Tag;
                Seat seat = seatList.SearchByRowAndColumn(si.Row, si.Column);
                if(seat.CanBook == false)
                {
                    seatListArray[4].InsertAtEnd(seat);
                }
            }

            seatList.binarySaveToFile(seatListArray);
            MessageBox.Show("Saved to file");

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

            List<Label> labels = panelSeats.Controls.OfType <Label>().ToList();
            for (int i = 0; i < seatListArray.Count-1; i++)
            {
                if(seatListArray[i].PersonChosen == true)
                {
                    foreach(Label label in labels)
                    {
                        SeatInfo si = (SeatInfo)label.Tag;
                        Seat seat = seatList.SearchByRowAndColumn(si.Row, si.Column);
                        Seat searchSeat = seatListArray[i].SearchLastSeat();
                        if(searchSeat == seat)
                        {
                            seatListArray[i].DeleteSeat(seat);
                            seat.BookStatus = false;
                            seat.BookingPerson = null;
                            label.BackColor = Color.White;
                            seatListArray[i].Counter = seatListArray[i].Counter - 1;
                            return;
                        }
                    }
                    MessageBox.Show("Unable to undo ");
                }
            }
        }
    }//end of normal_mode
}
