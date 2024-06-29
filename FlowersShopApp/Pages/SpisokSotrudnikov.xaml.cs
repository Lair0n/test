// Используемые пространства имен:
using FlowersShopApp.Model; // Доступ к моделям данных цветочного магазина.
using System; // Основные классы .NET, включая базовые типы и исключения.
using System.Configuration; // Классы для доступа к файлам конфигурации.
using System.Data.Entity; // Классы Entity Framework для взаимодействия с базой данных.
using System.Linq; // Поддержка LINQ для запросов к коллекциям и базам данных.
using System.Windows; // Классы для создания приложений на базе Windows Presentation Foundation (WPF).
using System.Windows.Controls; // Классы элементов управления WPF.
using System.Windows.Input; // Классы для обработки ввода пользователя в WPF.

// Пространство имен для страниц приложения цветочного магазина.
namespace FlowersShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для страницы "Список сотрудников" (SpisokSotrudnikov.xaml).
    /// </summary>
    public partial class SpisokSotrudnikov : Page
    {
        // Конструктор страницы "Список сотрудников".
        public SpisokSotrudnikov()
        {
            InitializeComponent(); // Инициализация компонентов страницы.
            // Получение контекста базы данных.
            var context = Shop_Model.GetContext();
            // Запрос к базе данных для получения списка сотрудников.
            var sotrudnik = context.Sotrudniki.Include(e => e.doljnost)
                .Select(e => new
                {
                    familiya = e.familiya,
                    doljnost = e.Doljnosti.nazvanie,
                    id_sotrudnika = e.id_sotrudnika
                }).ToList();
            // Присвоение источника данных для ListView.
            lvSotrudniki.ItemsSource = sotrudnik;
        }

        // Обработчик двойного клика мыши на элементе списка.
        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Проверка, что клик был сделан левой кнопкой мыши.
            if (e.ChangedButton == MouseButton.Left)
            {
                // Получение выбранного сотрудника из списка.
                var sotr = lvSotrudniki.SelectedItem as dynamic;
                int id = sotr.id_sotrudnika;
                // Навигация к странице "Редактирование сотрудника".
                NavigationService.Navigate(new RedaktirovanieSotrudnika(id));
            }
        }

        // Обработчик нажатия на кнопку "Добавить".
        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Навигация к странице "Редактирование сотрудника" для создания нового сотрудника.
            NavigationService.Navigate(new RedaktirovanieSotrudnika(0));
        }

        // Обработчик нажатия на кнопку "Удалить".
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранного сотрудника из списка.
            var sotr = lvSotrudniki.SelectedItem as dynamic;
            int id = sotr.id_sotrudnika;
            try
            {
                // Поиск и удаление сотрудника из базы данных.
                var users = Shop_Model.GetContext().Sotrudniki.Find(id);
                Shop_Model.GetContext().Sotrudniki.Remove(users);
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