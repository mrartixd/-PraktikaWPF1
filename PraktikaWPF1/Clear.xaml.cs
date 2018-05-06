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

namespace PraktikaWPF1
{
    public partial class Clear : Window
    {
        public Clear()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            docnumber.Clear();
            namebox.Clear();
            lastnamebox.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Room r in Booking.StaticRoom.Room)
            {
                if(r.Klient != null)
                {
                    if (r.Klient.docnum.Equals(docnumber.Text) && r.Klient.name.Equals(namebox.Text) && r.Klient.lastname.Equals(lastnamebox.Text))
                    {
                        if (MessageBox.Show("You wanna leave?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            //do no stuff
                        }
                        else
                        {
                            //do yes stuff
                            r.Status = false;
                            r.Klient = null;
                        }

                    }
                }
            }
        }

        private void docnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (Klient r in Booking.StaticKlient.Klient)
            {
                if(r.docnum.Equals(docnumber.Text))
                {
                    namebox.Text = r.name.ToString();
                    lastnamebox.Text = r.lastname.ToString();
                }
            }
        }   
    }
}
