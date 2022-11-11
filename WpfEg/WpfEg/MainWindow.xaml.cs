using WpfEg.Repository;
using System.Diagnostics;
using System.Windows;

namespace SinistrosListarWpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lstUsers.Items.Clear();
            txtBoxAvgTime.Visibility = Visibility.Hidden;
            txtBoxAvgTime.Text = "";
            lblAvgTime.Content = "";
            lblAmount.Content = "";
            // lblCountSinistros.Content = "";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            // lblCountSinistros.Content = "";
            lblAvgTime.Content = "";
            lstUsers.Items.Clear();
            txtBoxAvgTime.Text = "";
            txtBoxAvgTime.Visibility = Visibility.Hidden;
            lblAmount.Content = "";
        }

        private async void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (var item in await UsersRepository.ReadData())
                lstUsers.Items.Add(item);

            stopWatch.Stop();

            lblAvgTime.Content = "Average Time";

            txtBoxAvgTime.Text = stopWatch.ElapsedMilliseconds.ToString();
            txtBoxAvgTime.Visibility =
            txtBoxAvgTime.Visibility = Visibility.Visible;
            stopWatch.Reset();

            // lblCountSinistros.Content = $"There is: {lstSinistros.Items.Count.ToString()} lines on your search";
        }

        private void lstUsers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            lblAmount.Content = $"Qtd Selecionada:\n{lstUsers.SelectedItems.Count.ToString()}";
        }
    }
}
