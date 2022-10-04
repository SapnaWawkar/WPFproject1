using D2HLogin.Entities;
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
using System.Windows.Shapes;

namespace D2HLogin
{
    /// <summary>
    /// Interaction logic for Agent_Login.xaml
    /// </summary>
    public partial class Agent_Login : Window
    {
        private static string _connectionString;

        public Agent_Login(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Agent_Login()
        {
            InitializeComponent();
        }
        
        public static void AgentLoginWithUsernameAndPassword(string username, string password)
        {
           
            List<AgentInformation> agents = new List<AgentInformation>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"SELECT A.[Id],A.[FirstName],A.[LastName],AG.[City] AS GroupName FROM [Agent] as A JOIN [AgentGroup] as AG ON AG.[Id]=A.[GroupId] WHERE A.[Username]='{@username}' AND A.[Password]='{@password}'", connection);


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int cnt = 0;
                while (reader.Read())
                {
                    AgentInformation ag = new AgentInformation();
                    ag.id = (int)reader[0];
                    ag.FirstName = (string)reader[1];
                    ag.LastName = (string)reader[2];
                    ag.GroupName = (string)reader[3];


                    agents.Add(ag);
                    cnt++;

                }
                if (cnt == 1)
                {
                    MessageBox.Show("Congratulations..You have successfully Login");
                    MainWindow mw = new MainWindow();
                    mw.Visibility = Visibility.Hidden;
                    Agent_Login ag = new Agent_Login();
                    ag.Visibility = Visibility.Visible;

                }
                else
                {
                    MessageBox.Show("Wrong Credentials..");
                }
                connection.Close();
                
            }

        }
    }

   
}
