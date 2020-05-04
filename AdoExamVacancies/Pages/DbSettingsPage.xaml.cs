using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace AdoExamVacancies.Pages
{
    /// <summary>
    /// Interaction logic for DbSettingsPage.xaml
    /// </summary>
    public partial class DbSettingsPage : Page
    {
        public DbSettingsPage()
        {
            InitializeComponent();
        }

        private void BtnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            string serverName = tbxServerName.Text;
            string dbName = tbxDbName.Text;
            string userName = tbxUserName.Text;
            string password = tbxPassword.Text; 

            if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            string CS = ConfigurationManager.ConnectionStrings["VacancyModelContainer"].ConnectionString;
        }
    }
}
