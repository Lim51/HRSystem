using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
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
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private string conn = (App.Current as App).ConnectionString;

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string employeeID = txtEmployeeID.Text;
            string password = pwdPassword.Password;

            try
            {
                // Check credentials and get role
                string role = await ValidateUser(employeeID, password);

                if (role != null)
                {
                    // Navigate to MainPage with employeeID and role
                    this.Frame.Navigate(typeof(MainPage), Tuple.Create(employeeID, role));
                }
                else
                {
                    // Show error message
                    var dialog = new Windows.UI.Popups.MessageDialog("Invalid credentials.");
                    await dialog.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions
                var dialog = new Windows.UI.Popups.MessageDialog("Unexpected error: " + ex.Message);
                await dialog.ShowAsync();
                Debug.WriteLine($"Error in btnLogin_Click: {ex}");
            }
        }

        private async Task<string> ValidateUser(string employeeID, string password)
        {
            string role = null;

            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT Role FROM Users WHERE EmployeeID = @employeeID AND Password = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    // Logging query execution
                    Debug.WriteLine($"Executing query: {query} with EmployeeID: {employeeID}, Password: {password}");

                    if (reader.Read())
                    {
                        role = reader["Role"].ToString();
                        Debug.WriteLine($"Role found: {role}");
                    }
                    else
                    {
                        Debug.WriteLine("No matching role found.");
                    }
                }
                catch (SqlException sqlEx)
                {
                    // Handle SQL-specific exceptions
                    var dialog = new Windows.UI.Popups.MessageDialog("Database error: " + sqlEx.Message);
                    await dialog.ShowAsync();
                    Debug.WriteLine($"SQL Error: {sqlEx}");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    var dialog = new Windows.UI.Popups.MessageDialog("Error: " + ex.Message);
                    await dialog.ShowAsync();
                    Debug.WriteLine($"Error: {ex}");
                }
            }

            return role;
        }
    }
}