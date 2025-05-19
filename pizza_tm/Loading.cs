using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pizza_tm
{
    public partial class Loading : Form
    {
      
        public Loading()
        {
            InitializeComponent();
            progressBar1.Margin = new Padding(0);
            progressBar1.Padding = new Padding(0);
            timer1.Start();
         
            label2.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            timer2.Start();


        }

    



        private void timer1_Tick(object sender, EventArgs e)
        {
      
            timer1.Enabled = true;
            progressBar1.Increment(2);

            if (progressBar1.Value == 100)
            {
                timer1 .Enabled = false;
          
                Form1 form = new Form1();
                form.Show();
                this.Hide();
                
            }
        }

 

        private void timer3_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
                timer2.Enabled = true;



            if (progressBar1.Value >= 20)
                label2.Visible = true;

            if (progressBar1.Value >= 50)
                label5.Visible = true;

            if (progressBar1.Value >= 80)
                label6.Visible = true;

            if (progressBar1.Value >= 100)
                timer2.Enabled = false;









        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
