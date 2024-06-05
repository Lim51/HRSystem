using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HR
{
    public sealed partial class MainPage : Page
    {
        private string employeeID;
        private string role;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Tuple<string, string> parameters)
            {
                employeeID = parameters.Item1;
                role = parameters.Item2;

                if (role == "Admin")
                {
                    AdminContent.Visibility = Visibility.Visible;
                    EmployeeContent.Visibility = Visibility.Collapsed;
                }
                else if (role == "Employee")
                {
                    AdminContent.Visibility = Visibility.Collapsed;
                    EmployeeContent.Visibility = Visibility.Visible;
                }
            }
            else
            {
                // Handle the case where parameters are not passed
                AdminContent.Visibility = Visibility.Collapsed;
                EmployeeContent.Visibility = Visibility.Collapsed;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
           
           this.Frame.Navigate(typeof(LoginPage));
            
        }

        private void exitCommandBar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddEmployeePage),role);
        }

        private void ViewAllEmployees_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewAllEmployeesPage));
        }

        private void ViewPersonalDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PersonalDetailsPage), employeeID);
        }
    }
}