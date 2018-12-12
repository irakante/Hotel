using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
namespace App1
{
    public partial class MainPage : ContentPage
    {
        public Room selectedRoomListItem;
        public Client currentClient;
        public ObservableCollection<Room> Rooms { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Rooms = new ObservableCollection<Room>();
            for(int i = 0; i < 5; i++)
            {
                var room = new Room(i, RoomCapacity.SINGLE);
                Rooms.Add(room);
            }
            for (int i = 5; i < 15; i++)
            {
                var room = new Room(i, RoomCapacity.DOUBLE);
                Rooms.Add(room);
            }
            this.BindingContext = this;
        }
        // добавление клиента
        // вспомогательный метод для добавления элемента в список
        protected internal void AddClient(Client currentClient)
        {
            selectedRoomListItem.AddClient(currentClient);
        }
        // вспомогательный метод для добавления элемента в список
        protected internal void RemoveClient(Client currentClient)
        {
            selectedRoomListItem.RemoveClient(currentClient.Id);
        }
        private async void AddGuest(object sender, EventArgs e)
        {
            currentClient = new Client("", "", 0);         
            if (selectedRoomListItem != null && selectedRoomListItem.FreePlace>0)
            {
                await Navigation.PushModalAsync(new AddClientModalPage(selectedRoomListItem, currentClient));
              
            }
            else
            {
                ErrorSelectItemLabel.IsVisible = true;
            }
        }
        // удаление клиента
        private async void RemoveGuest(object sender, EventArgs e)
        {
            if (selectedRoomListItem != null  )
            {
                await Navigation.PushModalAsync(new DeleteClientModalPage(selectedRoomListItem));
            }
        }

        private void RoomList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {         
            if (e.SelectedItem != null)
            {
                selectedRoomListItem = (Room)e.SelectedItem;
                ErrorSelectItemLabel.IsVisible = false;
            }               
        }

        private void ClientList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
