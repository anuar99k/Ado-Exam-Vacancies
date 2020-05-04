using AdoExamVacancies.Pages;
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

namespace AdoExamVacancies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new VacancyCategoriesPage());
        }

        private void MiCategories_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new VacancyCategoriesPage());
        }

        private void MiSearchVacancy_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SearchVacancyPage());
        }

        private void MiStatisticInfo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StatisticPage());
        }

        private void MiDbSettings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DbSettingsPage());
        }
    }
}
