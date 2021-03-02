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

namespace Calculator
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

        private void Btn_0(object sender, RoutedEventArgs e)
        {
            Input.Text += 0;
        }
        private void Btn_1(object sender, RoutedEventArgs e)
        {
            Input.Text += 1;
        }
        private void Btn_2(object sender, RoutedEventArgs e)
        {
            Input.Text += 2;
        }
        private void Btn_3(object sender, RoutedEventArgs e)
        {
            Input.Text += 3;
        }
        private void Btn_4(object sender, RoutedEventArgs e)
        {
            Input.Text += 4;
        }
        private void Btn_5(object sender, RoutedEventArgs e)
        {
            Input.Text += 5;
        }
        private void Btn_6(object sender, RoutedEventArgs e)
        {
            Input.Text += 6;
        }
        private void Btn_7(object sender, RoutedEventArgs e)
        {
            Input.Text += 7;
        }
        private void Btn_8(object sender, RoutedEventArgs e)
        {
            Input.Text += 8;
        }
        private void Btn_9(object sender, RoutedEventArgs e)
        {
            Input.Text += 9;
        }

        private void Btn_Plus(object sender, RoutedEventArgs e)
        {
            UseSign('+');
        }
        private void Btn_Minus(object sender, RoutedEventArgs e)
        {
            UseSign('-');
        }

        private void Btn_Multiple(object sender, RoutedEventArgs e)
        {
            UseSign('*');
        }

        private void Btn_Division(object sender, RoutedEventArgs e)
        {
            UseSign('/');
        }

        private double result = 0;
        char sign = Char.MinValue;

        private void Btn_Equal(object sender, RoutedEventArgs e)
        {
            Calculate();
            Current.Text = result.ToString();
            Input.Text = "";
            result = 0;
            sign = Char.MinValue;
        }
        private void Btn_Clear(object sender, EventArgs e)
        {
            Input.Text = "";
            Current.Text = "";
            result = 0;
            sign = Char.MinValue;

        }
        private void UseSign(char ch)
        {
            if (sign == Char.MinValue)
            {
                Current.Text = "";
                result = (Input.Text == "") ? 0 : Double.Parse(Input.Text);
                Current.Text = result.ToString();
                sign = ch;
                Input.Text = "";
            }
            else
            {
                Calculate();
                sign = ch;
                Current.Text = result.ToString();
                Input.Text = "";
            }
        }

        private void Calculate()
        {
            switch (sign)
            {
                case '+':
                    result += Double.Parse(Input.Text);
                    break;
                case '-':
                    result -= Double.Parse(Input.Text);
                    break;
                case '*':
                    result *= Double.Parse(Input.Text);
                    break;
                case '/':
                    result /= Double.Parse(Input.Text);
                    break;
                default:
                    break;
            }
        }

    }
}
