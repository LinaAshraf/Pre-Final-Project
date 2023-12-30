using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nodelinkedlist;
namespace nodelinkedlist
{
    public partial class Form1 : Form
    {
        LinkedList Part = new LinkedList();
        public class Node
        {
            public Node Next { get; set; }
            public string Data { get; set; }

            public Node(Node next, string data)
            {
                this.Next = next;
                this.Data = data;
            }
        }

        public class LinkedList
        {
            public Node head { get; set; }

            public void Add(string newElement)
            {
                Node newNode = new Node(null, newElement);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node temp = head;
                    while (temp.Next != null)
                        temp = temp.Next;
                    temp.Next = newNode;
                }
            }

            public void PrintList()
            {
                Node temp = head;
                if (temp != null)
                {
                    Console.Write("The list contains: ");
                    while (temp != null)
                    {
                        Console.Write(temp.Data + " ");
                        temp = temp.Next;
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The list is empty.");
                }
            }

            public void Checkout(Node temp)
            {
                int price = 0;
                if (temp != null)
                {
                    Console.Write("The list contains: ");
                    while (temp != null)
                    {
                        if (temp.Data.ToLower() == "tire")
                        {
                            Console.WriteLine(temp.Data + " = $1500 ");
                            temp = temp.Next;
                            price += 1500;
                        }
                        else if (temp.Data.ToLower() == "gearbox")
                        {
                            Console.WriteLine(temp.Data + " = $5000 ");
                            temp = temp.Next;
                            price += 5000;
                        }
                        else if (temp.Data.ToLower() == "seats")
                        {
                            Console.WriteLine(temp.Data + " = $15000 ");
                            temp = temp.Next;
                            price += 15000;
                        }
                        else if (temp.Data.ToLower() == "suspension")
                        {
                            Console.WriteLine(temp.Data + " = $50000 ");
                            temp = temp.Next;
                            price += 50000;
                        }
                        else if (temp.Data.ToLower() == "mirrors")
                        {
                            Console.WriteLine(temp.Data + " = $3500");
                            temp = temp.Next;
                            price += 3500;
                        }
                        else if (temp.Data.ToLower() == "oil")
                        {
                            Console.WriteLine(temp.Data + " = $1300 ");
                            temp = temp.Next;
                            price += 1300;
                        }
                        else if (temp.Data.ToLower() == "service")
                        {
                            Console.WriteLine(temp.Data + " = $4000");
                            temp = temp.Next;
                            price += 4000;
                        }
                    }
                    Console.WriteLine("Total Price = $" + price);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The list is empty.");
                }
            }

            public void DeleteNode(Node given)
            {
                Node node = head;

                if (node == given)
                {
                    head = node.Next;
                    return;
                }

                while (node != null)
                {
                    if (node.Next == given)
                    {
                        node.Next = given.Next;
                        break;
                    }
                    node = node.Next;
                }
            }

            public void Update(int index)
            {
                Node temp = head;
                for (int i = 0; i < index && temp != null; i++)
                {
                    temp = temp.Next;
                }

                if (temp != null)
                {
                    Console.Write("Enter the new value: ");
                    temp.Data = Console.ReadLine();
                    Console.WriteLine("Updated value: " + temp.Data);
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }

            public void Reverse()
            {
                Node current = head;
                Node prev = null;

                while (current != null)
                {
                    Node next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }

                head = prev;
            }

            public int GetCount()
            {
                Node temp = head;
                int count = 0;
                while (temp != null)
                {
                    count++;
                    temp = temp.Next;
                }
                return count;
            }

            public void SearchElement(string searchValue)
            {
                Node temp = head;
                int found = 0;
                int i = 0;
                if (temp != null)
                {
                    while (temp != null)
                    {
                        i++;
                        if (temp.Data.ToLower() == searchValue.ToLower())
                        {
                            found++;
                            break;
                        }
                        temp = temp.Next;
                    }
                    if (found == 1)
                    {
                        Console.WriteLine(searchValue + " is found at index = " + i + ".");
                    }
                    else
                    {
                        Console.WriteLine(searchValue + " is not found in the list.");
                    }
                }
                else
                {
                    Console.WriteLine("The list is empty.");
                }
            }

            public void DetectAndRemove(string data)
            {
                Node node = head;
                while (node != null)
                {
                    if (node.Data == data)
                    {
                        DeleteNode(node);
                        break;
                    }
                    node = node.Next;
                }
            }

            public void Merging(LinkedList l1, LinkedList l2)
            {
                Node node = l1.head;

                if (node == null)
                {
                    head = l2.head;
                    return;
                }

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = l2.head;
            }

            public void Sort()
            {
                bool swapped;
                do
                {
                    swapped = false;
                    Node current = head;
                    while (current != null && current.Next != null)
                    {
                        if (string.Compare(current.Data, current.Next.Data) > 0)
                        {
                            // Swap current and current.Next
                            string temp = current.Data;
                            current.Data = current.Next.Data;
                            current.Next.Data = temp;
                            swapped = true;
                        }
                        current = current.Next;
                    }
                } while (swapped);
            }
        }

        public Form1()
        {
            InitializeComponent();
           LinkedList Part = new LinkedList();
            list_items.SelectedIndexChanged += listBox1_SelectedIndexChanged;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if any item is selected
            if (list_items.SelectedIndex != -1)
            {
                // Get the selected item
                string selectedPart = list_items.SelectedItem.ToString();

                // Display additional details or perform some action based on the selected item
                MessageBox.Show($"Selected part: {selectedPart}");
            }
        }

        private void button1_Click(object sender, EventArgs e)//add part
        {
            string newPart = textBox1.Text;
            Part.Add(newPart);
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e) //print
        {
            textBox2.Text = "";
            Part.PrintList();
        }

        private void button3_Click(object sender, EventArgs e)//sort
        {
            textBox2.Text = "Original List:\n";
            Part.PrintList(); // Display the original list

            Part.Sort();
            textBox2.AppendText("\nSorted List:\n");
            Part.PrintList(); // Display the sorted list
        }

        private void button4_Click(object sender, EventArgs e)//count
        {
            textBox2.Text = "Number of Items = " + Part.GetCount();

        }

        private void button5_Click(object sender, EventArgs e)//update
        {
            int index;
            if (int.TryParse(textBox3.Text, out index))
            {
                if (index >= 0 && index < Part.GetCount())
                {
                    Node temp = Part.head;
                    for (int i = 0; i < index && temp != null; i++)
                    {
                        temp = temp.Next;
                    }

                    if (temp != null)
                    {
                        Console.Write("Enter the new value: ");
                        temp.Data = Console.ReadLine();
                        Console.WriteLine("Updated value: " + temp.Data);
                    }
                    else
                    {
                        textBox2.Text = "Invalid index.";
                    }
                }
            }
            else
            {
                textBox2.Text = "Please enter a valid index.";
            }
            textBox3.Clear();
        }

        private void button6_Click(object sender, EventArgs e)//exit
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)//checkout
        {
            textBox2.Text = "Please Enter the number of parts Customer want to purchase:\n";
            int numb;
            if (int.TryParse(textBox4.Text, out numb))
            {
                LinkedList Cust2 = new LinkedList();

                for (int i = 1; i <= numb; i++)
                {
                    textBox2.AppendText("choose from: tire, gearbox, seats, suspension, mirrors, oil, service\n");
                    textBox2.AppendText("Enter Part Number " + i + ":\n");
                    string name = Console.ReadLine();

                    Cust2.Add(name);
                }
                Cust2.Checkout(Cust2.head);
            }
            else
            {
                textBox2.AppendText("Please enter a valid number.\n");
            }
            textBox4.Clear();
        }

        private void button8_Click(object sender, EventArgs e)//detect and remove
        {
            string partToRemove =  textBox6.Text;
            Part.DetectAndRemove(partToRemove);
            textBox6.Clear();
        }

        private void button9_Click(object sender, EventArgs e)//search
        {
            string searchValue = textBox8.Text;
            Part.SearchElement(searchValue);
            textBox8.Clear();
        }

        private void button10_Click(object sender, EventArgs e)//reverse
        {
            textBox2.Text = "Original List:\n";
            Part.PrintList(); // Display the original list

            Part.Reverse();

            textBox2.AppendText("\nReversed List:\n");
            Part.PrintList(); // Display the reversed list
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
