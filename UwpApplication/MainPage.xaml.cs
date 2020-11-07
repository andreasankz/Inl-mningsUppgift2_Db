using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        

        public MainPage()
        {
            this.InitializeComponent();
        }
        private void btnAddIssue_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(Views.AddIssueView));
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(Views.AddCustomerView));
        }

        private void btnViewIssues_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(Views.CheckIssuesView));
        }

       
    }
}
