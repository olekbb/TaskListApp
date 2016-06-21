using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class PersistentTextPage : Page
    {
        public PersistentTextPage()
        {
            this.InitializeComponent();
        }

        private void OnLocalSettingsClick(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["test"] = "test value";
        }

        private void OnLoadLocalSettingsClick(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            var value = localSettings.Values["test"];
        }

        private void Serialize()
        {
            var list = new List<string>
            {
                "test1",
                "test2",
                "test3"
            };
            string json = JsonConvert.SerializeObject(list);

            var deserializedList = JsonConvert.DeserializeObject<List<string>>(json);
        }

        private void OnSerializeClick(object sender, RoutedEventArgs e)
        {
            Serialize();
        }
    }
}
