using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double r;
            double n;
            double answer;
            bool validateimputs = true;
            double CBmultpilier = 1;
            string combo;
            r = ((double.Parse(Text_APR.Text) / 100) / 12);
            n = (double.Parse(Text_YTBP.Text) * 12);

            if (
                !double.TryParse(Text_APR.Text, out double n1) ||
                !double.TryParse(Text_YTBP.Text, out double r2) ||
                !double.TryParse(Text_Mort.Text, out double Mort1) ||
                !double.TryParse(Text_DP.Text, out double DP1)
                )
            {
                MessageBox.Show("Please enter numbers for each field");
                validateimputs = false;
            }
            else
            {
                validateimputs = true;
            }



            if (validateimputs)
            { 
                answer = (double.Parse(Text_Mort.Text) - double.Parse(Text_DP.Text)) * ((r * (Math.Pow((1 + r), n))) / ((Math.Pow((1 + r), n)) - 1));

                combo = Monthly_combo.SelectionBoxItem as string;

                switch(combo)
                {
                    case "Monthly":
                        CBmultpilier = 1;
                            break;
                    case "Yearly":
                        CBmultpilier = 12;
                            break;
                }


                Label_Monthly.Content = answer * CBmultpilier;
                Window1 Calculation = new Window1(answer);

                Calculation.ShowDialog();
            }
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow Help = new HelpWindow();

            Help.ShowDialog();
        }

        
    }
}
