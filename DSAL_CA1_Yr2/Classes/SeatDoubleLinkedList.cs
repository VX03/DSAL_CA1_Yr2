using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA1_Yr2.Classes
{
    class SeatDoubleLinkedList
    {
        //Make sure that "start" refers to first node of list

        public Node Start { get; set; }//End of Start

        public SeatDoubleLinkedList()
        {
            this.Start = null;
        }//End of SeatDoubleLinkedList

        public void InsertAtEnd(Seat pSeatData)
        {
            Node newNode = new Node(pSeatData);
            if(this.Start == null)
            {
                this.Start = newNode;
                return;
            }//End if

            Node p = this.Start;
            //Traverse through the list until p refers to last node
            while(p != null)
            {
                p = p.Next;
            }//End of While
            p.Next = newNode;
            newNode.Prev = p;
        }//End of InsertAtEnd

        public Seat SearchByRowAndColumn(int pRow,int pColumn)
        {
            Node p = this.Start;
            while(p != null)
            {
                if((p.Seat.Column == pColumn) && (p.Seat.Row == pRow))
                {
                    break;//Exit loop
                }
                p = p.Next;//Continue to next node
            }

            if(p == null)//Unable to find
            {
                return null;
            }
            else
            {
                return p.Seat;
            }//end of if else

        }//end of SearchByRowAndColumn

    }//end of SeatDoubleLinkedList
}//end of namespace
