using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApp
{
    public class ViewModelLocator
    {
        //private ViewModels.ViewModel viewModel = new ViewModels.MainViewModel();
        public ViewModels.ViewModel ViewModel { get; set; }

        public ViewModelLocator()
        {
            ViewModel = new ViewModels.MainViewModel();
        }

        public ViewModels.ViewModel getViewModel()
        {
            return ViewModel;
        }

    }
}
