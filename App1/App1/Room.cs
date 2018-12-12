using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace App1
{
    public class Room : INotifyPropertyChanged
    {
    
        private int freePlace;
        public static int uniqueID;

        public int Number { get; set; }
        public RoomCapacity Capacity { get; set; } 
        public int FreePlace
        {
            get { return freePlace; }
            set
            {
                if (freePlace != value)
                {
                    freePlace = value;
                    OnPropertyChanged("FreePlace");
                }
            }
        }
        public ObservableCollection<Client> Clients { get; set; }

        public Room(int number, RoomCapacity capacity)
        {
            Number = number;
            Capacity = capacity;
            Clients = new ObservableCollection<Client>();
            FreePlace = (capacity == RoomCapacity.SINGLE) ? 1 : 2;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void AddClient(Client newClient)
        {
            if (FreePlace > 0)
            {
                uniqueID++;
                newClient.Id = uniqueID;
                Clients.Add(newClient);
                FreePlace--;
            }
        }
        public   void RemoveClient(int  ClientIndex)
        {
            foreach (var item in Clients)
            {
                if (item.Id == ClientIndex)
                {
                    Clients.Remove(item);
                    break;
                }
            }
            FreePlace++;
        }
    }


    public enum RoomCapacity
    {
        NOTEMPTY = 0,
        SINGLE = 1,
        DOUBLE = 2
    };

}
