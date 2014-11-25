using CodeChallengesBL.Interfaces;
using System;
using System.Collections.Specialized;
using System.Text;

/*
Week 12
This week we'll focus on building a data structure.  Implement a Linked List (without using your languages Linked List structure).  If you aren't familiar with a linked list you should start here:
 
http://en.wikipedia.org/wiki/Linked_list
 
Extra Credit if you can make your linked list a double linked list.  Have fun and send submission to dan.bunker@stgutah.com.  Summer is wrapping up and there's only 2 more code challenges left after this one.
 
Dan
 */

namespace CodeChallengesBL.ConcreteClasses
{
    public class CodeChallenge12_LinkedList : ICodeChallenge
    {
        public string OutputResult(OrderedDictionary inputValues)
        {
            var outputString = new StringBuilder();
            
            // NOTE: altering the sequence number (and consequently the input name attribute) for any ChallengeInput in the database will need to also be updated here
            string userInput = inputValues["linked-list10"] == null ? "" : inputValues["linked-list10"].ToString();
            string getIndex = inputValues["linked-list20"] == null ? "" : inputValues["linked-list20"].ToString();
            string setIndex = inputValues["linked-list30"] == null ? "" : inputValues["linked-list30"].ToString();
            string setValue = inputValues["linked-list40"] == null ? "" : inputValues["linked-list40"].ToString();
            string removeIndex = inputValues["linked-list50"] == null ? "" : inputValues["linked-list50"].ToString();

            string[] userVals = userInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            DemoLinkList(userVals, getIndex, setIndex, setValue, removeIndex, outputString);
            return outputString.ToString();
        }

        public static void DemoLinkList(string[] vals, string getIndex, string setIndex, string setValue, string removeIndex, StringBuilder outputString)
        {
            var linkedList = new SingleLinkedList<string>();

            foreach (string val in vals)
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
            outputString.AppendLine("Traverse() Results:");
            linkedList.Traverse(outputString);

            // GetAt(int index)
            testIndexStr = getIndex;
            if (Int32.TryParse(testIndexStr, out testIndexNum))
            {
                Node<string> getAtIndexNode = linkedList.GetAt(testIndexNum);
                string getAtIndextVal = getAtIndexNode != null ? getAtIndexNode.Data : "null";
                outputString.AppendLine(String.Format("\nGetAt({0}) -> {1}", testIndexNum, getAtIndextVal));
            }
            else
            {
                outputString.AppendLine("Invalid GetAt() index.");
            }

            // SetAt(int index)
            testIndexStr = setIndex;

            if (Int32.TryParse(testIndexStr, out testIndexNum))
            {
                string testIndexVal = setValue;
                bool wasSet = linkedList.SetAt(testIndexNum, testIndexVal);
                outputString.AppendLine(String.Format("\nSetAt({0}) -> {1}", testIndexNum, Convert.ToBoolean(wasSet)));
                outputString.AppendLine("Linked List after update:");
                linkedList.Traverse(outputString);
            }
            else
            {
                outputString.AppendLine("Invalid SetAt() index.");
            }

            // RemoveAt(int index)
            testIndexStr = removeIndex;
            if (Int32.TryParse(testIndexStr, out testIndexNum))
            {
                bool wasRemoved = linkedList.RemoveAt(testIndexNum);
                outputString.AppendLine(String.Format("\nRemoveAt({0}) -> {1}", testIndexNum, Convert.ToBoolean(wasRemoved)));
                outputString.AppendLine("Linked List after removal:");
                linkedList.Traverse(outputString);
            }
            else
            {
                outputString.AppendLine("Invalid RemoveAt() index.");
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

        public int Traverse(StringBuilder outputString)
        {
            int count = 0;
            Node<T> node = this.FirstNode;
            while (node != null)
            {
                // TODO - pass function pointer here, perhaps
                outputString.AppendLine(node.Data.ToString());
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
