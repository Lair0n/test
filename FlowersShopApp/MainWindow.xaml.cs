using System; // Используется для включения базовых системных классов.
using System.Windows; // Используется для доступа к классам, которые составляют структуру приложения WPF.
using FlowersShopApp.Model; // Подключение моделей приложения цветочного магазина.
using FlowersShopApp.Pages; // Подключение страниц приложения цветочного магазина.

namespace FlowersShopApp
{
    // Основное окно приложения, наследующее от класса Window.
    public partial class MainWindow : Window
    {
        // Конструктор основного окна.
        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов, определенных в XAML.
            FrameMain.Navigate(new Avtor()); // Навигация к странице авторизации при запуске.
            Shop_Model.GetContext(); // Получение контекста данных для модели магазина.
        }

        // Обработчик события, вызываемый после рендеринга содержимого Frame.
        private void FrameMain_ContentRendered(object sender, EventArgs e)
        {
            // Проверка, есть ли в истории навигации предыдущие страницы.
            if (FrameMain.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible; // Показать кнопку "Назад", если можно вернуться.
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden; // Скрыть кнопку "Назад", если нельзя вернуться.
            }
        }

        // Обработчик события нажатия на кнопку.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.GoBack(); // Возврат к предыдущей странице в истории навигации.
        }
    }
}