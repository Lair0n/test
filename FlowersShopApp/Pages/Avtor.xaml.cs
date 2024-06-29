using System.Linq; // Позволяет использовать LINQ-запросы для упрощения работы с данными.
using System.Windows; // Обеспечивает доступ к базовым элементам WPF.
using System.Windows.Controls; // Содержит классы для элементов управления, таких как страницы и кнопки.
using System.Windows.Navigation; // Предоставляет сервисы навигации в WPF.
using FlowersShopApp.Model; // Подключает модели данных приложения цветочного магазина.

namespace FlowersShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для страницы авторизации Avtor.xaml.
    /// </summary>
    public partial class Avtor : Page
    {
        // Конструктор страницы авторизации.
        public Avtor()
        {
            InitializeComponent(); // Инициализирует компоненты XAML.
            Shop_Model.GetContext(); // Загружает контекст данных приложения.
        }

        // Обработчик события нажатия на кнопку входа.
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string inputLogin = txtbLogin.Text.Trim(); // Считывание логина из текстового поля.
            string inputParol = pswbPassword.Password.Trim(); // Считывание пароля из поля пароля.
            var context = Shop_Model.GetContext(); // Получение контекста данных.
            // Поиск пользователя в базе данных.
            var user = context.Users.Where(u => u.login == inputLogin && u.parol == inputParol).FirstOrDefault();
            if (user != null) // Если пользователь найден.
            {
                // Получение данных о сотруднике.
                var sotrudnik = context.Sotrudniki.Where(s => s.id_sotrudnika == user.id_sotrudnika).FirstOrDefault();
                int doljnost = sotrudnik.doljnost; // Получение должности сотрудника.
                LoadPage(doljnost); // Загрузка соответствующей страницы в зависимости от должности.
            }
            else
            {
                MessageBox.Show("Такого пользователя нет хээээх"); // Вывод сообщения об ошибке.
            }
        }

        // Обработчик события нажатия на кнопку входа для покупателя.
        private void btnEnterPokupatel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pokupatel()); // Навигация на страницу покупателя.
        }

        // Метод для загрузки страницы в зависимости от должности пользователя.
        private void LoadPage(int id)
        {
            if (id == 1) NavigationService.Navigate(new Admin()); // Если администратор.
            if (id == 2) NavigationService.Navigate(new Prodavez()); // Если продавец.
        }
    }
}