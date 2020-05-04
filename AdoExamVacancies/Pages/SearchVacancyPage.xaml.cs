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
    /// Interaction logic for SearchVacancyPage.xaml
    /// </summary>
    public partial class SearchVacancyPage : Page
    {
        public SearchVacancyPage()
        {
            InitializeComponent();
        }

        private void BtnSearchVacancy_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            string searchValue = tbxSearchValue.Text;
            if (string.IsNullOrEmpty(searchValue))
            {
                Mouse.OverrideCursor = null;
                MessageBox.Show("Введите искомое значение");
                return;
            }

            bool includeCategory = (bool)cbxCategory.IsChecked;
            bool includeDateOfPublish = (bool)cbxDateOfPublish.IsChecked;
            bool includeEmail = (bool)cbxEmail.IsChecked;
            bool includeDescription = (bool)cbxDescription.IsChecked;

            try
            {
                List<Vacancy> result = new List<Vacancy>();
                using (VacancyModelContainer db = new VacancyModelContainer())
                {
                    if (includeCategory)
                    {
                        var categoryId = from cat in db.Categories
                                         where cat.Name.Contains(searchValue)
                                         select cat.CategoryId;
                        (from catId in categoryId
                         from vac in db.Vacancies
                         where catId == vac.CategoryId
                         select vac).ToList().ForEach(f => result.Add(f));
                    }
                    if (includeDateOfPublish)
                    {
                        (from vac in db.Vacancies
                         where vac.PubDate.ToString().Contains(searchValue)
                         select vac).ToList().ForEach(f => result.Add(f));
                    }
                    if (includeEmail)
                    {
                        (from vac in db.Vacancies
                         where vac.Author.Contains(searchValue)
                         select vac).ToList().ForEach(f => result.Add(f));
                    }
                    if (includeDescription)
                    {
                        (from vac in db.Vacancies
                         where vac.Description.Contains(searchValue)
                         select vac).ToList().ForEach(f => result.Add(f));
                    }
                }
                if (result.Count == 0)
                    MessageBox.Show("Вакансий не найдено");

                lvSearchResult.ItemsSource = result;
                Mouse.OverrideCursor = null;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
