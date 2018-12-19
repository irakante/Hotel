using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Views;
using App1.SqlLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "notes.db";
        public static NotesRepository database;
        public static NotesRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new NotesRepository(DATABASE_NAME);
                }
                return database;
            }
        }
        public App()
        {

            InitializeComponent();
            MainPage = new NavigationPage(new NoteListPage());
         
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
