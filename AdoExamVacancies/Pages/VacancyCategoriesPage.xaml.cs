using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

namespace AdoExamVacancies.Pages
{
    /// <summary>
    /// Interaction logic for VacancyCategoriesPage.xaml
    /// </summary>
    public partial class VacancyCategoriesPage : Page
    {
        public VacancyCategoriesPage()
        {
            InitializeComponent();
        }

        private async void BtnSaveVacancyCategory_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;

            string vacancyCategory = tbxVacancyCategory.Text;
            string vacancyLink = tbxVacancyLink.Text;

            if (string.IsNullOrEmpty(vacancyCategory) || string.IsNullOrEmpty(vacancyLink))
            {
                MessageBox.Show("Заполните все поля");
                Mouse.OverrideCursor = null;
                return;
            }

            try
            {
                using (VacancyModelContainer db = new VacancyModelContainer())
                {
                    if (db.Categories.Any(a => a.Name == vacancyCategory))
                    {
                        MessageBox.Show("Такая категория вакансий в базе уже существует");
                        return;
                    }
                }

                XDocument xDoc = XDocument.Load(vacancyLink);

                using (VacancyModelContainer db = new VacancyModelContainer())
                {
                    Category cat = new Category() { Name = vacancyCategory };
                    db.Categories.Add(cat);
                    foreach (XElement xElem in xDoc.Element("rss").Element("channel").Elements("item"))
                    {
                        Vacancy vac = new Vacancy();
                        vac.Title = xElem.Element("title").Value;
                        vac.Link = xElem.Element("link").Value;
                        vac.Description = xElem.Element("description").Value;
                        vac.PubDate = Convert.ToDateTime(xElem.Element("pubDate").Value);
                        vac.Author = xElem.Element("author").Value;
                        vac.Category = cat;

                        db.Vacancies.Add(vac);
                    }
                    await db.SaveChangesAsync();
                }
                Mouse.OverrideCursor = null;
                MessageBox.Show("Вакансии сохранены");
                tbxVacancyCategory.Text = "";
                tbxVacancyLink.Text = "";
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
