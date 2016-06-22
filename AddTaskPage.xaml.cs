using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TaskListApp.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TaskListApp
{
    public sealed partial class AddTaskPage : Page
    {
        public AddTaskPage()
        {
            this.InitializeComponent();
            DataContext = ((App)App.Current).MyViewModelLocator.getViewModel();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
