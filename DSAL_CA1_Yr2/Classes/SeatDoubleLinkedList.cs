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
            while(p.Next != null)
            {
                p = p.Next;
            }//End of While
            p.Next = newNode;
            newNode.Prev = p;
        }//End of InsertAtEnd

        public void DeleteSeat(Seat pSeatData)
        {
            if (this.Start == null)
            {
                return;
            }//end of if
            if (this.Start.Next == null)
            {
                if (this.Start.Seat == pSeatData)
                {
                    this.Start = null;
                }
                else
                {
                    Console.WriteLine("{0} is not found on the list", pSeatData);
                }//end of else if
                return;
            }//End of if

            //If node satisfies criteria is the first node,logic need to handle node
            //deletion seperately
            if (this.Start.Seat == pSeatData)
            {
                this.Start = this.Start.Next;
                this.Start.Prev = null;
                return;
            }//end if

            //Do looping to find the node which match the search criteria
            Node p = this.Start.Next;

            while (p.Next != null)
            {
                if (p.Seat == pSeatData)
                {
                    break;
                }//end if
                p = p.Next;
            }//end while

            if (p.Next != null)
            {//node is in-between
                p.Prev.Next = p.Next;
                p.Next.Prev = p.Prev;
            }
            else
            {//if node is last node
                if (p.Seat == pSeatData)
                {
                    //statement is required because of the weakness of loop
                    //last node might not be checked against seatch criteria
                    p.Prev.Next = null;
                }
                else
                {
                    Console.WriteLine("{0} is not found on the list", pSeatData);
                }
            }//End if
        }//end of DeleteNode
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
