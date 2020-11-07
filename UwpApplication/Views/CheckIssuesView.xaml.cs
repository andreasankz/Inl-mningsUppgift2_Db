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
    public sealed partial class CheckIssuesView : Page
    {
        public IEnumerable<Issue> issues { get; set; }
        

        public CheckIssuesView()
        {
            this.InitializeComponent();
            LoadIssuesAsync().GetAwaiter();
        }
        public void LoadCurrentIssues()
        {
            lvCurrent.ItemsSource = issues
                .Where(i => i.Status != "closed")
                .OrderByDescending(i => i.Created)
                .Take(SettingsContext.GetMaxItemsCount())
                .ToList();
        }

        public void LoadClosedIssues()
        {
            lvCompleted.ItemsSource = issues
                .Where(i => i.Status == "closed")
                .OrderByDescending(i => i.Created)
                .Take(SettingsContext.GetMaxItemsCount())
                .ToList();
        }

        public async Task LoadIssuesAsync()
        {
            issues = await SqliteContext.GetIssues();
            LoadCurrentIssues();
            LoadClosedIssues();
        }
    }
}
