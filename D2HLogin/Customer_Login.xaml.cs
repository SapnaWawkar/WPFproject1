using D2HLogin.Entities;
using D2HLogin.Operations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace D2HLogin
{
    /// <summary>
    /// Interaction logic for Customer_Login.xaml
    /// </summary>
    public partial class Customer_Login : Window
    {
        private static string _connectionString;
        private int customerId;
        
        public Customer_Login(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Customer_Login()
        {
            InitializeComponent();
        }

        public Customer_Login(int customerId)
        {
            this.customerId = customerId;
        }

        public static List<Customer> CustomerLoginWithUsernameAndPassword(string username, string password)
        {
            List<Customer> customer = new List<Customer>();
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"SELECT CS.[ID],CS.[FirstName],CS.[LastName],CS.[Username], CS.[Password]," +
                    $"CS.[ConnectionStatus],CS.[PackageId],CS.[GroupId],CS.[AreaId] FROM Customer as CS WHERE CS.[Username]='{username}' AND CS.[Password]='{password}'", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int cnt = 0;
                while (reader.Read())
                {
                     Customer c = new Customer();
                     c.id = (int)reader[0];
                     c.FirstName = (string)reader[1];
                     c.LastName = (string)reader[2];
                     c.Username = (string)reader[3];
                     c.Password = (string)reader[4];
                     c.ConnectionStatus = (int)reader[5];
                     c.PackageId = (int)reader[6];
                     c.GroupId = (int)reader[7];
                     c.AreaId = (int)reader[8];
                     customer.Add(c);

                    cnt++;
                }
               /* if(cnt==1)
                {
                    MessageBox.Show("Congratulations..You have successfully Login");
                    MainWindow mw = new MainWindow();
                    mw.Visibility = Visibility.Hidden;
                    Customer_Login cl = new Customer_Login();
                    cl.Visibility=Visibility.Visible;

                }
                else
                {
                    MessageBox.Show("Wrong Credentials..");
                }*/
                connection.Close();
            }
            return customer;           
            
        }

        private void GetMyInformation(object sender, RoutedEventArgs e)
        {
            this.c2.Visibility=Visibility.Hidden;
            this.c3.Visibility = Visibility.Hidden;
            this.c4.Visibility = Visibility.Hidden;
            this.c1.Visibility = Visibility.Visible;
            var value=CustomerOperations.GetCustomersPersonalInfo(customerId);

            c1.ItemsSource = value.ToString().ToList();
        }

        private void GetYearlyStatement(object sender, RoutedEventArgs e)
        {

        }

        private void RaiseComplaint(object sender, RoutedEventArgs e)
        {

        }

        private void GetAgentInformation(object sender, RoutedEventArgs e)
        {

        }

        private void LogOut(object sender, RoutedEventArgs e)
        {

        }

    }
    
}
