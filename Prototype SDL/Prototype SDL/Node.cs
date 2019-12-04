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
        public int x_parent { get; set; }
        public int y_parent { get; set; }
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

        //gambar node
        public void gambar(Node cetak,int x,int y)
        {
            Graphics g = config.g;
            g.DrawString(cetak.key.ToString(), font, new SolidBrush(Color.Black), x+10, y+10);
            g.DrawEllipse(Pens.Black, new Rectangle(x, y, 50, 50));
        }
        public bool cekHistory(Node cetak,Node parent)
        {
            while (parent.parent != null)
            {
                parent=parent.parent;
                if((cetak.next == parent) || (cetak.next == parent.lastChild))
                {
                    return false;
                }
                cekHistory(cetak, parent);
            }
            return true;
        }
        //recursive panggil prosedure gambar dan menggambar line
        public void draw(Node pertama,int x,int y,int tamx)
        {
            Node cetak = pertama;
            Graphics g = config.g;
            int simpan_x = 0;
            if (cetak.parent == null)
            {
                int simpan = cetak.order-1;
                if(cetak.prev== null|| cetak.prev.parent == null)
                {
                    x = (int)(125 * Math.Pow(2,simpan))+tamx;
                    if (simpan == 0)
                    {
                        x = 125 + tamx;
                    }
                    simpan_x = x;
                    y = 0;
                    cetak.x_parent = x;
                }

                if (x < 0|| cetak.order == 0)
                {
                    x = 0 + tamx;

                    cetak.x_parent = x;
                }
            }
            else
            {
                cetak.x_parent = x;
                cetak.y_parent = y;
            }
            gambar(cetak,x,y); //gambar node
            if (cetak.firstChild != null)
            {
                g.DrawLine(Pens.Black, x+25,y+50,x+25,y+100);
               
                draw(cetak.firstChild, x, y+100,tamx); 
            }
            if (cetak.next != null&&cetak.parent==null)
            {
                
                g.DrawLine(Pens.Black, x +50, y + 25, x + simpan_x, y + 25);
                x = x  + simpan_x;
                draw(cetak.next, x , y, tamx);

                x = x - simpan_x;
            }
            else if ((cetak.next != null && cetak.parent != null)&&cekHistory(cetak,cetak))
            {
                //System.Windows.Forms.MessageBox.Show(cetak.key+" "+cetak.order);
                int kiri = (int)(125 * Math.Pow(2, cetak.order-2));
                if (cetak.order <= 1)
                {
                    kiri = 50;
                }
                g.DrawLine(Pens.Black, cetak.parent.x_parent+25, y - 50, x  -kiri, y);
                x = x - kiri;
                draw(cetak.next, x-25, y, tamx);
                x = x + kiri;
            }

            if (cetak.lastChild != null && cetak.lastChild != cetak.firstChild)
            {
                //System.Windows.Forms.MessageBox.Show(cetak.key+" ");
                int kiri=(int)(125 * Math.Pow(2, cetak.order-3));
                if (cetak.order == 2)
                {
                    kiri = 0;
                }
                if (cetak.order ==3)
                {
                    kiri = 75;
                }
                //System.Windows.Forms.MessageBox.Show(kiri+" "+x);
                g.DrawLine(Pens.Black, x + 25, y + 50, x - 50-kiri, y+100);
                x -= 50+kiri;
                draw(cetak.lastChild, x - 25, y+100, tamx);
            }

        }
    }
}
