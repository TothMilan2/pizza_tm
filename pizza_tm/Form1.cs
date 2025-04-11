using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pizza_tm
{
    public partial class Form1 : Form
    {
        public static List <string> p_nev=new List <string> ();
        public static List <string> p_forint=new List <string> ();
        public static List <int> p_ar=new List <int> ();
        public Form1()
        {
            InitializeComponent();
            string FilePath= "pizza.txt";
            try
            {
                using(StreamReader reader=new StreamReader(FilePath))
                {
                    string line;
                    reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] adatok = line.Split('|');
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
            string[] szabdalt = combo.Split(' ');
            string pizzaneve = szabdalt[0];



            for(int i = 0;i<p_nev.Count;i++)
            {
                if (pizzaneve == p_nev[i] && radioButton2.Checked)
                {
                    index = i;
                    listBox1.Items.Add(p_nev[index]+' '+ p_ar[index]+' '+ p_forint[index]);

                }
                /*Megcsinálni */

            }
            

        }


    }
}
