using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ogrodnik
{
    public partial class Form1 : Form
    {
        Graphics g;
        int rozmiarPola = 40;
        BazaDataContext BazaDC = new BazaDataContext();
        Point ogrodnik = new Point(10,10);
        public Form1()
        {
            InitializeComponent();
            pictureBoxOgrod_SizeChanged(null, null);
           
        }

        bool przesadzanie = false;
        Kwiatek doPrzesadzania;

        private void Odrysuj()
        {         
            g.Clear(Color.LightGreen);

            foreach(Kwiatek k in BazaDC.Kwiateks)
            {
                rysujKolor(Color.Red, k.x, k.y);
                rysujKolor(Color.Yellow, k.x+1, k.y);
                rysujKolor(Color.Yellow, k.x-1, k.y);
                rysujKolor(Color.Yellow, k.x, k.y-1);
                rysujKolor(Color.Yellow, k.x, k.y+1);           
            }
            rysujKolor(Color.Brown, ogrodnik.X, ogrodnik.Y);
            if(przesadzanie)
            {
                g.DrawRectangle(new Pen(Color.Red,2),
                    (ogrodnik.X-1)*rozmiarPola,
                    (ogrodnik.Y-1)*rozmiarPola,
                 rozmiarPola*3,
                rozmiarPola*3);


            }
            BazaDC.SubmitChanges();
            pictureBoxOgrod.Refresh();
        }
       

        private void rysujKolor(Color kolor, int x, int y)
        {
            g.FillEllipse(new SolidBrush(kolor),
                                 x * rozmiarPola,
                                 y * rozmiarPola,
                                 rozmiarPola,
                                 rozmiarPola);         
        }

        private void pictureBoxOgrod_SizeChanged(object sender, EventArgs e)
        {
            pictureBoxOgrod.Image = new Bitmap(pictureBoxOgrod.Width, pictureBoxOgrod.Height);
            g = Graphics.FromImage(pictureBoxOgrod.Image);
            Odrysuj();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           


                switch (e.KeyCode)
                {
                case Keys.P:
                    if (BazaDC.Kwiateks.Where(kwiat => kwiat.x == ogrodnik.X && kwiat.y == ogrodnik.Y).Count() > 0)
                    {
                        przesadzanie = !przesadzanie;
                        doPrzesadzania = BazaDC.Kwiateks.Single(kwiat => kwiat.x == ogrodnik.X && kwiat.y == ogrodnik.Y);
                    }
                        
                    break;
                    case Keys.Up:
                        ogrodnik.Y--;
                    if (przesadzanie)
                    {
                        doPrzesadzania.y--;
                    }
                    break;
                    case Keys.Down:
                        ogrodnik.Y++;
                    if (przesadzanie)
                    {
                        doPrzesadzania.y++;
                    }
                    break;

                    case Keys.Left:
                        ogrodnik.X--;
                    if(przesadzanie)
                    {
                        doPrzesadzania.x--;
                    }
                        break;
                    case Keys.Right:
                        ogrodnik.X++;
                    if (przesadzanie)
                    {
                        doPrzesadzania.x++;
                    }
                    break;

                    case Keys.Space:
                        //delete



                        if (BazaDC.Kwiateks.Where(kwiat => kwiat.x == ogrodnik.X && kwiat.y == ogrodnik.Y).Count() > 0)
                        {
                            //rysujKolor(Color.Yellow,ogrodnik)

                            BazaDC.Kwiateks.DeleteAllOnSubmit(BazaDC.Kwiateks.Where(kwiat => kwiat.x == ogrodnik.X && kwiat.y == ogrodnik.Y));
                            BazaDC.SubmitChanges();
                        }
                        //za blisko
                        else if (BazaDC.Kwiateks.Where(kwiat => Math.Abs(kwiat.x - ogrodnik.X) <= 1 &&
                                                                Math.Abs(kwiat.y - ogrodnik.Y) <= 1).Count() > 0)
                        {
                            MessageBox.Show("za blisko");
                        }
                        else
                        {
                            Kwiatek nowy = new Kwiatek();
                            nowy.y = ogrodnik.Y;
                            nowy.x = ogrodnik.X;
                            BazaDC.Kwiateks.InsertOnSubmit(nowy);
                            BazaDC.SubmitChanges();
                        }

                        break;



                }
            
            
            Odrysuj();
        }
    }
}
