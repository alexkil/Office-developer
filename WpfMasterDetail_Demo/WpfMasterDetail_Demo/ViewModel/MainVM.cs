using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using WpfMasterDetail_Demo.Model;

namespace WpfMasterDetail_Demo.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public MainVM()
        {
            Authors = new ObservableCollection<AuthorItem>() {
                new AuthorItem() {Name = "Author 1", ID = 1 },
                new AuthorItem() {Name = "Author 2", ID = 2 },
                new AuthorItem() {Name = "Author 3", ID = 3 }
            };
            Books = new ObservableCollection<BookItem>() {
                new BookItem() {Title = "Book1", ID = 1, Author = 1 },
                new BookItem() {Title = "Book2", ID = 2, Author = 1 },
                new BookItem() {Title = "Book3", ID = 3, Author = 2 },
                new BookItem() {Title = "Book4", ID = 4, Author = 3 },
                new BookItem() {Title = "Book5", ID = 5, Author = 2 },
                new BookItem() {Title = "Book6", ID = 6, Author = 1 },
                new BookItem() {Title = "Book7", ID = 7, Author = 3 }
            };
            BooksFromAuthor = new ObservableCollection<BookItem>();
            //BooksFromAuthor = Books;
        }
        #region Fields
        private ObservableCollection<BookItem> Books { get; set; }
        public ObservableCollection<BookItem> BooksFromAuthor { get; set; }
        public ObservableCollection<AuthorItem> Authors { get; set; }
        private AuthorItem _SelectedAuthor;
        public AuthorItem SelectedAuthor{ 
            get => _SelectedAuthor; 
            set { 
                _SelectedAuthor = value; 
                OnPropertyChanged("SelectedAuthor");
                LoadDetailItems();
            } 
        }
        #endregion

        #region Methods
        private void LoadDetailItems()
        {
            BooksFromAuthor.Clear();
            foreach (BookItem b in Books.Where(b => b.Author == SelectedAuthor.ID).ToList())
            {
                BooksFromAuthor.Add(b);
            }
                //BooksFromAuthor = Books; //new ObservableCollection<BookItem>(Books.Where(b => b.Author == SelectedAuthor.ID).ToList());
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
        
    }
}
