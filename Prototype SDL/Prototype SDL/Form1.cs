using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SDL
{
    public partial class Form1 : Form
    {
        Tree binomialTree;
        Node root;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Binomial Tree";
            binomialTree = new Tree();
            config.width = treePanel.Width;
            config.height = treePanel.Height;
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(insertTb.Text);
            insert(ref root,val);
            binomialTree.root = root;
            printConsole(val);
            treePanel.Invalidate();
            
        }

        private void insert(ref Node root,int key)
        {
            Node newNode = new Node(key);
            root = merge(root, newNode);
        }

        private Node merge(Node x, Node y)
        {
            if (x == null)
            {
                return y;
            }
            if (y == null)
            {
                return x;
            }

            Node firstRoot = x = simpleMerge(x,y);
            while(x!=null && x.next != null)
            {
                Node next_x = x.next;
                if ((x.order != next_x.order) //case 1
                        || (x.order == next_x.order && next_x.next != null
                        && x.order == next_x.next.order))
                { //case 2
                  //move ahead
                    x = next_x;
                }
                else
                {
                    Node prev_x = x.prev;
                    Node next_next_x = next_x.next;
                    x = mergeTree(x, next_x);
                    if (prev_x == null)
                    {
                        firstRoot = x;
                    }
                    else
                    {
                        prev_x.next = x;
                    }
                    x.next = next_next_x;
                    if (next_next_x != null)
                    {
                        next_next_x.prev = x;
                    }
                }
            }
            return firstRoot;
        }

        private Node simpleMerge(Node x,Node y)
        {
            Node result = null;
            Node last = null;
            while(x !=null || y != null)
            {
                if (x!=null&&y==null)
                {
                    x.prev = last;
                    if (result == null)
                    {
                        result = x;
                    }
                    else
                    {
                        last.next = x;
                    }
                    last = x;
                    x = x.next;
                }
                else if (x == null && y != null)
                {
                    y.prev = last;
                    if (result == null)
                    {
                        result = y;
                    }
                    else
                    {
                        last.next = y;
                    }
                    last = y;
                    y = y.next;
                }
                else
                {
                    if (x.order <= y.order)
                    {
                        x.prev = last;
                        if (result == null)
                        {
                            result = x;
                        }
                        else
                        {
                            last.next = x;
                        }
                        last = x;
                        x = x.next; 
                    }
                    else
                    {
                        y.prev = last;
                        if (result == null)
                        {
                            result = y;
                        }
                        else
                        {
                            last.next = y;
                        }
                        last = y;
                        y = y.next;
                    }
                }
            }
            last.next = null;
            return result;
        }

        private Node mergeTree(Node x,Node y)
        {
            if (x.key <= y.key)
            {
                x.addSubtree(y);
                return x;
            }
            else
            {
                y.addSubtree(x); 
                return y;
            }
        }

        public void printConsole(int insertVal)
        {
            Node temp = binomialTree.root;
            string last = "";
            string first = "";
            string next = "";
            string prev = "";
            string parent = "";

            Console.WriteLine("Insert: "+insertVal);

            if (temp.lastChild == null)
            {
                last = "null";
            }
            else
            {
                last = temp.lastChild.key.ToString();
            }

            if (temp.firstChild == null)
            {
                first = "null";
            }
            else
            {
                first = temp.firstChild.key.ToString();
            }

            if (temp.next == null)
            {
                next = "null";
            }
            else
            {
                next = temp.next.key.ToString();
            }
            if (temp.prev == null)
            {
                prev= "null";
            }
            else
            {
                prev = temp.prev.key.ToString();
            }
            if (temp.parent == null)
            {
                parent = "null";
            }
            else
            {
                parent = temp.parent.key.ToString();
            }

            Console.WriteLine("=================");
            Console.WriteLine(string.Format("Root key: {0}\n" +
                "firstChild: {1},\n" +
                "LastChild: {2},\n" +
                "next: {3},\n" +
                "prev: {4},\n" +
                "order:{5},\n" +
                "parent:{6}", temp.key, first, last, next,prev, temp.order, parent));
            Console.WriteLine("=================\n");

        }

        private void treePanel_Paint(object sender, PaintEventArgs e)
        {
            config.g = e.Graphics;
            if (root != null)
            {
                root.draw(root,root.order*150,0);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
