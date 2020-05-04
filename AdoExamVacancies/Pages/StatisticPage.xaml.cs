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

namespace AdoExamVacancies.Pages
{
    /// <summary>
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        public StatisticPage()
        {
            InitializeComponent();

            LoadStatistic();
        }

        private void LoadStatistic()
        {
            using (VacancyModelContainer db = new VacancyModelContainer())
            {
                lblNumberOfRecords.Content = db.Vacancies.Count();
                lblNumberOfRecords2.Content = db.Categories.Count();
            }
        }

        private void BtnClearVacancies_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (VacancyModelContainer db = new VacancyModelContainer())
                {
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE Vacancies");
                    lblNumberOfRecords.Content = db.Vacancies.Count();
                }
                MessageBox.Show("Таблица Vacancies очищена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnClearCategories_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (VacancyModelContainer db = new VacancyModelContainer())
                {
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE Categories");
                    lblNumberOfRecords2.Content = db.Categories.Count();
                }
                MessageBox.Show("Таблица Categories очищена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
