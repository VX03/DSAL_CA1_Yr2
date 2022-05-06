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
        }//end of btnGenerate_Click

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
                label.BackColor = Color.LightBlue; ;
            }


        }//end of labelSeat_Click

        class SeatInfo
        {
            public int Row { get; set; }
            public int Column { get; set; }
        }//end of seatInfo

    }//end of normal_mode
}
