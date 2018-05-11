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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace PraktikaWPF1
{
    public partial class Clear : Window
    {
        public Clear()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0);
            dispatcherTimer.Start();
            datetime.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            docnumber.Clear();
            namebox.Clear();
            lastnamebox.Clear();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            datetime.Content = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

            private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Room r in Booking.StaticRoom.Room)
            {
                if(r.Klient != null)
                {
                    if (r.Klient.docnum.Equals(docnumber.Text) && r.Klient.name.Equals(namebox.Text) && r.Klient.lastname.Equals(lastnamebox.Text))
                    {
                        if (MessageBox.Show("You wanna leave?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            r.Status = false;
                            r.Klient = null;
                        }
                    }
                }
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void docnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (Klient r in Booking.StaticKlient.Klient)
            {
                if(r.docnum.Equals(docnumber.Text))
                {
                    namebox.Text = r.name.ToString();
                    lastnamebox.Text = r.lastname.ToString();
                    starttime1.Content = r.start.ToString("dd/MM/yyyy");
                    if(r.end > DateTime.Now)
                    {
                        MessageBox.Show("You late!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        endtime1.Foreground = System.Windows.Media.Brushes.Red;
                        endtime1.Content = r.end.ToString("dd/MM/yyyy");
                    }
                    else if(r.end < DateTime.Now)
                    {
                        MessageBox.Show("You hurry!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        endtime1.Foreground = System.Windows.Media.Brushes.Red;
                        endtime1.Content = r.end.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        endtime1.Content = r.end.ToString("dd/MM/yyyy");
                    }
                }
            }
        }   
    }
}
