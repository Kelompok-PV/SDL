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
            simpan = null;
            insert(ref root,val);
            binomialTree.root = root;
            printConsole(val);
            treePanel.Invalidate();
            int angka = Convert.ToInt32(insertTb.Text) + 1;
            insertTb.Text=angka+"";
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
                    if (x.key<firstRoot.key)
                    {
                        firstRoot = x;
                    }
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
            //if (firstRoot.order >1)
            //{
            //    int ctr = 0;
            //    for (int i = 0; i < firstRoot.order; i++)
            //    {
            //        findHeap = false;
            //        findinHeap(firstRoot, firstRoot.prev);
            //        if (findHeap == true)
            //        {
            //            ctr++;
            //        }
            //        //if (findHeap == true)
            //        //{
            //        //    if (firstRoot.prev != null)
            //        //    {
            //        //        findHeap = false;
            //        //        Node prev = firstRoot.prev;
            //        //        findinHeap(firstRoot, prev);
            //        //        if (prev.prev != null)
            //        //        {
            //        //            firstRoot.prev = prev.prev;
            //        //        }
            //        //        else
            //        //        {
            //        //            firstRoot.prev = null;
            //        //        }
            //        //    }
            //        //}
            //    }
            //    if (ctr == firstRoot.order)
            //    {
            //        firstRoot.prev = null;
            //    }
            //}
            //if (simpan != null)
            //{
            //    firstRoot.prev = null;
            //}
            //MessageBox.Show(firstRoot.key+"");
            if (firstRoot.prev != null)
            {
                findHeap = false;
                //MessageBox.Show(firstRoot.key+" "+firstRoot.prev.key);
                Node prev = firstRoot;
                for (int i = 0; i < firstRoot.order; i++)
                {
                    prev = prev.prev;
                }

                findinHeap(firstRoot, prev);

                if (findHeap == true)
                {
                    firstRoot.prev = null;
                }
            }

            return firstRoot;
        }
        bool findHeap = false;
        private bool findinHeap(Node Root,Node prev)
        {
            Node cari = root;
            if (cari != null)
            {
                if (prev != null)
                {
                    return false;
                }
                if (cari == prev)
                {
                    findHeap = true;
                    return false;
                }
                if (cari.firstChild != null)
                {
                    findinHeap(cari.firstChild, prev);
                }
                if (cari.lastChild != null)
                {
                    findinHeap(cari.lastChild, prev);
                }
                if (cari.next != null && cari.parent != null)
                {
                    findinHeap(cari.next, prev);
                }
            }
            return false;
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
                root.draw(root,root.order*150+x_fix,0);;
            }
            
        }

        private Node getMin(Node root) { 
            if (root == null) return null; 
            Node minNode = root; 
            Node current = root.next;
            while (current != null) { 
                if (current.key < minNode.key)
                {
                    minNode = current;
                }
                current = current.next; 
            }
            return minNode;
        }
        private Node extractMin(ref Node root)
        {
            if (root != null)
            {
                Node minRoot = getMin(root);//remove from the root list
                remove(ref root, minRoot);//set parent to null for the children
                setParentToNull(minRoot.firstChild);//merge the children with the root list
                root = merge(root, minRoot.firstChild);
                hilangkanNext(root, minRoot);

                return minRoot;
            }else
                return null;
        }

        private void keParent(Node parent)
        {
            while (parent.parent!=null)
            {
                parent = parent.parent;
            }
        }

        private void hilangkanNext( Node root, Node minRoot)
        {
            Node hilang = root;
            if (hilang!=null)
            {
                if (hilang.next != minRoot)
                {
                    hilangkanNext( hilang.next, minRoot);
                }
                else
                {
                    hilang.next = null;
                }

                if (hilang.firstChild != null)
                {
                    hilangkanNext( hilang.firstChild, minRoot);
                }

                if (hilang.lastChild==null)
                {
                    keParent(hilang);
                    hilangkanNext(hilang.next, minRoot);
                }

                if (hilang.prev == minRoot)
                {
                    hilang.prev = null;
                }


                //if (hilang == minRoot)
                //{
                //    Console.WriteLine("3");
                //    if (hilang == minRoot.lastChild)
                //    {
                //        hilang.next = null;
                //    }
                //    else
                //    {
                //        hilang.next = minRoot.lastChild;
                //        Console.WriteLine("5");
                //    }
                //}

                //if (hilang.lastChild == null)
                //{
                //    Console.WriteLine("6");
                //    hilang = root.next;
                //    root = root.next;
                //    hilangkanNext(hilang, minRoot);
                //}
                //else
                //{
                //    Console.WriteLine("7");
                //    hilang = hilang.lastChild;
                //    hilangkanNext(hilang, minRoot);
                //}
            }

        }

        void remove(ref Node root, Node node) { 
            if (node.prev == null) 
                root = node.next; 
            else
                node.prev.next = node.next; 

            if (node.next != null) 
                node.next.prev = node.prev; 
        }
        void setParentToNull(Node node) { 
            for (Node current = node; current != null; current = current.next) 
                current.parent = null; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            extractMin(ref root);
            binomialTree.root = root;
            if (root != null)
            {
                printConsole(root.key);
            }
        }

        private void decreaseKey(Node node, int newKey) { 
            node.key = newKey;
            heapifyUp(node);
        }
        void heapifyUp(Node node)
        {
            while (node.parent != null && node.parent.key > node.key)
            { //violated
                swap(node, node.parent);
                node = node.parent;
            }
        }
        void swap(Node x, Node y) { 
            int temp = x.key; 
            x.key = y.key; 
            y.key = temp; 
        }
        Node simpan = null;
        private bool find(Node root,int angka)
        {
            Node cari = root;
            if (cari.key == angka)
            {
                simpan = cari;
                return true;
            }
            if (cari.firstChild != null)
            {
                find(cari.firstChild, angka);
            }
            if (cari.lastChild != null)
            {
                find(cari.lastChild, angka);
            }
            if (cari.next != null)
            {
                find(cari.next, angka);
            }
            return false;
        }
        public 
        int x_fix=0;
        int y_fix = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            treePanel.Invalidate();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            x_fix = hScrollBar1.Value-500;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int angka1 = Convert.ToInt32(textBox1.Text);
            int angka2 = Convert.ToInt32(textBox2.Text);
            simpan = null;
            find(root, angka1);
            if (simpan != null)
            {
                decreaseKey(simpan, angka2);
            }
            else
            {
                MessageBox.Show("Key yang di Decrease tidak ada");
            }
        }
    }
}
