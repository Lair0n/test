// Используемые пространства имен:
using FlowersShopApp.Model; // Доступ к моделям данных цветочного магазина.
using System; // Основные классы .NET, включая базовые типы и исключения.
using System.Data.Entity; // Классы Entity Framework для взаимодействия с базой данных.
using System.Linq; // Поддержка LINQ для запросов к коллекциям и базам данных.
using System.Windows; // Классы для создания приложений на базе Windows Presentation Foundation (WPF).
using System.Windows.Controls; // Классы элементов управления WPF.
using System.Windows.Input; // Классы для обработки ввода пользователя в WPF.

// Пространство имен для страниц приложения цветочного магазина.
namespace FlowersShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для страницы "Список поставок" (SpisokPostavok.xaml).
    /// </summary>
    public partial class SpisokPostavok : Page
    {
        // Конструктор страницы "Список поставок".
        public SpisokPostavok()
        {
            InitializeComponent(); // Инициализация компонентов страницы.
            // Получение контекста базы данных.
            var context = Shop_Model.GetContext();
            // Запрос к базе данных для получения списка поставок.
            var postavka = context.Postavki.Include(e => e.id_zvetov)
                .Select(e => new
                {
                    postavschik = e.Postavschiki.naimenovanie,
                    zvety = e.Zvety.imya,
                    kolichestvo = e.kolichestvo,
                    data = e.data_postavki,
                    id_postavki = e.id_postavki
                }).ToList();
            // Присвоение источника данных для ListView.
            lvPostavki.ItemsSource = postavka;
        }

        // Обработчик двойного клика мыши на элементе списка.
        private void lvPostavki_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Проверка, что клик был сделан левой кнопкой мыши.
            if (e.ChangedButton == MouseButton.Left)
            {
                // Получение выбранной поставки из списка.
                var postavka = lvPostavki.SelectedItem as dynamic;
                int id = postavka.id_postavki;
                // Навигация к странице "Редактирование поставки".
                NavigationService.Navigate(new RedaktirovaniePostavki(id));
            }
        }

        // Обработчик нажатия на кнопку "Добавить".
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Навигация к странице "Редактирование поставки" для создания новой поставки.
            NavigationService.Navigate(new RedaktirovaniePostavki(0));
        }

        // Обработчик нажатия на кнопку "Удалить".
        private void btnReplace_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранной поставки из списка.
            var post = lvPostavki.SelectedItem as dynamic;
            int id = post.id_postavki;
            try
            {
                // Поиск и удаление поставки из базы данных.
                var users = Shop_Model.GetContext().Postavki.Find(id);
                Shop_Model.GetContext().Postavki.Remove(users);
                Shop_Model.GetContext().SaveChanges();
                // Уведомление пользователя об успешном удалении.
                MessageBox.Show("Удаление завершено");
                // Обновление контекста базы данных.
                Shop_Model.GetContext();
            }
            catch (Exception ex)
            {
                // Уведомление пользователя об ошибке.
                MessageBox.Show(ex.Message);
            }
        }
    }
}