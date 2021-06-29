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

namespace Calculator_In_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double resultValue = 0;
        string text = "";
        bool isPerformed = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if ((resultTxt.Text == "0") || (isPerformed))
            {
                resultTxt.Clear();
            }
            isPerformed = false;
            Button button = (Button)sender;
            if (button.Content.ToString() == ",")
            {
                if (!resultTxt.Text.Contains(","))
                {
                    resultTxt.Text = resultTxt.Text + button.Content;
                }
            }
            else
            {
                resultTxt.Text = resultTxt.Text + button.Content;
            }
        }

        private void ceBtn_Click(object sender, RoutedEventArgs e)
        {
            resultTxt.Text = "0";
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            resultTxt.Text = "0";
            resultValue = 0;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxt.Text.Length > 0)
            {
                resultTxt.Text = resultTxt.Text.Remove(resultTxt.Text.Length - 1, 1);
            }
        }

        private void operator_click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (resultTxt.Text.EndsWith("*") || resultTxt.Text.EndsWith("+") || resultTxt.Text.EndsWith("-") || resultTxt.Text.EndsWith("/"))
            {
                return;
            }
            else
            {
                if (resultValue != 0)
                {
                    text = button.Content.ToString();
                    resultValue = double.Parse(resultTxt.Text);
                    resultTxt.Text += text;
                    exResultLbl.Content = resultValue + " " + text;
                    isPerformed = true;
                }
                else
                {
                    text = button.Content.ToString();
                    resultValue = double.Parse(resultTxt.Text);
                    resultTxt.Text += text;
                    exResultLbl.Content = resultValue + " " + text;
                    isPerformed = true;
                }
            }
        }

        private void equalBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (text)
                {
                    case "+":
                        resultTxt.Text = (resultValue + double.Parse(resultTxt.Text)).ToString();
                        resultValue = 0;
                        break;
                    case "-":
                        resultTxt.Text = (resultValue - double.Parse(resultTxt.Text)).ToString();
                        resultValue = 0;
                        break;
                    case "*":
                        resultTxt.Text = (resultValue * double.Parse(resultTxt.Text)).ToString();
                        resultValue = 0;
                        break;
                    case "/":
                        if (resultTxt.Text != "0")
                        {
                            resultTxt.Text = (resultValue / double.Parse(resultTxt.Text)).ToString();
                            resultValue = 0;
                        }
                        else
                        {
                            MessageBox.Show("Cannot devide by zero");
                        }
                        break;
                }
                resultValue = double.Parse(resultTxt.Text);
                exResultLbl.Content = "";
                isPerformed = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void plusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((double.Parse(resultTxt.Text)) >= 0)
            {
                resultTxt.Text = (System.Math.Abs(double.Parse(resultTxt.Text)) * (-1)).ToString();
            }
            else
            {
                resultTxt.Text = (System.Math.Abs(double.Parse(resultTxt.Text)) * (1)).ToString();
            }
        }
    }
}
