using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeleteClientModalPage : ContentPage
	{
        public Room selectedRoom;
        public Client selectedClient;
        public DeleteClientModalPage (Room selectedRoomListItem)
		{
			InitializeComponent ();
             selectedRoom = selectedRoomListItem;
            this.BindingContext = selectedRoomListItem;
        }

        private void ClientsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedClient  = (Client)e.SelectedItem;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var ob = selectedClient;

            await Navigation.PopModalAsync();
            // находим в стеке предпоследнюю страницу - то есть MainPage
            NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
            MainPage homePage = navStack[navPage.Navigation.NavigationStack.Count - 1] as MainPage;

            if (homePage != null)
            {
                homePage.RemoveClient(ob);
            }
        }
    }
}