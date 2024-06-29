using FlowersShopApp.Model; // Доступ к моделям данных приложения цветочного магазина.
using System; // Фундаментальные классы базовой библиотеки .NET.
using System.Collections.Generic; // Классы для работы с коллекциями данных.
using System.Data.Entity; // Классы Entity Framework для работы с базой данных.
using System.Linq; // Поддержка LINQ для запросов к коллекциям.
using System.Runtime.Remoting.Contexts; // Классы для управления контекстами выполнения.
using System.Security.Cryptography.X509Certificates; // Классы для работы с X.509 сертификатами.
using System.Text; // Классы для работы со строками и текстовыми энкодерами.
using System.Text.RegularExpressions; // Классы для работы с регулярными выражениями.
using System.Threading.Tasks; // Поддержка асинхронного программирования.
using System.Windows; // Классы для создания приложений на базе WPF.
using System.Windows.Controls; // Классы элементов управления WPF.
using System.Windows.Data; // Классы для привязки данных в WPF.
using System.Windows.Documents; // Классы для работы с документами WPF.
using System.Windows.Input; // Классы для обработки ввода пользователя в WPF.
using System.Windows.Media; // Классы для работы с графикой в WPF.
using System.Windows.Media.Imaging; // Классы для работы с изображениями в WPF.
using System.Windows.Navigation; // Классы для навигации в WPF.
using System.Windows.Shapes; // Классы для рисования фигур в WPF.

// Пространство имен для страниц приложения цветочного магазина.
namespace FlowersShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для страницы "Редактирование склада" (RedaktirovanieSklad.xaml).
    /// </summary>
    public partial class RedaktirovanieSklad : Page
    {
        // Поля класса:
        public Sklad sklad; // Экземпляр класса Sklad для хранения данных о складе.
        public Shop_Model context; // Контекст базы данных для доступа к моделям данных.

        // Конструктор класса RedaktirovanieSklad.
        public RedaktirovanieSklad(int id)
        {
            InitializeComponent(); // Инициализация компонентов страницы.
            btnAdd.Visibility = Visibility.Collapsed; // Скрытие кнопки "Добавить".
            btnSave.Visibility = Visibility.Collapsed; // Скрытие кнопки "Сохранить".

            // Проверка переданного идентификатора склада.
            if (id != 0)
            {
                btnSave.Visibility = Visibility.Visible; // Отображение кнопки "Сохранить".
                context = Shop_Model.GetContext(); // Получение контекста базы данных.
                sklad = context.Sklad.FirstOrDefault(s => s.id_sklada == id); // Поиск склада по идентификатору.

                // Заполнение полей формы данными склада.
                txbAdres.Text = sklad.adres;
                txbZvety.Text = sklad.Zvety.imya;
                txbKolichestvo.Text = sklad.kolichestvo.ToString();
            }
            else
            {
                btnAdd.Visibility = Visibility.Visible; // Отображение кнопки "Добавить".
            }
        }

        // Обработчик события клика по кнопке "Сохранить".
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Попытка сохранения изменений данных о складе.
            try
            {
                // Поиск цветка по имени.
                var zvetok = context.Zvety.FirstOrDefault(z => z.imya == txbZvety.Text);
                if (zvetok != null)
                {
                    sklad.id_zvetov = zvetok.id_zvetov; // Обновление идентификатора цветка.
                }
                else
                {
                    MessageBox.Show("Таких цветов нет в базе данных"); // Сообщение об ошибке.
                    return;
                }

                sklad.adres = IsAddres(txbAdres.Text); // Проверка и обновление адреса склада.
                sklad.kolichestvo = Convert.ToInt32(txbKolichestvo.Text); // Обновление количества цветов на складе.
                context.Entry(sklad).State = EntityState.Modified; // Отметка объекта как измененного.
                context.SaveChanges(); // Сохранение изменений в базе данных.
                MessageBox.Show("Данные изменены"); // Сообщение об успешном изменении данных.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Отображение сообщения об ошибке.
            }
        }

        // Метод для проверки корректности адреса.
        private string IsAddres(string addres)
        {
            // Регулярное выражение для проверки формата адреса.
            Regex format = new Regex(@"[а-яА-Я*\s]*\s\d+");
            if (format.IsMatch(addres)) // Проверка соответствия адреса формату.
            {
                return addres; // Возврат корректного адреса.
            }
            else
            {
                MessageBox.Show("Сначала введите улицу, а затем номер дома!!!"); // Сообщение об ошибке.
                return ""; // Возврат пустой строки в случае ошибки.
            }
        }

        // Обработчик события клика по кнопке "Добавить".
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Попытка добавления нового склада.
            try
            {
                Sklad newSklad = new Sklad(); // Создание нового экземпляра склада.
                var newContext = Shop_Model.GetContext(); // Получение контекста базы данных.
                newSklad.id_sklada = new Random().Next(300, 1000); // Генерация случайного идентификатора склада.
                newSklad.adres = IsAddres(txbAdres.Text); // Проверка и установка адреса склада.

                // Поиск цветка по имени.
                var newZvetok = newContext.Zvety.FirstOrDefault(z => z.imya == txbZvety.Text);
                if (newZvetok != null)
                {
                    newSklad.id_zvetov = newZvetok.id_zvetov; // Установка идентификатора цветка.
                }
                else
                {
                    MessageBox.Show("Таких цветов нет в базе данных"); // Сообщение об ошибке.
                    return;
                }

                newSklad.kolichestvo = Convert.ToInt32(txbKolichestvo.Text); // Установка количества цветов на складе.
                if (newContext != null)
                {
                    newContext.Sklad.Add(newSklad); // Добавление нового склада в базу данных.
                    newContext.SaveChanges(); // Сохранение изменений в базе данных.
                    MessageBox.Show("Склад добавлен"); // Сообщение об успешном добавлении склада.
                }
                else
                {
                    MessageBox.Show("Повторите попытку"); // Сообщение об ошибке.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Отображение сообщения об ошибке.
            }
        }
    }
}
