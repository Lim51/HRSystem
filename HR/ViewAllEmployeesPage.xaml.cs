using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace HR
{
    public sealed partial class ViewAllEmployeesPage : Page
    {
        private string conn = (App.Current as App).ConnectionString;

        public ViewAllEmployeesPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT EmployeeID, Name, Role, ICNo, Gender, Address, ContactNo, EmailAddress FROM Users";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeID = reader["EmployeeID"].ToString(),
                            Name = reader["Name"].ToString(),
                            Role = reader["Role"].ToString(),
                            ICNo = reader["ICNo"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            EmailAddress = reader["EmailAddress"].ToString(),
                            ContactNo = reader["ContactNo"].ToString(),
                            Address = reader["Address"].ToString()
                        });
                    }

                    lstEmployees.ItemsSource = employees;
                }
                catch (SqlException sqlEx)
                {
                    var dialog = new MessageDialog("Database error: " + sqlEx.Message);
                    await dialog.ShowAsync();
                }
                catch (Exception ex)
                {
                    var dialog = new MessageDialog("Error: " + ex.Message);
                    await dialog.ShowAsync();
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }

    public class Employee
    {
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string ICNo { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
    }
}