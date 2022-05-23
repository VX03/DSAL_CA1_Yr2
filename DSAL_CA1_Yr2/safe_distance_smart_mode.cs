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

        private string[] bookingPersonArray = { "A", "B", "C", "D" };
        private bool bookSeats = false;
        private Boolean load = false;
        private int[] rowDivider =  { 3 };
        private int[] colDivider =  { 3,5 };
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
                btnEditorMode.Enabled = true;
            }catch (Exception ex)
            {

            }
        }
        public void btnEnableDisableAll_Click(object sender, EventArgs e)
        {
            bool enableDisable = false;
            Button button = (Button)sender;

            if (button.Text == "Enable All")
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
                    seat.BookStatus = false;
                    seat.BookingPerson = null;
                    label.BackColor = Color.DarkBlue;
                }
            }
        }//end 
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
        private void trueFalseEditor(Boolean input)
        {
            rbEnable.Enabled = input;
            rbDisable.Enabled = input;
            btnEnableAll.Enabled = input;
            btnDisableAll.Enabled = input;
            btnEditorMode.Enabled = input;
        }//end of trueFalseEditor
        public void labelSeat_Click(object sender, EventArgs e) 
        {
            List <Label> labels = panelSeats.Controls.OfType<Label>().ToList(); 
            Color[] colorArray = getColorArray();
            Color color = Color.White;//set color to white
            Label label = (Label)sender;//label that is clicked
            SeatInfo seatInfo = (SeatInfo)label.Tag;//tag label
            Boolean[] stateArray = new Boolean[4];

            Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            Seat rightSeat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
            Seat leftSeat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);

            Seat frontSeat = seatList.SearchByRowAndColumn(seatInfo.Row - 1, seatInfo.Column);
            Seat backSeat = seatList.SearchByRowAndColumn(seatInfo.Row + 1, seatInfo.Column);

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
                MessageBox.Show("Click on Person button");
                return;
            }

            if(label.BackColor == Color.LightSeaGreen)
            {
                MessageBox.Show("Unable to book seat beside another person");
                return;
            }

            try
            {
                

                for (int i = 0; i < seatListArray.Count - 1; i++)
                {

                    if (seatListArray[i].PersonChosen == true)
                    {
                        color = colorArray[i];//set color

                        //chose seat
                        if (label.BackColor == Color.White)
                        {

                                //if left or right seat is null
                                if (leftSeat == null || rightSeat == null || frontSeat == null || backSeat == null)
                                {
                                    //none chosen
                                    if (seatListArray[i].Counter == 0 &&
                                        ((leftSeat != null && leftSeat.BookingPerson == null) ||
                                        (rightSeat != null && rightSeat.BookingPerson == null) ||
                                        (frontSeat != null && frontSeat.BookingPerson == null) ||
                                        (backSeat != null && backSeat.BookingPerson == null)))
                                    {
                                        
                                        seatListArray[i].Counter = seatListArray[i].Counter + 1;
                                        seat.BookStatus = true;
                                        seat.BookingPerson = bookingPersonArray[i];
                                        seatListArray[i].InsertAtEnd(seat);
                                        label.BackColor = color;
                                        return;
                                    }

                                    //left or right or front or back seat 
                                    else if ((leftSeat != null && leftSeat.BookingPerson == bookingPersonArray[i]) ||
                                            (rightSeat != null && rightSeat.BookingPerson == bookingPersonArray[i]) ||
                                            (frontSeat != null && frontSeat.BookingPerson == bookingPersonArray[i]) ||
                                            (backSeat != null && backSeat.BookingPerson == bookingPersonArray[i]))
                                    {
                                    
                                    seatListArray[i].Counter = seatListArray[i].Counter + 1;
                                        seat.BookStatus = true;
                                        seat.BookingPerson = bookingPersonArray[i];
                                        seatListArray[i].InsertAtEnd(seat);
                                        label.BackColor = color;
                                        return;
                                    }//end else if 
                                    else
                                    {
                                        if (leftSeat == null && rightSeat.BookingPerson != null)
                                        {
                                            MessageBox.Show("You cannot book seat next to another person!!!");
                                        }
                                        else if (rightSeat == null && leftSeat.BookingPerson != null)
                                        {
                                            MessageBox.Show("You cannot book seat next to another person!!!");
                                        }
                                        else
                                            MessageBox.Show("You may only book adjacent seats!!!");
                                        return;
                                    }

                                }//end of if for null seats

                                //for non-null seats
                                else if (seatListArray[i].Counter == 0 )
                                {
                                    seatListArray[i].Counter = seatListArray[i].Counter + 1;
                                    seat.BookStatus = true;
                                    seat.BookingPerson = bookingPersonArray[i];
                                    seatListArray[i].InsertAtEnd(seat);
                                    label.BackColor = color;
                                    return;
                                }//end else if


                            else if ((leftSeat.BookingPerson == bookingPersonArray[i]) ||
                                     (rightSeat.BookingPerson == bookingPersonArray[i]) ||
                                     (frontSeat.BookingPerson == bookingPersonArray[i]) ||
                                     (backSeat.BookingPerson == bookingPersonArray[i]))
                            {
                                seatListArray[i].Counter = seatListArray[i].Counter + 1;
                                seat.BookStatus = true;
                                seat.BookingPerson = bookingPersonArray[i];
                                seatListArray[i].InsertAtEnd(seat);
                                label.BackColor = color;
                                return;
                            }
                                else
                                {
                                    MessageBox.Show("Unable to book Seat");
                                return;
                                }//end else if
                            } //end if

                        //delete seat
                        else if (label.BackColor == colorArray[i])
                        {
                            //if all seats around is null
                            if (leftSeat == null || rightSeat == null || frontSeat == null || backSeat == null)
                            {
                                if ((leftSeat == null && frontSeat == null) ||
                                    (leftSeat == null && backSeat == null) ||
                                    (rightSeat == null && backSeat == null) ||
                                    (rightSeat == null && frontSeat == null))
                                {
                                    if(leftSeat == null && frontSeat == null) { 
                                        if (rightSeat.BookStatus && backSeat.BookStatus)
                                        {
                                            MessageBox.Show("Unable to unbook");
                                            return;
                                        }
                                    }
                                    else if (leftSeat == null && backSeat == null)
                                    {
                                        if (rightSeat.BookStatus && frontSeat.BookStatus)
                                        {
                                            MessageBox.Show("Unable to unbook");
                                            return;
                                        }
                                    }
                                    else if (rightSeat == null && backSeat == null)
                                    {
                                        if (leftSeat.BookStatus && frontSeat.BookStatus)
                                        {
                                            MessageBox.Show("Unable to unbook");
                                            return;
                                        }
                                    }
                                    else if (rightSeat == null && frontSeat == null)
                                    {
                                        if (leftSeat.BookStatus && backSeat.BookStatus)
                                        {
                                            MessageBox.Show("Unable to unbook");
                                            return;
                                        }
                                    }
                                }
                                if (leftSeat != null && rightSeat != null)
                                {
                                    if (leftSeat.BookStatus && rightSeat.BookStatus)
                                    {
                                        MessageBox.Show("Unable to unbook");
                                        return ;
                                    }
                                }
                                else if (frontSeat != null && backSeat != null)
                                {
                                    if (frontSeat.BookStatus && backSeat.BookStatus)
                                    {
                                        MessageBox.Show("Unable to book");
                                        return;
                                    }
                                }
                                seatListArray[i].Counter = seatListArray[i].Counter - 1;
                                seat.BookStatus = false;
                                seat.BookingPerson = null;
                                seatListArray[i].DeleteSeat(seat);
                                label.BackColor = Color.White;
                                return;
                            }
                            if ((leftSeat.BookStatus && rightSeat.BookStatus)||(frontSeat.BookStatus && backSeat.BookStatus))
                            {
                                MessageBox.Show("Unable to unbook");
                                return;
                            }
                            else if (!(rightSeat.BookStatus && leftSeat.BookStatus && frontSeat.BookStatus && backSeat.BookStatus))
                            {
                                seatListArray[i].Counter = seatListArray[i].Counter - 1;
                                seat.BookStatus = false;
                                seat.BookingPerson = null;
                                seatListArray[i].DeleteSeat(seat);
                                label.BackColor = Color.White;
                                return;

                            }//end else if
                            else if(leftSeat.BookingPerson != bookingPersonArray[i] ||
                                    rightSeat.BookingPerson != bookingPersonArray[i] ||
                                    frontSeat.BookingPerson != bookingPersonArray[i] ||
                                    backSeat.BookingPerson != bookingPersonArray[i])
                            {
                                MessageBox.Show("unable to delete seat");
                            }
                        }//end else if
                        }//end if

                }//end of forloop

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void btnPerson_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();

                if (button.Text == "Person A Booking")
                {
                    for (int i = 0; i < seatListArray.Count - 1; i++)
                    {
                        if (i == 0)
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
                    for (int i = 0; i < seatListArray.Count - 1; i++)
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
                    for (int i = 0; i < seatListArray.Count - 1; i++)
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
                    for (int i = 0; i < seatListArray.Count - 1; i++)
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

                numRow.Enabled = false;
                numCol.Enabled = false;

                trueFalseEditor(false);
                bookSeats = true;

                setBtn();
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
                MessageBox.Show("Unknown Error");
            }
        }
        public void changeLabelColorAndCanBook()
        {
            try
            {
                Color[] colorArray = getColorArray();
                bool getColor = false;
                List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();
                int number = 0;

                foreach (Label label in labels) // Looping through all seatLabels
                {
                    SeatInfo si = (SeatInfo)label.Tag; // Current seat
                    
                    foreach ( SeatDoubleLinkedList seatlist in seatListArray) // Looping through the persons' booking
                    {
                        Seat seat = seatlist.SearchByRowAndColumn(si.Row, si.Column);
                        Seat leftSeat = seatList.SearchByRowAndColumn(si.Row, si.Column - 1);
                        Seat rightSeat = seatList.SearchByRowAndColumn(si.Row, si.Column + 1);
                        Seat frontSeat = seatList.SearchByRowAndColumn(si.Row - 1, si.Column);
                        Seat backSeat = seatList.SearchByRowAndColumn(si.Row + 1, si.Column);

                        if (seat != null)
                        {
                            Boolean here;
                                if (leftSeat != null && leftSeat.CanBook && !leftSeat.BookStatus)
                                {
                                     here = false;
                                     for (int n = 0; n < colDivider.Length; n++)
                                     {
                                         if(leftSeat.Column == colDivider[n])
                                         {
                                             here = true;
                                             break;
                                         }
                                     }
                                     if (!here)
                                     {
                                         leftSeat.CanBook = false;
                                     }
                                }
                                if (rightSeat != null && rightSeat.CanBook && !rightSeat.BookStatus)
                                {
                                     here = false;
                                     for (int n = 0; n < colDivider.Length; n++)
                                     {
                                         if (rightSeat.Column == colDivider[n]+1)
                                         {
                                             here = true;
                                             break;
                                         }
                                     }
                                     if (!here)
                                     {
                                         rightSeat.CanBook = false;
                                     }
                                }
                                if (backSeat != null && backSeat.CanBook && !backSeat.BookStatus)
                                {
                                     here = false;
                                     for (int n = 0; n < rowDivider.Length; n++)
                                     {
                                         if (backSeat.Row == rowDivider[n]+1)
                                         {
                                             here = true;
                                             break;
                                         }
                                     }
                                     if (!here)
                                     {
                                         backSeat.CanBook = false;
                                     }
                                }
                                if (frontSeat != null && frontSeat.CanBook && !frontSeat.BookStatus)
                                {
                                     here = false;
                                     for (int n = 0; n < rowDivider.Length; n++)
                                     {
                                         if (frontSeat.Row == rowDivider[n])
                                         {
                                             here = true;
                                             break;
                                         }
                                     }
                                     if (!here)
                                     {
                                         frontSeat.CanBook = false;
                                     }
                                }
                            

                        }
                        
                    }
                }
                int num = 0;
                for(int i = 0; i < seatListArray.Count - 1; i++)
                {
                    if(seatListArray[i].PersonChosen == true)
                    {
                        num = i;
                    }
                }
                foreach (Label label in labels)
                {
                    SeatInfo si = (SeatInfo)label.Tag;
                    Seat seat = seatList.SearchByRowAndColumn(si.Row, si.Column);
                    
                    foreach (SeatDoubleLinkedList seatDoubleLinkedList in seatListArray)
                    {
                        SeatInfo seatinfo = (SeatInfo)label.Tag;
                        Seat s = seatDoubleLinkedList.SearchByRowAndColumn(seatinfo.Row, seatinfo.Column);
                        if(seat.CanBook == false)
                        {
                            label.BackColor = Color.DarkBlue;
                        }
                        if (s != null)
                        {
                            if (s .CanBook == false)
                            {
                                label.BackColor = Color.DarkBlue;
                            }
                            else if(seatDoubleLinkedList.PersonChosen == true)
                            {
                                label.BackColor = colorArray[num];
                            }
                            else
                            {
                                getColor = true;
                                label.BackColor = Color.DarkGray;
                            }
                        }
                    }
                    if (label.BackColor == Color.LightBlue || label.BackColor == Color.White)
                    {
                        seat.CanBook = true;
                        label.BackColor = Color.White;
                    }
                    else if (label.BackColor == Color.DarkBlue)
                    {
                        seat.BookStatus = false;
                        seat.BookingPerson = null;
                        seat.CanBook = false;

                        foreach (SeatDoubleLinkedList seatDoubleLinkedList in seatListArray)
                        {
                            seatDoubleLinkedList.DeleteSeat(seat);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown Error");
            }
        }//end of changeLabelColorAndCanBook
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
        public void setBtn()
        {
            Button[] buttonArray = { btnA, btnB, btnC, btnD };
            bool check = false;
            for (int i = 0; i < seatListArray.Count - 1; i++)
            {
                if (seatListArray[i].PersonChosen == true)
                {
                    bookSeats = true;
                    check = true;
                    labelMessage.Text = "Person " + bookingPersonArray[i] + " is booking now";
                }
                if (check)
                {
                    buttonArray[i].Enabled = true;
                }
                else
                {
                    buttonArray[i].Enabled = false;
                }

            }
        }
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

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();
                foreach (Label label in labels)
                {
                    SeatInfo si = (SeatInfo)label.Tag;
                    Seat seat = seatList.SearchByRowAndColumn(si.Row, si.Column);
                    if (seat.CanBook == false)
                    {
                        seatListArray[4].InsertAtEnd(seat);
                    }
                }

                seatList.binarySaveToFile(seatListArray, "smartMode.dat");

                
                string s = numRow.Text + "\n" + numCol.Text;
                seatList.textSaveToFile(s, "smartMode.txt");

                MessageBox.Show("Saved to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                load = true;
                List<SeatDoubleLinkedList> linkedList = seatList.binaryReadFromFile("smartMode.dat");
                List<string> stringList = seatList.textReadFromFile("smartMode.txt");
                if (linkedList == null || stringList == null)
                {
                    MessageBox.Show("Unable to load file");
                    return;
                }
                seatListArray = linkedList;

                Color[] colorArray = getColorArray();
                delSeatandLabel();
                setBtn();
                trueFalseEditor(false);

                int rowSpace = 0;
                int prevRowSpace = 0;
                int colSpace = 0;
                int prevColSpace = 0;

                numRow.Text = stringList[0];
                numCol.Text = stringList[1];
                int row = int.Parse(numRow.Text);
                int seatsPerRow = int.Parse(numCol.Text);

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

                        Boolean getSeat = false;
                        Color color = Color.White;
                        Seat s = null;
                        Label labelSeat;
                        for (int x = 0; x < linkedList.Count; x++)
                        {
                            s = linkedList[x].SearchByRowAndColumn(i, j);
                            if (s != null)
                            {
                                if (linkedList[x].PersonChosen == true)
                                {
                                    color = colorArray[x];
                                    getSeat = true;
                                    break;
                                }
                                if (linkedList[x].PersonChosen == false && s.BookStatus == true)
                                {
                                    color = Color.DarkGray;
                                    getSeat = true;
                                    break;
                                }
                                if (s.CanBook == false)
                                {
                                    color = Color.DarkBlue;
                                    getSeat = true;
                                    break;
                                }
                            }
                        }

                        if (getSeat)
                        {
                            seatList.InsertAtEnd(s);
                            labelSeat = new Label();
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
                            labelSeat.BackColor = color;
                            //font 
                            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
                            //font color
                            labelSeat.ForeColor = Color.Black;
                            //Tag
                            labelSeat.Tag = new SeatInfo() { Row = s.Row, Column = s.Column };
                            labelSeat.Click += new EventHandler(labelSeat_Click);
                            panelSeats.Controls.Add(labelSeat);
                        }
                        else
                        {
                            s = new Seat();
                            s.Row = i;
                            s.Column = j;
                            seatList.InsertAtEnd(s);
                            labelSeat = new Label();
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
                            labelSeat.BackColor = color;
                            //font 
                            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
                            //font color
                            labelSeat.ForeColor = Color.Black;
                            //Tag
                            labelSeat.Tag = new SeatInfo() { Row = s.Row, Column = s.Column };
                            labelSeat.Click += new EventHandler(labelSeat_Click);
                            panelSeats.Controls.Add(labelSeat);
                        }

                        prevColSpace = colSpace;

                    }//end for loop

                    prevRowSpace = rowSpace;//add row space
                    prevColSpace = 0;//add col space
                }//end for loop

                changeLabelColorAndCanBook();
                load = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown Error");
            }
        }
        private void btnResetSimulation_Click(object sender, EventArgs e)
        {
            List<Label> labels = panelSeats.Controls.OfType<Label>().ToList();
            foreach (SeatDoubleLinkedList seatDoubleLinkedListItem in seatListArray)
            {
                foreach (Label label in labels)
                {
                    //for doubleLinkedList
                    SeatInfo seatInfo = (SeatInfo)label.Tag;
                    Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                    seatDoubleLinkedListItem.DeleteSeat(seat);
                    seat.CanBook = true;
                    seat.BookStatus = false;
                    seat.BookingPerson = null;

                    //Remove label
                    panelSeats.Controls.Remove(label);
                }
            }
            for (int i = 0; i < seatListArray.Count - 1; i++)
            {
                seatListArray[i].Counter = 0;
            }
            generate();

            bookSeats = false;
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            trueFalseEditor(false);
            rbDisable.Checked = false;
            rbEnable.Checked = false;
            btnEditorMode.Enabled = true;
            btnEditorMode.Text = "Enter Editor Mode";
            labelMessage.Text = "Simulation has resetted";
        }
    }
}
