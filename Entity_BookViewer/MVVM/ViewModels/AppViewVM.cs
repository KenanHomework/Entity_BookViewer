using Entity_BookViewer.Commands;
using Entity_BookViewer.Extensions;
using Entity_BookViewer.MVVM.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Entity_BookViewer.MVVM.ViewModels
{
    public class AppViewVM
    {
        #region Members

        private List<object> filters = new();

        private List<string> strings;

        private List<string> typesname;

        private List<object> types;

        private int filterselectedinde;

        private int typeindex;

        public AppView Window { get; set; }


        public List<object> Types
        {
            get { return types; }
            set { types = value; OnPropertyChanged(); }
        }

        public List<string> TypeNames
        {
            get { return typesname; }
            set { typesname = value; OnPropertyChanged(); }
        }

        public int TypeSelectedIndex
        {
            get { return typeindex; }
            set { typeindex = value; OnPropertyChanged(); }
        }

        public int FilterSelectedIndex
        {
            get { return filterselectedinde; }
            set { filterselectedinde = value; OnPropertyChanged(); }
        }

        public List<object> Filters
        {
            get { return filters; }
            set { filters = value; OnPropertyChanged(); }
        }

        public List<string> FilterNames
        {
            get { return strings; }
            set { strings = value; OnPropertyChanged(); }
        }

        #endregion

        #region Methods

        public void ReadContext()
        {
            using (LibraryContext context = new(App.Options))
            {
                Filters.Add(context.Authors);
                Filters.Add(context.Presses);
                Filters.Add(context.Categories);
                Filters.Add(context.Themes);
            }
            FilterNames = Filters.ToObjectNames();
        }

        public void FilterSelectionChanged(int index)
        {

            List<object> list = new();
            object selected = Filters[index];

            using (LibraryContext context = new(App.Options))
            {
                if (selected is DbSet<Author>) Types = context.Authors.ToList<object>();
                else if (selected is DbSet<Press>) Types = context.Presses.ToList<object>();
                else if (selected is DbSet<Category>) Types = context.Categories.ToList<object>();
                else if (selected is DbSet<Theme>) Types = context.Themes.ToList<object>();
            }

            Window.TypeComboBox.ItemsSource = null;
            Window.TypeComboBox.ItemsSource = Types;

        }

        #endregion

        #region Commands


        #endregion

        #region PropertyChangedEventHandler

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        public AppViewVM()
        {

        }

    }
}
