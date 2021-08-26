using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ImageView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetImage(string url, bool reset = false)
        {
            if (reset)
            {
                Lbl_error.Content = "";
                Img_main.Visibility = Visibility.Hidden;
            }
            else
            {
                if (url.Length <= 0 || !Regex.IsMatch(url, @"([A-z]+)\.([A-z]+)", RegexOptions.IgnoreCase))
                {
                    Lbl_error.Content = "Invalid URL!";
                }
                else
                {
                    try
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(url, UriKind.Absolute);
                        bitmap.EndInit();
                        Img_main.Source = bitmap;
                        if (Img_main.Visibility == Visibility.Hidden)
                        {
                            Img_main.Visibility = Visibility.Visible;
                        }
                        Lbl_error.Content = "";
                    }
                    catch (UriFormatException)
                    {
                        Lbl_error.Content = "Invalid Image! I cannot upload a picture!";
                    }
                    catch
                    {
                        Lbl_error.Content = "Unknow error!";
                    }
                }
            }
        }

        private void Btn_start_Click(object sender, RoutedEventArgs e)
        {
            string fullFilePath = Txtbox_input.Text;
            SetImage(fullFilePath);
        }

        private void Btn_reset_Click(object sender, RoutedEventArgs e)
        {
            SetImage("", true);
        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_author_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/winsomequill/");
        }
    }
}
