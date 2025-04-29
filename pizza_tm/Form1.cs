using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pizza_tm
{
    public partial class Form1 : Form
    {
        public static List <string> p_nev=new List <string> ();
        public static List <string> p_forint=new List <string> ();
        public static List <int> p_ar=new List <int> ();
        int plusszar = 0;
        public static string[] adatok = new string[0]; 

        public Form1()
        {
            InitializeComponent();
            string FilePath= "pizza.txt";
            try
            {
                using(StreamReader reader=new StreamReader(FilePath))
                {
                    string line;
                    
                    while ((line = reader.ReadLine()) != null)
                    {
                        adatok = line.Split('|');
                        p_nev.Add(adatok[0]);
                        p_ar.Add(Convert.ToInt32(adatok[1]));
                        p_forint.Add(adatok[2]);
                        


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
            for(int i = 0; i < p_nev.Count; i++)
            {
                comboBox1.Items.Add(p_nev[i] + " " + p_ar[i] + p_forint[i]);
               
            }
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            int index=0;
            string combo=comboBox1.SelectedItem.ToString();

            string name = adatok[0];

            for(int i = 0;i < p_nev.Count; i++)
            {
                if (combo == p_nev[i])
                {

                    index = i;
                    listBox1.Items.Add(p_nev[i]);
                }
            }
            

            

            // Hozzáadjuk a ListBox-hoz
           

            //I give up there is no hope

            for (int i = 0;i<p_nev.Count;i++)
            {
                if (fullName == p_nev[i] && radioButton2.Checked)
                {
                   
                    

                }
                else if(fullName == p_nev[i] && radioButton1.Checked)
                {
              
                    index = i;


                    listBox1.Items.Add("-"+p_nev[index] + ' ' + p_ar[index] + ' ' + p_forint[index] + ", " + "24cm");
                }
                /*Ha kettőt választunk ugyan abból a fajtából az árat tovább növeli */

            }
            

        }

        private void mentésToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string megjegyzes = textBox1.Text.ToString();
            string filePath2 = "rendeles.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath2))
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        writer.WriteLine(listBox1.Items[i]);
                    }
                    writer.WriteLine($"Megjegyzés: {megjegyzes}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Helo");
            }
        }

        private void törlésToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mentésMáskéntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Filter tulajdonság a menthető fájltípusok megadásához
            saveFileDialog1.Filter = "Szöveges fájl (*.txt)|*.txt|Minden fájl (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1; //DefaultExt tulajdonságot az alapértelmezett fájlkiterjesztés megadásához
            saveFileDialog1.DefaultExt = "txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            { // Fájl mentése a saveFileDialog1.FileName útvonalra
                string megjegyzes = textBox1.Text.ToString();
                string filePath2 = "rendeles.txt";
                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath2))
                    {
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            writer.WriteLine(listBox1.Items[i]);
                        }
                        writer.WriteLine($"Megjegyzés: {megjegyzes}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Helo");
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void névjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void kapcsolatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void szövegtípusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rendelésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nevjegy form2 = new nevjegy();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
        
    
    
}
