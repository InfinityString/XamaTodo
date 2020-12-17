using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamaTodo.Models;

namespace XamaTodo
{
    public partial class MainPage : ContentPage
    {
     public ObservableCollection<ToDo> AllToDo { get; set; }
        public MainPage()
        {
            InitializeComponent();
            
            var db = new SQLiteConnection(SqlConnection.SqlPath);

            db.CreateTable<ToDo>();

            AllToDo = new ObservableCollection<ToDo>(db.Table<ToDo>().ToList());
            BindingContext = this;

        }

        private void Editor_ChildAdded(object sender, ElementEventArgs e)
        {

        }
       
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text)) {
                await DisplayAlert("Error", "Enter todo item", "OK");
                return;
            }
            var db = new SQLiteConnection(SqlConnection.SqlPath);           

            var todo = new ToDo()
            {
                Done = false,
                TodoText = TextBox1.Text,
                TodoTime = TimeBox.Time.ToString()

            };
            db.Insert(todo);
            AllToDo.Add(todo);
           

        }

       
        protected override void OnDisappearing()
        {
            var db = new SQLiteConnection(SqlConnection.SqlPath);
            base.OnDisappearing();
            db.UpdateAll(AllToDo);
        }
        private void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(SqlConnection.SqlPath);
            SwipeItem item = sender as SwipeItem;
            ToDo model = item.BindingContext as ToDo;            
            AllToDo.Remove(model);
            db.Delete(model);

        }
    }
}
