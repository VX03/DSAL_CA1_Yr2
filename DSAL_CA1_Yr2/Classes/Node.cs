using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA1_Yr2.Classes
{
    class Node
    {
        private Node _prev;
        private Seat _seat;
        private Node _next;

        public Node(Seat pSeat)
        {
            _seat = pSeat;
            _prev = null;
            _next = null;   
        }//End of constructor

        public Seat Seat
        {
            get { return _seat; }
            set { _seat = value; }
        }//End of Seat

        public Node Next
        {
            get { return _next; }
            set { _next = value; }
        }//End of Next

        public Node Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }//End of Previous

    }//end of Node class
}//end of namespace
