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
    public sealed partial class AddEmployeePage : Page
    {
        private string conn = (App.Current as App).ConnectionString;

        public AddEmployeePage()
        {
            this.InitializeComponent();
        }

        private void exitCommandBar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the previous page
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            string employeeID = txtEmployeeID.Text;
            string password = pwdPassword.Password;
            string confirmPassword = pwdConfirmPassword.Password;
            string role = (cmbRole.SelectedItem as ComboBoxItem)?.Content.ToString();
            string name = txtName.Text;
            string icNo = txtICNo.Text;
            string gender = rbMale.IsChecked == true ? "Male" : "Female";
            string address = txtAddress.Text;
            string contactNo = txtContactNo.Text;
            string emailAddress = txtEmailAddress.Text;

            if (string.IsNullOrWhiteSpace(employeeID) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(icNo) ||
                string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(contactNo) || string.IsNullOrWhiteSpace(emailAddress) ||
                (!rbMale.IsChecked.Value && !rbFemale.IsChecked.Value))
            {
                var dialog = new MessageDialog("All fields are required.");
                await dialog.ShowAsync();
                return;
            }

            if (password != confirmPassword)
            {
                var dialog = new MessageDialog("Passwords do not match.");
                await dialog.ShowAsync();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string query = "INSERT INTO Users (EmployeeID, Password, Role, Name, ICNo, Gender, Address, ContactNo, EmailAddress) " +
                                   "VALUES (@EmployeeID, @Password, @Role, @Name, @ICNo, @Gender, @Address, @ContactNo, @EmailAddress)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@ICNo", icNo);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@EmailAddress", emailAddress);
                    command.Parameters.AddWithValue("@ContactNo", contactNo);
                    command.Parameters.AddWithValue("@Address", address);
                    

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    var dialog = new MessageDialog("Employee added successfully.");
                    dialog.Commands.Add(new UICommand("OK") { Id = 0 });
                    dialog.DefaultCommandIndex = 0;

                    var result = await dialog.ShowAsync();
                    if ((int)result.Id == 0)
                    {
                        this.Frame.GoBack();
                    }
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