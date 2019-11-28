using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_SDL
{
    class Node
    {
        public int key { get; set; }
        public Node parent { get; set; }
        public Node next { get; set; }
        public Node lastChild { get; set; }
        public Node firstChild { get; set; }
        public int order { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Node(int key)
        {
            this.key = key;
            this.parent = null;
            this.next = null;
            this.lastChild = null;
            this.firstChild = null;
            this.order = 0;
        }

        public void addSubtree(Node newChild)
        {
            Console.WriteLine("add kebawah");
            Console.WriteLine(newChild.key);
            if(this.firstChild == null)
            {
                this.firstChild = newChild;
                this.lastChild = newChild;
            }
            else
            {
                this.lastChild.next = newChild; 
                this.lastChild = newChild; 
            }
            newChild.parent = this;
            newChild.next = null;
            this.order = newChild.order + 1;

            newChild.x = newChild.parent.x;
            newChild.y = newChild.parent.y + 100;

            while (firstChild.next!=null)
            {
                mergeTree(newChild, firstChild.next);
            }
        }
        public void mergeTree(Node x, Node y)
        {
            if (x.key <= y.key)
            {
                x.addSubtree(y); //y becomes child of x
                y.y += 100;
            }
            else
            {
                y.addSubtree(x); //x becomes child of y
                x.y += 100;
            }
                
        }
            Font font = new Font("ARIAL",15,FontStyle.Regular);
        public void draw()
        {
            Graphics g = config.g;
            if(this.parent == null)
            {
                g.DrawEllipse(Pens.Black, new Rectangle(this.x, this.y, 50, 50));
                g.DrawString(this.key.ToString(), font, new SolidBrush(Color.Black),x,y);
            }
            else
            {
                g.DrawLine(Pens.Black, this.parent.x+25, this.parent.y+50,this.x+25,this.y);
                g.DrawString(this.key.ToString(), font, new SolidBrush(Color.Black), x, y);
                g.DrawEllipse(Pens.Black, new Rectangle(this.x,this.y, 50, 50));
            }
            
        }
    }
}
