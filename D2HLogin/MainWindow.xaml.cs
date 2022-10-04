using D2HLogin.Entities;
using System;
using System.Collections.Generic;
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

namespace D2HLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string connectionString = @"Data Source=LAPTOP-QQJKA00R;Initial Catalog=Sapna;Integrated Security=True";
        private static Customer_Login custLogin = new Customer_Login(connectionString);
        private static Agent_Login agentLogin = new Agent_Login(connectionString);
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CustomerLogin(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            List<Customer> cust=Customer_Login.CustomerLoginWithUsernameAndPassword(username, password);
            int customerId = 0;
            foreach(Customer c in cust)
            {
                customerId = c.id;
            }
            Customer_Login clogin = new Customer_Login(customerId);
            if(cust!=null)
            {
                MessageBox.Show("Congratulations..You have successfully Login");
                MainWindow mw = new MainWindow();
                mw.Visibility = Visibility.Hidden;
                Customer_Login cl = new Customer_Login();
                cl.Visibility = Visibility.Visible;              
                
            }
            else
            {
                MessageBox.Show("Wrong Credentials..");
            }
        }

        private void AgentLogin(object sender, RoutedEventArgs e)
        {
            string username = Enter_Username.Text;
            string password = Enter_Password.Text;
            Agent_Login.AgentLoginWithUsernameAndPassword(username, password);
        }
    }
}
