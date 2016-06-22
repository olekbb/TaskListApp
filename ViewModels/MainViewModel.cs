using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TaskListApp.Commands;

namespace TaskListApp.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private TaskManager taskManager;
        private string title;
        private string value;
        private string user;
        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }
        private ObservableCollection<ToDoTask> itemsCollection = new ObservableCollection<ToDoTask>();
        public ObservableCollection<ToDoTask> ItemsCollection
        {
            get
            {
                return itemsCollection;
            }
            set
            {
                itemsCollection = value;
                OnPropertyChanged("ItemsCollection");
            }
            
        }
        public ICommand AddElementCommand { get; set; }
        public ICommand SyncCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public MainViewModel()
        {
            taskManager = new TaskManager();
            User = "defaultUser";
            
            AddElementCommand = new RelayCommand(pars => AddElement());
            SyncCommand = new RelayCommand(pars => Sync());
            DeleteCommand = new RelayCommand(pars => Delete());
        }

        private void Delete()
        {
            taskManager.DeleteTask(Id);
        }

        private async void Sync()
        {
            ItemsCollection.Clear();
            List<ToDoTask> list = await taskManager.DownloadTasks(User);
            foreach (ToDoTask task in list)
            {
                ItemsCollection.Add(task);
            }
        }
        private void AddElement()
        {
            ToDoTask task = new ToDoTask(Title, Value, User);
            taskManager.UploadTask(task);
            Sync();
        }
    }
}
