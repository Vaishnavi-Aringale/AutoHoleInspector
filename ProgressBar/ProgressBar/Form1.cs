using System;
using System.Windows.Forms;

namespace ProgressBar
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void setTimerStatus(bool status)
        {
            timer1.Enabled = status;
        }

        public void setProgressLabel(string labelText)
        {
            label1.Text = labelText;
        }

        public void setSetpSize(int stepSize)
        {
            progressBar1.Step = stepSize;
        }
        public void setInterval(double secs)
        {
            timer1.Interval = (int)(1000 * secs);
        }

        public void incrementProgressBar()
        {
            progressBar1.PerformStep();
            label2.Text = progressBar1.Value.ToString() + "%";
            if (progressBar1.Value >= 100)
            {
                label1.Text = "Features Extracted Successfully!";
                this.Close();
            }
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (progressBar1.Value >= 100)
            {
                label2.Text = "100%";
            }
            else
                label2.Text = string.Format("{0:0}%", progressBar1.Value);
        }
    }
}
