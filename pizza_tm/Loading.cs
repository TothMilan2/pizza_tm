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
       
    

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Start the timer that updates the progress bar.
            timer2.Start();

            // Start asynchronous label animation concurrently.
            await AnimateLabelsAsync();
        }





        private void timer1_Tick(object sender, EventArgs e)
        {
      
            timer1.Enabled = true;
            progressBar1.Increment(24);

            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
          
                Form1 form = new Form1();
                form.Show();
                this.Hide();
                
            }
            if (progressBar1.Value >= 25)
                label2.Visible = true;

            if (progressBar1.Value >= 50)
                label5.Visible = true;

            if (progressBar1.Value >= 75)
                label6.Visible = true;

            
        }

 

        private void timer3_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            timer2.Enabled = true;  
     

           









        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private async Task AnimateLabelsAsync()
        {
            // Loop until the progress bar is complete.
            while (progressBar1.Value < 100)
            {
                // Show label1 for 2 seconds.
                label2.Visible = true;
                await Task.Delay(2000);
                label2.Visible = false;

                // Check if the progress is complete before moving on.
                if (progressBar1.Value >= 100)
                    break;

                // Show label2 for 2 seconds.
                label5.Visible = true;
                await Task.Delay(2000);
                label5.Visible = false;

                if (progressBar1.Value >= 100)
                    break;

                // Show label3 for 2 seconds.
                label6.Visible = true;
                await Task.Delay(2000);
                label6.Visible = false;
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }
    }
}
