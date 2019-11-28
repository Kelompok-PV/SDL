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
        public Node prev { get; set; }
        public Node lastChild { get; set; }
        public Node firstChild { get; set; }
        public int order { get; set; }
        public Node(int key)
        {
            this.key = key;
            this.parent = null;
            this.next = null;
            this.prev = null;
            this.lastChild = null;
            this.firstChild = null;
            this.order = 0;
        }

        public void addSubtree(Node newChild)
        {
            if(this.firstChild == null)
            {
                this.firstChild = newChild;
                this.lastChild = newChild;
            }
            else
            {
                this.lastChild.next = newChild;
                newChild.prev = this.lastChild;
                this.lastChild = newChild; 
            }
            newChild.parent = this;
            newChild.next = null;
            this.order = newChild.order + 1;


        }
        public void mergeTree(Node x, Node y)
        {
            if (x.key <= y.key)
            {
                x.addSubtree(y); //y becomes child of x
            }
            else
            {
                y.addSubtree(x); //x becomes child of y
            }
                
        }
        Font font = new Font("ARIAL",15,FontStyle.Regular);
        public void gambar(Node cetak,int x,int y)
        {
            Graphics g = config.g;
            g.DrawString(cetak.key.ToString(), font, new SolidBrush(Color.Black), x+10, y+10);
            g.DrawEllipse(Pens.Black, new Rectangle(x, y, 50, 50));
        }
        public void draw(Node pertama,int x,int y)
        {
            Node cetak = pertama;
            Graphics g = config.g;
            gambar(cetak,x,y);
            if (cetak.firstChild != null)
            {
                g.DrawLine(Pens.Black, x+25,y+50,x+25,y+100);
                y += 100;
                draw(cetak.firstChild, x, y); 
            }

            if (cetak.lastChild != null&&cetak.lastChild!=cetak.firstChild)
            {
                g.DrawLine(Pens.Black, x + 25, y - 50, x -75, y);
                x -= 100;
                draw(cetak.lastChild, x, y);
            }

            if (cetak.next != null&&cetak.parent==null)
            {
                y = 0;
                g.DrawLine(Pens.Black, x +50, y + 25, x + 100*cetak.next.order, y + 25);
                x += 100 * cetak.next.order;
                draw(cetak.next, x, y);
            }


        }
    }
}
