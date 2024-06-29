using System; // Подключение пространства имён, содержащего фундаментальные и базовые классы.
using System.Collections.Generic; // Предоставляет классы для работы с коллекциями объектов.
using System.Linq; // Поддержка LINQ (Language Integrated Query) для коллекций.
using System.Text; // Классы для работы со строками в кодировке Unicode.
using System.Threading.Tasks; // Поддержка асинхронного программирования с использованием задач.
using System.Windows; // Основные классы для работы с приложениями WPF.
using System.Windows.Controls; // Классы для работы с элементами управления в WPF.
using System.Windows.Data; // Классы для привязки данных в WPF.
using System.Windows.Documents; // Классы для работы с документами.
using System.Windows.Input; // Классы для работы с вводом пользователя в WPF.
using System.Windows.Media; // Классы для работы с графикой и мультимедиа.
using System.Windows.Media.Imaging; // Классы для работы с изображениями.
using System.Windows.Navigation; // Классы для навигации между страницами.
using System.Windows.Shapes; // Классы для рисования графических фигур.

namespace FlowersShopApp.Pages
{
    // Определение класса страницы администратора, наследующего от класса Page.
    public partial class Admin : Page
    {
        // Конструктор страницы администратора.
        public Admin()
        {
            InitializeComponent(); // Инициализация компонентов страницы, определенных в XAML.
        }

        // Обработчик события нажатия на кнопку "Склады".
        private void btnSklady_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SpisokSkladov()); // Навигация к странице со списком складов.
        }

        // Обработчик события нажатия на кнопку "Поставки".
        private void btnPostavki_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SpisokPostavok()); // Навигация к странице со списком поставок.
        }

        // Обработчик события нажатия на кнопку "Сотрудники".
        private void btnSotrudniki_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SpisokSotrudnikov()); // Навигация к странице со списком сотрудников.
        }
    }
}