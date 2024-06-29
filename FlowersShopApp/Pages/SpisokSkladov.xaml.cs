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
    /// Логика взаимодействия для страницы "Список складов" (SpisokSkladov.xaml).
    /// </summary>
    public partial class SpisokSkladov : Page
    {
        // Конструктор страницы "Список складов".
        public SpisokSkladov()
        {
            InitializeComponent(); // Инициализация компонентов страницы.
            // Получение контекста базы данных.
            var context = Shop_Model.GetContext();
            // Запрос к базе данных для получения списка складов.
            var sklad = context.Sklad.Include(e => e.id_zvetov)
                .Select(e => new
                {
                    adres = e.adres,
                    zvety = e.Zvety.imya,
                    kolichestvo = e.kolichestvo,
                    id_sklada = e.id_sklada
                }).ToList();
            // Присвоение источника данных для ListView.
            lvSklady.ItemsSource = sklad;
        }

        // Обработчик двойного клика мыши на элементе списка.
        private void lvSklady_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Проверка, что клик был сделан левой кнопкой мыши.
            if (e.ChangedButton == MouseButton.Left)
            {
                // Получение выбранного склада из списка.
                var sklad = lvSklady.SelectedItem as dynamic;
                int id = sklad.id_sklada;
                // Навигация к странице "Редактирование склада".
                NavigationService.Navigate(new RedaktirovanieSklad(id));
            }
        }

        // Обработчик нажатия на кнопку "Добавить".
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Навигация к странице "Редактирование склада" для создания нового склада.
            NavigationService.Navigate(new RedaktirovanieSklad(0));
        }

        // Обработчик нажатия на кнопку "Удалить".
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранного склада из списка.
            var sotr = lvSklady.SelectedItem as dynamic;
            int id = sotr.id_sklada;
            try
            {
                // Поиск и удаление склада из базы данных.
                var sklad = Shop_Model.GetContext().Sklad.Find(id);
                Shop_Model.GetContext().Sklad.Remove(sklad);
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