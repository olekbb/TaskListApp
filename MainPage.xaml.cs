using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TaskListApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private TaskManager taskManager;
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = ((App)App.Current).MyViewModelLocator.getViewModel();
            taskManager = new TaskManager();

        }
        private void GoToAddTaskPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddTaskPage));
        }
        private void GoToLoginPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }
        private void GoToPage2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PersistentTextPage));
        }
        private void SendTaskToApi(object sender, RoutedEventArgs e)
        {
            ToDoTask task = new ToDoTask("testTitle2", "testValue2", "testOwner");
            taskManager.uploadTask(task);
        }

        private async void DownloadTasks(object sender, RoutedEventArgs e)
        {
            
            List<ToDoTask> list = await taskManager.DownloadTasks("testOwner");
            foreach (ToDoTask element in list)
            {
                Debug.WriteLine(element.Serialize());
            }
        }
    }
}
