using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using App1.Views;
using System;
using System.Collections.Generic;
using Plugin.Share;
using Plugin.Share.Abstractions;

namespace App1
{
     
    public class NoteListViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Note> Notes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateNoteCommand { protected set; get; }
        public ICommand DeleteNoteCommand { protected set; get; }
        public ICommand SaveNoteCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        public ICommand ShareCommand { protected set; get; }
       
        
        public INavigation Navigation { get; set; }

        public NoteListViewModel()
        {    
            CreateNoteCommand = new Command(CreateNote);
            DeleteNoteCommand = new Command(DeleteNote);
            SaveNoteCommand = new Command(SaveNote);
            BackCommand = new Command(Back);
            ShareCommand = new Command(execute: ShareAsync);

            Notes = App.Database.GetItems();
        }

        public void updateList()
        {
             Notes = App.Database.GetItems();
            OnPropertyChanged(nameof(Notes));
        }

        private Note _selectedNote;
        public Note SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                if (_selectedNote != value)
                {
                    Note tempN  = value;                                    
                    _selectedNote = tempN;
                    OnPropertyChanged(nameof(SelectedNote));
                    Navigation.PushAsync(new NotePage(new NoteViewModel() { ListViewModel = this }));
                }
            }
        }
 

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateNote()
        {
            _selectedNote = new Note() { Created = DateTime.Now };
            OnPropertyChanged(nameof(SelectedNote));
            Navigation.PushAsync(new NotePage(new NoteViewModel() { ListViewModel = this }));
        }
         
        private void Back()
        {           
            updateList();
            Navigation.PopAsync();         
        }

        private async void ShareAsync(object romObject)
        {
            if (romObject != null)
            {
                var note = romObject as NoteViewModel;     
                var shareObject = new ShareMessage()
                {
                    Title = note.ListViewModel.SelectedNote.Title,
                    Text = note.ListViewModel.SelectedNote.Description,
                };

                // Share message and an optional title.
                await CrossShare.Current.Share(shareObject);
            }
           
        }

        private void SaveNote(object romObject)
        {
            if (romObject != null)
            {
                var test = this;
                var note = romObject as NoteViewModel;
                if (note != null)
                {                 
                    App.Database.SaveItem(note.ListViewModel.SelectedNote);
                }
                Back();
            }   
        }

        private void DeleteNote(object obj)
        {
            var note = obj as NoteViewModel;
            if (note != null)
            {
                App.Database.DeleteItem(note.ListViewModel.SelectedNote.Id);               
            }
            Back();
        }
         

    }
}