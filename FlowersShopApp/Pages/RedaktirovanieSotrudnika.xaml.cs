// Используемые пространства имен:
using FlowersShopApp.Model; // Доступ к моделям данных цветочного магазина.
using System; // Основные классы .NET, включая базовые типы и исключения.
using System.Data.Entity; // Классы Entity Framework для взаимодействия с базой данных.
using System.Linq; // Поддержка LINQ для запросов к коллекциям и базам данных.
using System.Runtime.Remoting.Contexts; // Классы для управления контекстами выполнения (не используется в WPF).
using System.Text.RegularExpressions; // Классы для работы с регулярными выражениями.
using System.Windows; // Классы для создания приложений на базе Windows Presentation Foundation (WPF).
using System.Windows.Controls; // Классы элементов управления WPF.

// Пространство имен для страниц приложения цветочного магазина.
namespace FlowersShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для страницы "Редактирование сотрудника" (RedaktirovanieSotrudnika.xaml).
    /// </summary>
    public partial class RedaktirovanieSotrudnika : Page
    {
        // Поля класса:
        public Sotrudniki sotrudnik; // Экземпляр класса Sotrudniki для хранения данных о сотруднике.
        public Shop_Model context; // Контекст базы данных для доступа к моделям данных.

        // Конструктор класса RedaktirovanieSotrudnika.
        public RedaktirovanieSotrudnika(int id)
        {
            InitializeComponent(); // Инициализация компонентов страницы.
            btnAdd.Visibility = Visibility.Collapsed; // Скрытие кнопки "Добавить".
            btnSave.Visibility = Visibility.Collapsed; // Скрытие кнопки "Сохранить".

            // Проверка переданного идентификатора сотрудника.
            if (id != 0)
            {
                btnSave.Visibility = Visibility.Visible; // Отображение кнопки "Сохранить".
                context = Shop_Model.GetContext(); // Получение контекста базы данных.
                sotrudnik = context.Sotrudniki.Where(s => s.id_sotrudnika == id).FirstOrDefault(); // Поиск сотрудника по идентификатору.

                // Заполнение полей формы данными сотрудника.
                txbFamiliya.Text = sotrudnik.familiya;
                txbImya.Text = sotrudnik.imya;
                txbOtchestvo.Text = sotrudnik.otchestvo;
                txbDoljnost.Text = GetDolgnost(sotrudnik.doljnost); // Получение названия должности.
                txbZarplata.Text = sotrudnik.zarplata.ToString(); // Отображение зарплаты сотрудника.
            }
            else
            {
                btnAdd.Visibility = Visibility.Visible; // Отображение кнопки "Добавить".
            }
        }

        // Обработчик события нажатия на кнопку "Сохранить".
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Валидация и присвоение значений полям сотрудника.
                sotrudnik.familiya = IsFIO(txbFamiliya.Text);
                sotrudnik.imya = IsFIO(txbImya.Text);
                sotrudnik.otchestvo = IsFIO(txbOtchestvo.Text);
                sotrudnik.doljnost = GetDolgnostId(txbDoljnost.Text);
                sotrudnik.zarplata = Convert.ToDouble(txbZarplata.Text);

                // Обновление данных сотрудника в базе данных.
                context.Entry(sotrudnik).State = EntityState.Modified;
                context.SaveChanges();

                // Уведомление пользователя об успешном изменении данных.
                MessageBox.Show("Данные изменены");
            }
            catch (Exception ex)
            {
                // Уведомление пользователя об ошибке.
                MessageBox.Show(ex.Message);
            }
        }

        // Метод для получения названия должности по идентификатору.
        private string GetDolgnost(int id)
        {
            string doljnost = "";
            // Определение названия должности.
            if (id == 1) doljnost = "Администратор";
            else if (id == 2) doljnost = "Продавец-консультант";
            return doljnost;
        }

        // Метод для получения идентификатора должности по названию.
        private int GetDolgnostId(string doljnost)
        {
            int id = 0;
            // Определение идентификатора должности.
            if (doljnost == "Администратор") id = 1;
            else if (doljnost == "Продавец-консультант") id = 2;
            else MessageBox.Show("Такой должности нет");
            return id;
        }

        // Метод для валидации ФИО.
        private string IsFIO(string str)
        {
            // Регулярное выражение для проверки ФИО.
            Regex formatFIO = new Regex("[а-яА-Я]");
            // Проверка соответствия строки регулярному выражению.
            if (formatFIO.Match(str).Success)
            {
                return str;
            }
            else
            {
                // Уведомление пользователя о некорректном вводе.
                MessageBox.Show("Используйте кириллицу, без дополнительных символов!!!");
                return "";
            }
        }

        // Обработчик события нажатия на кнопку "Добавить".
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создание нового экземпляра сотрудника.
                Sotrudniki sotrud = new Sotrudniki();
                var context = Shop_Model.GetContext();
                // Генерация случайного идентификатора сотрудника.
                sotrud.id_sotrudnika = new Random().Next(300, 1000);
                // Валидация и присвоение значений полям нового сотрудника.
                sotrud.familiya = IsFIO(txbFamiliya.Text);
                sotrud.imya = IsFIO(txbImya.Text);
                sotrud.otchestvo = IsFIO(txbOtchestvo.Text);
                sotrud.doljnost = GetDolgnostId(txbDoljnost.Text);
                sotrud.zarplata = Convert.ToDouble(txbZarplata.Text);

                // Проверка наличия контекста базы данных.
                if (context != null)
                {
                    // Добавление нового сотрудника в базу данных.
                    context.Sotrudniki.Add(sotrud);
                    context.SaveChanges();
                    // Уведомление пользователя о добавлении сотрудника.
                    MessageBox.Show("Сотрудник добавлен");
                }
                else
                {
                    // Уведомление пользователя о необходимости повторить попытку.
                    MessageBox.Show("Повторите попытку");
                }

            }
            catch (Exception ex)
            {
                // Уведомление пользователя об ошибке.
                MessageBox.Show(ex.Message);
            }
        }
    }
}