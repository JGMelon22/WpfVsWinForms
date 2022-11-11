using System;
using System.Diagnostics;
using System.Windows.Forms;
using WinFormsEg.Repository;

namespace WinFormsListarSinistrosDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtQuantity.Enabled = false;
            lstUsers.Items.Clear();
            lblCaptionAvgAmount.Text = "";
            txtQuantity.Text = "";
            txtQuantity.Hide();
            lblAmount.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lstUsers.Items.Clear();
            lblCaptionAvgAmount.Text = "";
            txtQuantity.Text = "";
            txtQuantity.Hide();
            lblAmount.Text = "";
        }

        private async void btnCarga_Click(object sender, EventArgs e)
        {
            lblCaptionAvgAmount.Text = $"Average Time{Environment.NewLine}in seconts:";

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (var item in await UsersRepository.ReadData())
                lstUsers.Items.Add(item);

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            txtQuantity.Show();
            txtQuantity.Text = Math.Round(ts.TotalSeconds, 2).ToString();
            //txtQuantity.Text = ts.TotalMilliseconds.ToString();
        }


        private void lstUsers_Click(object sender, EventArgs e)
        {
            lblAmount.Text = $"Selecteds: {lstUsers.SelectedIndices.Count.ToString()}";
        }
    }
}
