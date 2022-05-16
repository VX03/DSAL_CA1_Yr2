using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace DSAL_CA1_Yr2.Classes
{
    [Serializable]
    public class SeatDoubleLinkedList
    {
        //Make sure that "start" refers to first node of list
        int counter = 0;
        bool personChosen = false;

        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }

        public bool PersonChosen
        {
            get { return personChosen; }
            set { personChosen = value; }
        }

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

        public void DeleteAllSeat()
        {
            if (this.Start == null)
            {
                return;
            }//end of if
            if (this.Start.Next == null)
            {
                this.Start = null;
                return;
            }//End of if
            Node p = this.Start.Next;

            while(p.Next != null)
            {
                p = p.Next;
                p.Prev = null;
            }
            if (this.Start.Next == null)
            {
                this.Start = null;
                return;
            }//End of if
        }

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
        }//end of DeleteSeat

        public Seat SearchLastSeat()
        {
            if (this.Start == null)
            {
                return null;
            }
            if (this.Start.Next == null)
            {
                return this.Start.Seat;
            }

            //the list is not empty and has more than 1 node
            Node p = this.Start;
            while (p.Next != null)
            {
                p = p.Next;
            }//end of while

            return p.Seat;
        }
        public void DeleteLastSeat()
        {
            if (this.Start == null)
            {
                return;
            }
            if (this.Start.Next == null)
            {
                this.Start = null;
                return;
            }

            //the list is not empty and has more than 1 node
            Node p = this.Start;
            while (p.Next != null)
            {
                p = p.Next;
            }//end of while
            //when loop terminates, p should be referring to last node
            p.Prev.Next = null;//Make the previous node as last node
        }//end of DeleteLastNode
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

        public void binarySaveToFile(List<SeatDoubleLinkedList> seatListArray,string file)
        {

                string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" +file;

                BinaryFormatter bf = new BinaryFormatter();
                Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);

                bf.Serialize(stream, seatListArray);
                stream.Close();

        }//end of binarySaveToFile

        public void textSaveToFile(string s, string file)
        {
            string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + file ;

            TextWriter tw = new StreamWriter(filepath);
            tw.Write(s);
            tw.Close();
        }//end of textSaveToFile

        public List<SeatDoubleLinkedList> binaryReadFromFile(string file)
        {
            try
            {
                //The logic in this method is de-serialization process
                //De-serializarion is the process of recovering an object from a storage
                string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\"+file;
                Stream stream = new FileStream(@filepath, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                List<SeatDoubleLinkedList> list = null;
                if (stream.Length != 0)
                {
                    list = (List<SeatDoubleLinkedList>)bf.Deserialize(stream);
                }
                stream.Close();

                return list;
            }catch (FileNotFoundException ex)
            {
                MessageBox.Show("Unable to find file");
                return null;
            }
        }//end of binaryReadFromFile

        public List<string> textReadFromFile(string file)
        {
            try
            {
                string line;
                List<string> list = new List<string>();
                string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\"+file;
                TextReader tr = new StreamReader(filepath);

                line = tr.ReadLine();
                do
                {
                    list.Add(line);
                    line = tr.ReadLine();
                } while (line != null);
                tr.Close();

                return list;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Unable to find file");
                return null;
            }
        }//end of textReadFromFile

        public int[] convertStringToInt(string split, TextBox s)
        {
            string[] stringArray = s.Text.Split(split);
            int[] intArray = Array.ConvertAll(stringArray, s => int.Parse(s));
            return intArray;
        }
    }//end of SeatDoubleLinkedList
}//end of namespace
