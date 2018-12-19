using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System;
 


namespace App1 
{
    public class NoteViewModel : INotifyPropertyChanged
    {      
        public Note Note { get; private set; }
        public bool Editing { get; set; }

        public NoteViewModel()
        {
            Note = new Note();
            Note.Created = DateTime.Now;
            Editing = true;         
        }

        private NoteListViewModel lvm;
        public NoteListViewModel ListViewModel
        {
            get {
                return lvm;
            }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged(nameof(ListViewModel));
                }
            }
        }

        public string Title
        {
            get { return Note.Title; }
            set
            {
                if (Note.Title != value)
                {
                    Note.Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }     
        
        public string Description
        {
            get { return Note.Description; }
            set
            {
                if (Note.Description != value)
                {
                    Note.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public DateTime Created  
        {
            get { return Note.Created; }
            set
            {
                if (Note.Created != value)
                {
                    Note.Created = value;
                    OnPropertyChanged(nameof(Created));
                }
            }
        }

        public int Id { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
