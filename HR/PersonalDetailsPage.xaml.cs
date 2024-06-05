using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
    public sealed partial class PersonalDetailsPage : Page
    {
        private string conn = (App.Current as App).ConnectionString;

        public PersonalDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is string employeeID)
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string query = "SELECT EmployeeID, Password, Role, Name, ICNo, Gender, Address, ContactNo, EmailAddress FROM Users WHERE EmployeeID = @employeeID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@employeeID", employeeID);

                    try
                    {
                        await connection.OpenAsync();
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        if (reader.Read())
                        {
                            txtEmployeeID.Text = reader["EmployeeID"].ToString();
                            txtPassword.Text = reader["Password"].ToString();
                            txtRole.Text = reader["Role"].ToString();
                            txtName.Text = reader["Name"].ToString();
                            txtICNo.Text = reader["ICNo"].ToString();
                            txtGender.Text = reader["Gender"].ToString();
                            txtEmailAddress.Text = reader["EmailAddress"].ToString();
                            txtContactNo.Text = reader["ContactNo"].ToString();
                            txtAddress.Text = reader["Address"].ToString();

                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        var dialog = new MessageDialog("Database error: " + sqlEx.Message);
                        await dialog.ShowAsync();
                        Debug.WriteLine($"SQL Error: {sqlEx}");
                    }
                    catch (Exception ex)
                    {
                        var dialog = new MessageDialog("Error: " + ex.Message);
                        await dialog.ShowAsync();
                        Debug.WriteLine($"Error: {ex}");
                    }
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
}