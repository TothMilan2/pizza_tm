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
        public static List<string> p_nev = new List<string>();
        public static List<string> p_forint = new List<string>();
        public static List<int> p_ar = new List<int>();
        int plusszar = 0;
        public static string[] adatok = new string[0];
        private bool backgroundSet = false;
   
        public Form1()
        {

            InitializeComponent();


      string FilePath = "pizza.txt";
            try
            {
                using (StreamReader reader = new StreamReader(FilePath))
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
                MessageBox.Show(ex.Message);
            }
            for (int i = 0; i < p_nev.Count; i++)
            {
                comboBox1.Items.Add(p_nev[i] + " " + p_ar[i] + p_forint[i]);

            }
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(2, 2, button2.Width - 5, button2.Height - 8);
            button2.Region = new Region(p);
           
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            int index = 0;
            string combo = comboBox1.SelectedItem.ToString();
            string[] levagott = combo.Split(' ');

            //Mennyiség:
            int mennyiseg = Convert.ToInt32(numericUpDown1.Value);
            int plusszar = 0;


            for (int i = 0; i < p_nev.Count; i++)
            {
                if (p_nev[i] == levagott[0])
                {
                    index = i;
                    if (mennyiseg != 0 && radioButton1.Checked)
                    {
                        listBox1.Items.Add("- "+p_nev[index] + " " + mennyiseg + " " + "db" + "24cm" + " " + p_ar[index] * mennyiseg + " " + p_forint[i]);
                    }

                    else if (mennyiseg != 0 && radioButton2.Checked)
                    {
                        listBox1.Items.Add("- " + p_nev[index] + " " + mennyiseg + " " + "db" + "32cm" + " " + p_ar[index] * mennyiseg * 1.5 + " " + p_forint[i]);
                    }
                    else if (!radioButton1.Checked && !radioButton2.Checked)
                    {
                        MessageBox.Show("Nem adott meg méretet vagy mennyiséget!");
                    }


                }

            }





            // Hozzáadjuk a ListBox-hoz


            //I give up there is no hope


            /*Ha kettőt választunk ugyan abból a fajtából az árat tovább növeli */

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
                    MessageBox.Show("Mentve");
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
            listBox1.Items.Clear();
            numericUpDown1.Value = 0;
            comboBox1.SelectedItem = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Text = string.Empty;

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

        private void szövegtípusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                // If the user selects a font and clicks OK
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    // Loop through all controls on the form
                    foreach (Control control in this.Controls)
                    {
                        // Apply the selected font to each control that supports it
                        listBox1.Font = fontDialog.Font;
                    }
                }
            }
        }

        private void háttérszínToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundSet != true)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.BackColor = colorDialog1.Color;
                    if (colorDialog1.Color == Color.Black)
                    {

                        label2.ForeColor = Color.White;
                        label3.ForeColor = Color.White;
                        label4.ForeColor = Color.White;
                        label5.ForeColor = Color.White;
                        label6.ForeColor = Color.White;
                        radioButton1.ForeColor = Color.White;
                        radioButton2.ForeColor = Color.White;
                    }
                    if (colorDialog1.Color == Color.White)
                    {

                        label2.ForeColor = Color.Black;
                        label3.ForeColor = Color.Black;
                        label4.ForeColor = Color.Black;
                        label5.ForeColor = Color.Black;
                        label6.ForeColor = Color.Black;
                        radioButton1.ForeColor = Color.Black;
                        radioButton2.ForeColor = Color.Black;
                    }

                }
            }
            else
            {
                MessageBox.Show("Már van háttér!");
            }
            
        }

        private void háttérképToolStripMenuItem_Click(object sender, EventArgs e)
        {
                    
        openFileDialog1.Filter = "Képek (*.png)|*.png|Minden fájl (*.*)|*.*";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.Multiselect = true;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileName in openFileDialog1.FileNames)
                        { // Fájl feldolgozása

                        }
                        this.BackgroundImage = Image.FromFile(openFileDialog1.FileNames[0]);
                        backgroundSet = true;
            }
                
                
        }

        private void rendelésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Szöveges fájlok (*.txt)|*.txt|Minden fájl (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;

                try
                {
                    // Read all lines from the file
                    string[] lines = File.ReadAllLines(filePath);

                    // Add each line of the file to the ListBox
                    listBox1.Items.Clear();  // Clear previous items
                    foreach (string line in lines)
                    {
                        listBox1.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading the file: " + ex.Message);
                }
            }
        }

        private void súgóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Válassza ki pizzáját \n" +
                "2. Véglegesítse\n" +
                "3. Mentse el a fájlra kattintva\n"+"4. Erősen ajánlott a kilépés gombra kattintani a teljes programleállás érdekében!");
        }

        private void menüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (listBox1.SelectedItems.Count > 0)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }

        }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void Shutdown()
    {


      // Now exit the application completely
      Environment.Exit(0);  // Forces the process to exit immediately
    }
    private void button3_Click(object sender, EventArgs e)
    {
      Shutdown(); // Your cleanup method
    }
   
    
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      
    }
  }
   




}
