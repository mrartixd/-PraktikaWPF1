﻿using System;
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

        public class StaticKlient
        {
            private static List<Klient> klient = new List<Klient>();
            
            internal static List<Klient> Klient { get => klient; set => klient = value; }
        }
        public class StaticRoom
        {
            private static List<Room> room = new List<Room>();

            internal static List<Room> Room { get => room; set => room = value; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            StaticRoom.Room.Add(new Room("Room#1", 0, null, 2, "A", false));
            StaticRoom.Room.Add(new Room("Room#2", 1, null, 2, "B", false));
            StaticRoom.Room.Add(new Room("Room#3", 2, null, 1, "B", false));
            StaticRoom.Room.Add(new Room("Room#4", 3, null, 1, "A", false));
            StaticRoom.Room.Add(new Room("Room#5", 4, null, 2, "C", false));
            StaticRoom.Room.Add(new Room("Room#6", 5, null, 1, "C", false));
            StaticRoom.Room.Add(new Room("Room#7", 6, null, 2, "A", false));
            StaticRoom.Room.Add(new Room("Room#8", 7, null, 3, "A", false));
            StaticRoom.Room.Add(new Room("Room#9", 8, null, 1, "B", false));
            for (int i = 0; i < StaticRoom.Room.Count; i++)
            {
                if (!rooms.Items.Contains(RoomText(StaticRoom.Room[i])))
                    rooms.Items.Add(RoomText(StaticRoom.Room[i]));

            }
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
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
            ChangePictures(StaticRoom.Room[0], door1);
            ChangePictures(StaticRoom.Room[1], door2);
            ChangePictures(StaticRoom.Room[2], door3);
            ChangePictures(StaticRoom.Room[3], door4);
            ChangePictures(StaticRoom.Room[4], door5);
            ChangePictures(StaticRoom.Room[5], door6);
            ChangePictures(StaticRoom.Room[6], door7);
            ChangePictures(StaticRoom.Room[7], door8);
            ChangePictures(StaticRoom.Room[8], door9);
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
                if (agreebox.IsChecked == true && StaticRoom.Room[rooms.SelectedIndex].Status == false)
                {
                    StaticRoom.Room[rooms.SelectedIndex].Status = true;
                    Klient kl = new Klient(name.Text, last.Text, telephone.Text, numberdoc.Text, starttime.SelectedDate.Value, endtime.SelectedDate.Value);
                    StaticKlient.Klient.Add(kl);
                    StaticRoom.Room[rooms.SelectedIndex].Klient = kl;
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
            nameroom.Content = StaticRoom.Room[0].NameRoom.ToString();
            classroom.Content = StaticRoom.Room[0].ClassRoom.ToString();
            numberroom.Content = StaticRoom.Room[0].Beds.ToString();
            if(StaticRoom.Room[0].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked by: "+StaticRoom.Room[0].Klient.name + " "+ StaticRoom.Room[0].Klient.lastname;
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
            nameroom.Content = StaticRoom.Room[1].NameRoom.ToString();
            classroom.Content = StaticRoom.Room[1].ClassRoom.ToString();
            numberroom.Content = StaticRoom.Room[1].Beds.ToString();
            if (StaticRoom.Room[1].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked by: " + StaticRoom.Room[1].Klient.name + " " + StaticRoom.Room[1].Klient.lastname;
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
            nameroom.Content = StaticRoom.Room[2].NameRoom.ToString();
            classroom.Content = StaticRoom.Room[2].ClassRoom.ToString();
            numberroom.Content = StaticRoom.Room[2].Beds.ToString();
            if (StaticRoom.Room[2].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked by: " + StaticRoom.Room[2].Klient.name + " " + StaticRoom.Room[2].Klient.lastname;
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
            nameroom.Content = StaticRoom.Room[3].NameRoom.ToString();
            classroom.Content = StaticRoom.Room[3].ClassRoom.ToString();
            numberroom.Content = StaticRoom.Room[3].Beds.ToString();
            if (StaticRoom.Room[3].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked by: " + StaticRoom.Room[3].Klient.name + " " + StaticRoom.Room[3].Klient.lastname;
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
            nameroom.Content = StaticRoom.Room[4].NameRoom.ToString();
            classroom.Content = StaticRoom.Room[4].ClassRoom.ToString();
            numberroom.Content = StaticRoom.Room[4].Beds.ToString();
            if (StaticRoom.Room[4].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked by: " + StaticRoom.Room[4].Klient.name + " " + StaticRoom.Room[4].Klient.lastname;
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
            nameroom.Content = StaticRoom.Room[5].NameRoom.ToString();
            classroom.Content = StaticRoom.Room[5].ClassRoom.ToString();
            numberroom.Content = StaticRoom.Room[5].Beds.ToString();
            if (StaticRoom.Room[5].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked by: " + StaticRoom.Room[5].Klient.name + " " + StaticRoom.Room[5].Klient.lastname;
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
            nameroom.Content = StaticRoom.Room[6].NameRoom.ToString();
            classroom.Content = StaticRoom.Room[6].ClassRoom.ToString();
            numberroom.Content = StaticRoom.Room[6].Beds.ToString();
            if (StaticRoom.Room[6].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked by: " + StaticRoom.Room[6].Klient.name + " " + StaticRoom.Room[6].Klient.lastname;
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
            nameroom.Content = StaticRoom.Room[7].NameRoom.ToString();
            classroom.Content = StaticRoom.Room[7].ClassRoom.ToString();
            numberroom.Content = StaticRoom.Room[7].Beds.ToString();
            if (StaticRoom.Room[7].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked by: " + StaticRoom.Room[7].Klient.name + " " + StaticRoom.Room[7].Klient.lastname;
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
            nameroom.Content = StaticRoom.Room[8].NameRoom.ToString();
            classroom.Content = StaticRoom.Room[8].ClassRoom.ToString();
            numberroom.Content = StaticRoom.Room[8].Beds.ToString();
            if (StaticRoom.Room[8].Status == false)
            {
                statusbook.Content = "Empty";
            }
            else
            {
                statusbook.Content = "Booked by: " + StaticRoom.Room[8].Klient.name + " " + StaticRoom.Room[8].Klient.lastname;
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
