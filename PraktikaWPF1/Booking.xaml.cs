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
    /// <summary>
    /// Логика взаимодействия для Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        public Booking()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        static Room room1 = new Room();
        static Room room2 = new Room();
        static Room room3 = new Room();
        static Room room4 = new Room();



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            room1 = new Room("Room#1", 1, null, 2, "A", false);
            room2 = new Room("Room#2", 2, null, 2, "B", false);
            room3 = new Room("Room#3", 3, null, 1, "B", false);
            room4 = new Room("Room#4", 4, null, 1, "A", false);
        }

     
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ChangePictures(room1, door1);
            ChangePictures(room2, door2);
            ChangePictures(room3, door3);
            ChangePictures(room4, door4);
        }


        private void ChangePictures(Room room, Image image)
        {
            if (room.Status == true)
            {
                image.Source = redkey.Source;

            }
            else if (room.Status == false)
            {
                image.Source = greenkey.Source;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name.Clear();
            last.Clear();
            numberdoc.Clear();
            telephone.Clear();
            
        }
    }
}
