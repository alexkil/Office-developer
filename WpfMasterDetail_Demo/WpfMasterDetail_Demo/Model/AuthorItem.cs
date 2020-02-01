using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfMasterDetail_Demo.Model
{
    public class AuthorItem : INotifyPropertyChanged
    {
        private int _ID;
        private string _Name;

        public int ID { get => _ID; set { _ID = value; OnPropertyChanged("ID"); } }
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged("Name"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
