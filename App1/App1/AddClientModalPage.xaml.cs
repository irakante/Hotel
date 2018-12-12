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
    public partial class AddClientModalPage : ContentPage
    {
        public Client newCLient;       
        public AddClientModalPage(Room selectedRoomListItem, Client currentCLient)
        {
            newCLient = currentCLient;
            InitializeComponent();
            this.BindingContext = newCLient;
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var ob = newCLient;
             
            await Navigation.PopModalAsync();
            // находим в стеке предпоследнюю страницу - то есть MainPage
            NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
            MainPage homePage = navStack[navPage.Navigation.NavigationStack.Count - 1] as MainPage;

            if (homePage != null)
            {
                homePage.AddClient(ob);
            }
        }
    }
}