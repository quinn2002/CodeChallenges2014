using System;

/*
Week 12
This week we'll focus on building a data structure.  Implement a Linked List (without using your languages Linked List structure).  If you aren't familiar with a linked list you should start here:
 
http://en.wikipedia.org/wiki/Linked_list
 
Extra Credit if you can make your linked list a double linked list.  Have fun and send submission to dan.bunker@stgutah.com.  Summer is wrapping up and there's only 2 more code challenges left after this one.
 
Dan
 */

namespace CodeChallenge12_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                Console.WriteLine("\n\nEnter space-separated values to add to the linked list. Type 'q' to quit.");
                userInput = Console.ReadLine();
                string[] userVals = userInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (userInput != "q")
                {
                    DemoLinkList(userVals);
                }
            } while (userInput != "q");
        }

        public static void DemoLinkList(string[] vals)
        {
            var linkedList = new SingleLinkedList<string>();

            foreach(string val in vals)
            {
                linkedList.Add(new Node<string>(val));
            }

            /**********QUICK AND DIRTY "UNIT" TESTS FOR DEMO PURPOSES************/
            // demo of implementation illustrates basic CRUD operations on the linked list
            // C - Add()
            // R - Traverse(), GetAt()
            // U - SetAt()
            // D - RemoveAt()
            string testIndexStr;
            int testIndexNum;
            
            // Traverse()
            Console.WriteLine("Traverse() Results:");
            linkedList.Traverse();

            // GetAt(int index)
            Console.Write("\nType index to get value at:");
            testIndexStr = Console.ReadLine();
            if (Int32.TryParse(testIndexStr, out testIndexNum))
            {
                Node<string> getAtIndexNode = linkedList.GetAt(testIndexNum);
                string getAtIndextVal = getAtIndexNode != null ? getAtIndexNode.Data : "null";
                Console.WriteLine("\nGetAt({0}) -> {1}", testIndexNum, getAtIndextVal);
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }

            // SetAt(int index)
            Console.Write("\nType index to set value at:");
            testIndexStr = Console.ReadLine();
            
            if (Int32.TryParse(testIndexStr, out testIndexNum))
            {
                Console.Write("\nType new value to set at index {0}:", testIndexNum);
                string testIndexVal = Console.ReadLine();
                bool wasSet = linkedList.SetAt(testIndexNum, testIndexVal);
                Console.WriteLine("\nSetAt({0}) -> {1}", testIndexNum, Convert.ToBoolean(wasSet));
                Console.WriteLine("Linked List after update:");
                linkedList.Traverse();
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }

            // RemoveAt(int index)
            Console.Write("\nType index to remove value at:");
            testIndexStr = Console.ReadLine();
            if (Int32.TryParse(testIndexStr, out testIndexNum))
            {
                bool wasRemoved = linkedList.RemoveAt(testIndexNum);
                Console.WriteLine("\nRemoveAt({0}) -> {1}", testIndexNum, Convert.ToBoolean(wasRemoved));
                Console.WriteLine("Linked List after removal:");
                linkedList.Traverse();
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T data)
        {
            this.Data = data;
        }
    }

    // implementation provides basic CRUD operations
    // C - Add()
    // R - Traverse(), GetAt()
    // U - SetAt()
    // D - RemoveAt()
    public class SingleLinkedList<T>
    {
        private Node<T> FirstNode { get; set; }

        // returns true if item was succesfully added
        public bool Add(Node<T> newNode)
        {
            bool success = false;
            Node<T> node = this.FirstNode;
            if (node == null) // list is empty
            {
                this.FirstNode = newNode;
                success = true;
                return success;
            }

            do
            {
                if (node.Next == null) // end of list
                {
                    newNode.Next = node.Next;
                    node.Next = newNode;
                    success = true;
                    break;
                }
                node = node.Next;
            } while (node != null);
            return success;
        }

        // returns how many items were traversed
        public int Traverse()
        {
            int count = 0;
            Node<T> node = this.FirstNode;
            while (node != null)
            {
                // TODO - pass function pointer here, perhaps
                Console.WriteLine(node.Data);
                node = node.Next;
                count++;
            }
            return count;
        }

        public Node<T> GetAt(int index)
        {
            int count = 0;
            Node<T> node = this.FirstNode;
            while (node != null)
            {
                if (count == index)
                {
                    return node;
                }
                else
                {
                    node = node.Next;
                    count++;
                }
            }
            return null;
        }

        // returns true if update succeeded
        public bool SetAt(int index, T val)
        {
            int count = 0;
            Node<T> node = this.FirstNode;
            while (node != null)
            {
                if (count == index)
                {
                    node.Data = val;
                    return true;
                }
                else
                {
                    node = node.Next;
                    count++;
                }
            }
            return false;
        }

        // returns true if item was successfully removed
        public bool RemoveAt(int index)
        {
            int count = 0;
            Node<T> node = this.FirstNode;

            while (node != null)
            {
                if (index == 0) // at the beginning of the list
                {
                    if (node.Next != null)
                    {
                        this.FirstNode = node.Next;
                    }
                    else
                    {
                        this.FirstNode = null; // list only had one element to begin with
                    }
                    return true;
                }
                else if (count == index - 1) // at the previous element
                {
                    if (node.Next != null) // check for end of list
                    {
                        node.Next = node.Next.Next;
                    }
                    else
                    {
                        node.Next = null;
                    }
                    return true;
                }
                else
                {
                    node = node.Next;
                    count++;
                }
            }
            return false;
        }
    }
}
