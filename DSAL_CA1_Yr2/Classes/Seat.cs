using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA1_Yr2.Classes
{
    class Seat
    {
        //Whether the seat has been selected
        private bool _bookStatus = false;
        //Seat is bookable or not
        private bool _canBook = false;
        //the _row field is 2 if obj modelling a seat at row "B"
        private int _row;
        //the _column field is 3 if obj modelling a seat at col 3
        private int _column;

        private string _bookingPerson;

        public string BookingPerson
        {
            get { return _bookingPerson; }
            set { _bookingPerson = value; }
        }
        public int Row
        {
            get { return _row; }//get method
            set { _row = value; }//set method
        }//end of property Row

        public int Column
        {
            get { return _column; }//get method
            set { _column = value; }//set method
        }//end of property Column

        public bool CanBook
        {
            get { return _canBook; }//get method
            set { _canBook = value; }//set method
        }//end of property CanBook

        public bool BookStatus
        {
            get { return _bookStatus; }//get method
            set { _bookStatus = value; }//set method
        }//end of property CanBook

        public string ComputeSeatLabel()
        {
            return((char)(_row+64)).ToString()+_column.ToString();
        }//end of ComputeSeatLabel

    }//end of Seat class
}//end of namespace
