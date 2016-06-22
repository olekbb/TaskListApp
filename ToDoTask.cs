using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApp
{
    public class ToDoTask : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string OwnerId { get; set; }
        public string CreatedAt { get; set; }

        public ToDoTask(string Title, string Value)
        {
            this.Title = Title;
            this.Value = Value;

        }

        [JsonConstructor]
        public ToDoTask(string id, string title, string ownerId, string createdAt)
        {
            this.Id = id;
            this.Title = title;
            this.OwnerId = ownerId;
            this.CreatedAt = createdAt;
        }

        public ToDoTask(string Title, string Value, string OwnerId)
        {
            this.Title = Title;
            this.Value = Value;
            this.OwnerId = OwnerId;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
