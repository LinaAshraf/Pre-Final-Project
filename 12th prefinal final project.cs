using _12th_project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12th_project
{
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
        private Node Head;
        public Node head
        {
            get { return this.Head; }
            set
            {
                this.Head = value;
            }
        }
        public void Add(string newElement)
        {
            Node newNode = new Node(null, newElement);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = new Node(head, newElement);
                while (temp.Next != null)
                    temp = temp.Next;
                temp.Next = newNode;
            }
        }
        public void PrintList()
        {
            Node temp = this.Head;
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
            Node node = this.Head;

            while (node != null)
            {
                if (node.Data == given.Data)
                {
                    node.Next = given.Next;
                    break;
                }
                node = node.Next;
            }
        }

        public void update(int x)
        {
            Node n1 = this.head;
            for (int i = 0; i < x; i++)
            {
                n1 = n1.Next; //to get to the previous node
            }
            n1 = n1.Next; //to get to node number x
            n1.Data = Console.ReadLine();
            Console.WriteLine(n1.Data);
        }
        public void Reverse()
        {
            Node current = this.head;
            Node prev = null;

            while (current != null)
            {
                Node next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            // Set the head to the last node (which is now the first node after reversal)
            this.head = prev;
        }
        public int getCount()
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
            Node temp = this.Head;
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
        public void detectandremove(string data)
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

            // If the first list is empty, set the head of the merged list to the head of the second list
            if (node == null)
            {
                this.head = l2.head;
                return;
            }

            // Traverse the first list to its end
            while (node.Next != null)
            {
                node = node.Next;
            }

            // Set the Next of the last node in the first list to the head of the second list
            node.Next = l2.head;
        }

        public void Sort(Node head)
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






    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Store's Cashier System");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Show all parts available");
                Console.WriteLine("2. Sort parts in alphabetical order");
                Console.WriteLine("3. Number of items in the inventory");
                Console.WriteLine("4. Update  the inventory");
                Console.WriteLine("5. Search for a part ");
                Console.WriteLine("6. detect and remove a certain part");
                Console.WriteLine("7. merge 2lists");
                Console.WriteLine("8. checkout");
                Console.WriteLine("9. reverse");
                Console.WriteLine("10.Exit");
                Console.WriteLine("Enter 1 to continue");
                int choice = int.Parse(Console.ReadLine());
                LinkedList Part = new LinkedList();
                LinkedList Cust = new LinkedList();
                LinkedList Cust2 = new LinkedList();
                Part.Add("Tire");
                Part.Add("Gearbox");
                Part.Add("Suspension");
                Part.Add("Mirrors");
                Part.Add("Oil");
                Part.Add("Service");


                if (choice == 1)
                {
                    Part.PrintList();

                }
                else if (choice == 2)
                {
                    Console.WriteLine("Original List:");
                    Part.PrintList(); // Display the original list
                    Part.Sort(Part.head);
                    Part.PrintList();

                }
                else if (choice == 3)
                {
                    Console.WriteLine("Number of Items = " + Part.getCount());

                }
                else if (choice == 4)
                {
                    Console.WriteLine("enter the number of the part you want to edit");
                    int y = int.Parse(Console.ReadLine());
                    Part.update(y);

                }
                else if (choice == 5)
                {
                    Console.WriteLine("Enter the name of the part");
                    string name = Console.ReadLine();
                    Part.SearchElement(name);

                }
                else if (choice == 6)
                {
                    Console.WriteLine("Enter Name of the Part");
                    string rem = Console.ReadLine();

                    Part.detectandremove(rem);

                }
                else if (choice == 7)
                {
                    Console.WriteLine("Enter Number of new list");
                    int num = int.Parse(Console.ReadLine());
                    for (int i = 0; i < num; i++)
                    {
                        string obj = Console.ReadLine();
                        Cust.Add(obj);

                    }
                    LinkedList mergedList = new LinkedList();
                    mergedList.Merging(Part, Cust);
                    Console.WriteLine("Merged List:");
                    mergedList.PrintList();

                }

                else if (choice == 8)
                {
                    Console.WriteLine("Please Enter the number of parts Customer want to purchase");
                    int numb = int.Parse(Console.ReadLine());
                    for (int i = 1; i <= numb; i++)
                    {
                        Console.WriteLine("choose from : tire, gearbox, seats, suspension, mirrors, oil, service");
                        Console.WriteLine("Enter Part Number " + i);
                        string name = Console.ReadLine();

                        Cust2.Add(name);
                    }
                    Cust2.Checkout(Cust2.head);
                }
                else if (choice == 9)
                {
                    Console.WriteLine("Original List:");
                    Part.PrintList(); // Display the original list
                    Part.Reverse();   // Reverse the list
                    Console.WriteLine("Reversed List:");
                    Part.PrintList(); // Display the reversed list
                }
                else if (choice == 10)
                {
                    Environment.Exit(0);
                    break;
                }


                Console.ReadLine();
            }
        }
    }
}

