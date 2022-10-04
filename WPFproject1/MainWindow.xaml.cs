using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFproject1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string connectionString = @"Data Source=LAPTOP-QQJKA00R;Initial Catalog=Sapna;Integrated Security=True";
        private static CustomerLogin custLogin = new CustomerLogin(connectionString);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Content == "ON")
            {
                btn.Content = "OFF";
            }
            else 
            {
                btn.Content = "ON";
            }          
            
        }
        private void GoToDashBoard(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            DashBoard d=new DashBoard();
            d.Visibility = Visibility.Visible;
        }

        private void getTable()
        {
            string input = InputForTable.Text;
            int value = int.Parse(input);
            string s1 = "";
            for(int i=1; i<=10; i++)
            {
                int val = i * value;
                s1=s1+ " "+val;
            }
            this.LableTable.Content = s1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getTable();
        }

        private void Sign_Up(object sender, RoutedEventArgs e)
        {

        }

       /* private void Sign_In(object sender, RoutedEventArgs e)
        {
            string username=Username.Text;
            string password=Password.Text;
            List<Customer> customer=CustomerLogin.Customers(username, password);
            if(customer!=null)
            {
                this.CustomerLogin.Content = "Congratulations...Successfully SignIn..!!";
            }
            else
            {
                this.CustomerLogin.Content = "Wrong Credentials..";
            }
        }*/
    }
    public class CustomerLogin
    {
        private static string _connectionString;

        public CustomerLogin(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static List<Customer> Customers(string username, string password)
        {
            List<Customer> customer = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"SELECT CS.[ID],CS.[FirstName],CS.[LastName],CS.[Username], CS.[Password]," +
                    $"CS.[ConnectionStatus],CS.[PackageId],CS.[GroupId],CS.[AreaId] FROM Customer as CS WHERE CS.[Username]='{username}' AND CS.[Password]='{password}'", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

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

                }
                connection.Close();
            }
            return customer;

        }
    }
        

}
