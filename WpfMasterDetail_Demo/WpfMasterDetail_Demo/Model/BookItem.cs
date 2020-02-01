using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfMasterDetail_Demo.Model
{
    public class BookItem : INotifyPropertyChanged
    {
        private int _ID;
        private string _Title;
        private int _Author;

        public int ID { get => _ID; set { _ID = value; OnPropertyChanged("ID"); } }
        public string Title { get => _Title; set { _Title = value; OnPropertyChanged("Title"); } }
        public int Author { get => _Author; set { _Author = value; OnPropertyChanged("Author"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
