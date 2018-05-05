using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Booking : Window
    {
        public Booking()
        {
            InitializeComponent();
            
        }
        static MainWindow main = new MainWindow();
        static List<Klient> klient = new List<Klient>();
        static List<Room> room = new List<Room>();
        static System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();


      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            room.Add(new Room("Room#1", 0, null, 2, "A", false));
            room.Add(new Room("Room#2", 1, null, 2, "B", false));
            room.Add(new Room("Room#3", 2, null, 1, "B", false));
            room.Add(new Room("Room#4", 3, null, 1, "A", false));
            room.Add(new Room("Room#5", 4, null, 2, "C", false));
            room.Add(new Room("Room#6", 5, null, 1, "C", false));
            room.Add(new Room("Room#7", 6, null, 2, "A", false));
            room.Add(new Room("Room#8", 7, null, 3, "A", false));
            room.Add(new Room("Room#9", 8, null, 1, "B", false));

            for (int i = 0; i < room.Count; i++)
            {
                if (!rooms.Items.Contains(RoomText(room[i])))
                    rooms.Items.Add(RoomText(room[i]));

            }
            
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private String RoomText(Room room)
        {
           return room.NameRoom + " rooms: " + room.Beds + " Class: " + room.ClassRoom; 
        }
     
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ChangePictures(room[0], door1);
            ChangePictures(room[1], door2);
            ChangePictures(room[2], door3);
            ChangePictures(room[3], door4);
            ChangePictures(room[4], door5);
            ChangePictures(room[5], door6);
            ChangePictures(room[6], door7);
            ChangePictures(room[7], door8);
            ChangePictures(room[8], door9);
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
            rooms.SelectedIndex = -1;
            starttime.SelectedDate = null;
            endtime.SelectedDate = null;
            agreebox.IsChecked = false;  
        }

       
    

        private void book_Click(object sender, RoutedEventArgs e)
        {
            if(name.Equals(null) || last.Equals(null) || numberdoc.Equals(null) || telephone.Equals(null) || rooms.SelectedIndex == -1)
            {
                MessageBox.Show("Field box empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            else
            {
                if (agreebox.IsChecked == true && room[rooms.SelectedIndex].Status == false)
                {
                    room[rooms.SelectedIndex].Status = true;
                    Klient kl = new Klient(name.Text, last.Text, telephone.Text, numberdoc.Text, starttime.SelectedDate.Value, endtime.SelectedDate.Value);
                    room[rooms.SelectedIndex].Klient = kl;
                    klient.Add(kl);
                    MessageBox.Show("Welcome", "Success", MessageBoxButton.OK,MessageBoxImage.Information);
                }
                else if (agreebox.IsChecked == false)
                {
                    MessageBox.Show("Check agree state", "Agree book room", MessageBoxButton.OK,MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Room booked", "Book room", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        // mouse hover
        private void door1_MouseEnter(object sender, MouseEventArgs e)
        {
            nameroom.Content = room[0].NameRoom.ToString();
            classroom.Content = room[0].ClassRoom.ToString();
            numberroom.Content = room[0].Beds.ToString();
            if(room[0].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked";
            }
            
        }

        private void door1_MouseLeave(object sender, MouseEventArgs e)
        {
            nameroom.Content = "name room";
            classroom.Content = "class room";
            numberroom.Content = "bed number";
            statusbook.Content = "status";
            
        }

        private void door2_MouseEnter(object sender, MouseEventArgs e)
        {
            nameroom.Content = room[1].NameRoom.ToString();
            classroom.Content = room[1].ClassRoom.ToString();
            numberroom.Content = room[1].Beds.ToString();
            if (room[1].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked";
            }

        }

        private void door2_MouseLeave(object sender, MouseEventArgs e)
        {
            nameroom.Content = "name room";
            classroom.Content = "class room";
            numberroom.Content = "bed number";
            statusbook.Content = "status";

        }

        private void door3_MouseEnter(object sender, MouseEventArgs e)
        {
            nameroom.Content = room[2].NameRoom.ToString();
            classroom.Content = room[2].ClassRoom.ToString();
            numberroom.Content = room[2].Beds.ToString();
            if (room[2].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked";
            }

        }

        private void door3_MouseLeave(object sender, MouseEventArgs e)
        {
            nameroom.Content = "name room";
            classroom.Content = "class room";
            numberroom.Content = "bed number";
            statusbook.Content = "status";

        }

        private void door4_MouseEnter(object sender, MouseEventArgs e)
        {
            nameroom.Content = room[3].NameRoom.ToString();
            classroom.Content = room[3].ClassRoom.ToString();
            numberroom.Content = room[3].Beds.ToString();
            if (room[3].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked";
            }

        }

        private void door4_MouseLeave(object sender, MouseEventArgs e)
        {
            nameroom.Content = "name room";
            classroom.Content = "class room";
            numberroom.Content = "bed number";
            statusbook.Content = "status";

        }

        private void door5_MouseEnter(object sender, MouseEventArgs e)
        {
            nameroom.Content = room[4].NameRoom.ToString();
            classroom.Content = room[4].ClassRoom.ToString();
            numberroom.Content = room[4].Beds.ToString();
            if (room[4].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked";
            }

        }

        private void door5_MouseLeave(object sender, MouseEventArgs e)
        {
            nameroom.Content = "name room";
            classroom.Content = "class room";
            numberroom.Content = "bed number";
            statusbook.Content = "status";

        }

        private void door6_MouseEnter(object sender, MouseEventArgs e)
        {
            nameroom.Content = room[5].NameRoom.ToString();
            classroom.Content = room[5].ClassRoom.ToString();
            numberroom.Content = room[5].Beds.ToString();
            if (room[5].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked";
            }

        }

        private void door6_MouseLeave(object sender, MouseEventArgs e)
        {
            nameroom.Content = "name room";
            classroom.Content = "class room";
            numberroom.Content = "bed number";
            statusbook.Content = "status";

        }

        private void door7_MouseEnter(object sender, MouseEventArgs e)
        {
            nameroom.Content = room[6].NameRoom.ToString();
            classroom.Content = room[6].ClassRoom.ToString();
            numberroom.Content = room[6].Beds.ToString();
            if (room[6].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked";
            }

        }

        private void door7_MouseLeave(object sender, MouseEventArgs e)
        {
            nameroom.Content = "name room";
            classroom.Content = "class room";
            numberroom.Content = "bed number";
            statusbook.Content = "status";

        }

        private void door8_MouseEnter(object sender, MouseEventArgs e)
        {
            nameroom.Content = room[7].NameRoom.ToString();
            classroom.Content = room[7].ClassRoom.ToString();
            numberroom.Content = room[7].Beds.ToString();
            if (room[7].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked";
            }

        }

        private void door8_MouseLeave(object sender, MouseEventArgs e)
        {
            nameroom.Content = "name room";
            classroom.Content = "class room";
            numberroom.Content = "bed number";
            statusbook.Content = "status";

        }

        private void door9_MouseEnter(object sender, MouseEventArgs e)
        {
            nameroom.Content = room[8].NameRoom.ToString();
            classroom.Content = room[8].ClassRoom.ToString();
            numberroom.Content = room[8].Beds.ToString();
            if (room[8].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked";
            }

        }

        private void door9_MouseLeave(object sender, MouseEventArgs e)
        {
            nameroom.Content = "name room";
            classroom.Content = "class room";
            numberroom.Content = "bed number";
            statusbook.Content = "status";

        }

    }
}
