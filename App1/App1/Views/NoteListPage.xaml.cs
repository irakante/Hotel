using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteListPage : ContentPage
	{
		public NoteListPage()
		{
			InitializeComponent();
            BindingContext = new NoteListViewModel() { Navigation = this.Navigation };
        }

         

    }
}