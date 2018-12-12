using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App1
{
    public class Client : INotifyPropertyChanged
    {
        
        private string surname;
        private int id;
        private string initials;
        private int room;

       // public static int CountCLients = 0;
        public int Id{
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                  //  OnPropertyChanged("Surname");
                }
            }
        }         
        public Client(string surname, string initials, int room)
        {
            Surname = surname;
            Initials = initials;
            Room = room;
        }

        public string Surname {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }

        public string Initials
        {
            get { return initials; }
            set
            {
                if (initials != value)
                {
                    initials = value;
                    OnPropertyChanged("Initials");
                }
            }
        }
      
        public int Room {
            get { return room; }
            set
            {
                if (room != value)
                {
                    room = value;
                    OnPropertyChanged("Room");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
