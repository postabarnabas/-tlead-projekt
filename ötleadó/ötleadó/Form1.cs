using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ötleadó
{
    public partial class Form1 : Form
    {
        public List<string> kártyák = new List<string>();
        public Random rnd = new Random();
        public List<string> magyarkártyák = new List<string>();
        public bool győztes = false;
        public List<PictureBox> kiválaszottlapok = new List<PictureBox>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void kiosztás()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    pictureBox1.Image = Image.FromFile(magyarkártyák[i]);
                    pictureBox1.Tag = magyarkártyák[i];
                    magyarkártyák.Remove(magyarkártyák[i]);
                }
                if (i == 1)
                {
                    pictureBox2.Image = Image.FromFile(magyarkártyák[i]);
                    pictureBox2.Tag = magyarkártyák[i];
                    magyarkártyák.Remove(magyarkártyák[i]);
                }
                if (i == 2)
                {
                    pictureBox3.Image = Image.FromFile(magyarkártyák[i]);
                    pictureBox3.Tag = magyarkártyák[i];
                    magyarkártyák.Remove(magyarkártyák[i]);
                }
                if (i == 3)
                {
                    pictureBox4.Image = Image.FromFile(magyarkártyák[i]);
                    pictureBox4.Tag = magyarkártyák[i];
                    magyarkártyák.Remove(magyarkártyák[i]);
                }
                if (i == 4)
                {
                    pictureBox5.Image = Image.FromFile(magyarkártyák[i]);
                    pictureBox5.Tag = magyarkártyák[i];
                    magyarkártyák.Remove(magyarkártyák[i]);
                }
                if (i == 5)
                {
                    pictureBox6.Image = Image.FromFile(magyarkártyák[i]);
                    magyarkártyák.Remove(magyarkártyák[i]);
                }
                if (i == 6)
                {
                    pictureBox7.Image = Image.FromFile(magyarkártyák[i]);
                    magyarkártyák.Remove(magyarkártyák[i]);
                }
                if (i == 7)
                {
                    pictureBox8.Image = Image.FromFile(magyarkártyák[i]);
                    magyarkártyák.Remove(magyarkártyák[i]);
                }
                if (i == 8)
                {
                    pictureBox9.Image = Image.FromFile(magyarkártyák[i]);
                    magyarkártyák.Remove(magyarkártyák[i]);
                }
                if (i == 9)
                {
                    pictureBox10.Image = Image.FromFile(magyarkártyák[i]);
                    magyarkártyák.Remove(magyarkártyák[i]);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            string eleresi_ut = @"D:\ötleadó\ötleadó"; // A célkönyvtár elérési útja
            foreach (string filePath in Directory.GetFiles(eleresi_ut, "*.png"))
            {
                kártyák.Add(filePath);
            }
            //véletlenszerűség meghatározása
            #region
            while (magyarkártyák.Count != 32)
            {
                int x = rnd.Next(0, 32);
                if (!magyarkártyák.Contains(kártyák[x]))
                {
                    magyarkártyák.Add(kártyák[x]);
                }
            }
            #endregion
            //kártyák kiosztása a játékosoknak
            #region
            kiosztás();
            label16.Text += magyarkártyák.Count.ToString();
            #endregion
            label5.Visible = true;
            panel2.Enabled = false;
            button3.Visible = true;
            button3.Enabled = true;
            foreach (var item in magyarkártyák)
            {
                listBox1.Items.Add(item);
            }
            
        }
        //kártyák kiválasztása leadáshoz //csak egyszer teszi bele
        #region
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!kiválaszottlapok.Contains(pictureBox3))
            {
                pictureBox14.Image = pictureBox3.Image;
                kiválaszottlapok.Add(pictureBox3);
            }
            return;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (!kiválaszottlapok.Contains(pictureBox4))
            {
                pictureBox15.Image = pictureBox4.Image;
                kiválaszottlapok.Add(pictureBox4);
            }
            return;
        }       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!kiválaszottlapok.Contains(pictureBox1))
            {
                pictureBox11.Image = pictureBox1.Image;
                kiválaszottlapok.Add(pictureBox1);
            }
            return;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anyád");
        }        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!kiválaszottlapok.Contains(pictureBox2))
            {
                pictureBox12.Image = pictureBox2.Image;
                kiválaszottlapok.Add(pictureBox2);
            }
            return;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (!kiválaszottlapok.Contains(pictureBox5))
            {
                pictureBox13.Image = pictureBox5.Image;
                kiválaszottlapok.Add(pictureBox5);
            }
            return;
        }
        #endregion
        //párosság vizsgálása
        private void button3_Click(object sender, EventArgs e)
        {            
            int mennyi = 0;
            List<PictureBox> pictureboxes = new List<PictureBox>();
            pictureboxes = new List<PictureBox>{pictureBox11,pictureBox12,pictureBox13,pictureBox14,pictureBox15};
            foreach (var item in pictureboxes)
            {
                if (item.Image != null)
                {
                    mennyi++;
                }
            }
            if (mennyi == 3 || mennyi == 5 || mennyi == 1)
            {
                if (mennyi == 1)
                {
                    panel2.Enabled = true;
                    panel3.Enabled = false;
                    label5.Text = "Játékos kettő következik! \nVálassz lapokat, hogy melyik(ek)kel ütöd el! Ha nem lehetséges fel kell venned!";
                    foreach (var item in kiválaszottlapok)
                    {
                        item.Image = Image.FromFile(magyarkártyák[0]);
                        magyarkártyák.RemoveAt(0);
                    }
                    label16.Text = "Lent van a talonban: "+magyarkártyák.Count.ToString();
                    button3.Enabled = false;
                    listBox1.Items.Clear();
                    foreach (var item in magyarkártyák)
                    {
                        listBox1.Items.Add(item);
                    }

                }
                else if(mennyi==3|| mennyi == 5)
                {//mennyi==3
                    if(mennyi == 3)
                    {
                        List<string> párosake = new List<string>();
                        foreach (var item in kiválaszottlapok)
                        {
                            párosake.Add(item.Tag.ToString().Split('\\')[3].Split('_')[1].Split('.')[0]);   
                        }
                        List<string> párosakevizsgálat = new List<string>();
                        foreach (var item in párosake)
                        {
                            if (!párosakevizsgálat.Contains(item))
                                párosakevizsgálat.Add(item);
                        }
                        if (párosakevizsgálat.Count != 2)
                        {
                            MessageBox.Show("Nem jól párzik");
                            foreach (var item in pictureboxes)
                            {
                                item.Image = null;
                            }
                            kiválaszottlapok.Clear();
                        }
                        else
                        {
                            panel2.Enabled = true;
                            panel3.Enabled = false;
                            label5.Text = "Játékos kettő következik! \nVálassz lapokat, hogy melyik(ek)kel ütöd el! Ha nem lehetséges fel kell venned!";
                            foreach (var item in kiválaszottlapok)
                            {
                                item.Image = Image.FromFile(magyarkártyák[0]);
                                magyarkártyák.RemoveAt(0);

                            }
                            label16.Text = "Lent van a talonban: " + magyarkártyák.Count.ToString();
                            button3.Enabled = false;
                            listBox1.Items.Clear();
                            foreach (var item in magyarkártyák)
                            {
                                listBox1.Items.Add(item);
                            }
                        }
                    }//mennyi==5
                    else
                    {
                        List<string> párosake = new List<string>();
                        foreach (var item in kiválaszottlapok)
                        {
                            párosake.Add(item.Tag.ToString().Split('\\')[3].Split('_')[1].Split('.')[0]);
                        }
                        List<string> párosakevizsgálat = new List<string>();
                        foreach (var item in párosake)
                        {
                            if (!párosakevizsgálat.Contains(item))
                                párosakevizsgálat.Add(item);
                        }
                        if (párosakevizsgálat.Count!=3)
                        {
                            MessageBox.Show("Nem jól párzik");
                            foreach (var item in pictureboxes)
                            {
                                item.Image = null;
                            }
                            kiválaszottlapok.Clear();
                        }
                        else
                        {
                            panel2.Enabled = true;
                            panel3.Enabled = false;
                            label5.Text = "Játékos kettő következik! \nVálassz lapokat, hogy melyik(ek)kel ütöd el! Ha nem lehetséges fel kell venned!";
                            foreach (var item in kiválaszottlapok)
                            {
                                item.Image = Image.FromFile(magyarkártyák[0]);
                                magyarkártyák.RemoveAt(0);

                            }
                            label16.Text = "Lent van a talonban: " + magyarkártyák.Count.ToString();
                            button3.Enabled = false;
                            listBox1.Items.Clear();
                            foreach (var item in magyarkártyák)
                            {
                                listBox1.Items.Add(item);
                            }
                        }
                    }    
                }
            }
            else
            {
                MessageBox.Show("El lett pofázva, hogy 1,3 vagy 5 lapot kell választani! Válassz új lapo(ka)t","Szabálytalanság");
                foreach (var item in pictureboxes)
                {
                    item.Image = null;
                }
                kiválaszottlapok.Clear();
            }            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
