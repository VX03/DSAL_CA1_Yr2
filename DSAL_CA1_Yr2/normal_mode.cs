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

                        panelLabels.GenerateSeat(i, j, rowSpace, colSpace,this.panelSeats);
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
            Button button = (Button)sender;
            if(button.Text == "Person A Booking")
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
            else if(button.Text == "Person C Booking")
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

            panelLabels.changeLabelColor(panelSeats);

        }

    }//end of normal_mode
}
