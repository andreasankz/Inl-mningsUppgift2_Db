using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApplication.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddIssueView : Page
    {
        
        public AddIssueView()
        {
            this.InitializeComponent();
            LoadCustomersAsync().GetAwaiter();
            LoadStatusAsync().GetAwaiter();
            
        }

        private async Task LoadCustomersAsync()
        {
            cmbCustomers.ItemsSource = await SqliteContext.GetCustomerNames();
        }

        private async Task LoadStatusAsync()
        {
            cmbStatus.ItemsSource = await SettingsContext.GetStatus();
        }

        private async void btnAddIssue_Click(object sender, RoutedEventArgs e)
        {
            await SqliteContext.CreateIssueAsync(
                   new Issue
                   {
                       Title = "Title: " + tbTitle.Text,
                       Description = "Desc: " + tbDescription.Text,
                       Status = cmbStatus.SelectedItem.ToString(),
                       CustomerId = await SqliteContext.GetCustomerIdByName(cmbCustomers.SelectedItem.ToString())
                   }

                  ); 

            tbTitle.Text = string.Empty;
            tbDescription.Text = string.Empty;
        }

       

    }
}
