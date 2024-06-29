using FlowersShopApp.Model; // Подключение модели данных приложения цветочного магазина.
using System; // Подключение пространства имён, содержащего базовые классы и типы данных.
using System.Collections.Generic; // Предоставляет классы для работы с коллекциями объектов.
using System.Configuration; // Предоставляет доступ к настройкам конфигурации приложения.
using System.Data.Entity; // Подключение Entity Framework для работы с базой данных.
using System.Globalization; // Предоставляет классы и методы для работы с культурой и форматированием.
using System.Linq; // Позволяет использовать LINQ-запросы для упрощения работы с данными.
using System.Runtime.Remoting.Contexts; // Предоставляет классы для работы с контекстами выполнения.
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
    /// <summary>
    /// Логика взаимодействия для страницы "Редактирование поставки" (RedaktirovaniePostavki.xaml).
    /// </summary>
    public partial class RedaktirovaniePostavki : Page
    {
        public Postavki postavka; // Объект для хранения данных о поставке.
        public Shop_Model context; // Контекст для работы с базой данных.

        // Конструктор страницы редактирования поставок.
        public RedaktirovaniePostavki(int id)
        {
            InitializeComponent(); // Инициализация компонентов страницы, определенных в XAML.
            btnAdd.Visibility = Visibility.Collapsed; // Скрытие кнопки добавления.
            btnSave.Visibility = Visibility.Collapsed; // Скрытие кнопки сохранения.
            if (id != 0) // Если передан идентификатор поставки.
            {
                btnSave.Visibility = Visibility.Visible; // Показать кнопку сохранения.
                context = Shop_Model.GetContext(); // Получение контекста данных.
                // Загрузка данных о поставке из базы данных.
                postavka = context.Postavki.Where(s => s.id_postavki == id).FirstOrDefault();
                // Заполнение полей данными о поставке.
                txbPostavschik.Text = postavka.Postavschiki.naimenovanie;
                txbZvety.Text = postavka.Zvety.imya;
                txbData.Text = postavka.data_postavki.ToString();
                txbKolichestvo.Text = postavka.kolichestvo.ToString();
            }
            else
            {
                btnAdd.Visibility = Visibility.Visible; // Показать кнопку добавления.
            }
        }

        // Обработчик события нажатия на кнопку сохранения изменений поставки.
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Поиск поставщика по названию.
                var postavschik = context.Postavschiki.Where(p => p.naimenovanie == txbPostavschik.Text).FirstOrDefault();
                if (postavschik != null) // Если поставщик найден.
                {
                    postavka.id_postavschika = postavschik.id_postavschika; // Обновление идентификатора поставщика.
                }
                else
                {
                    MessageBox.Show("Такого поставщика нет в базе данных"); // Сообщение об ошибке.
                }
                // Поиск цветка по имени.
                var zvetok = context.Zvety.Where(z => z.imya == txbZvety.Text).FirstOrDefault();
                if (zvetok != null) // Если цветок найден.
                {
                    postavka.id_zvetov = zvetok.id_zvetov; // Обновление идентификатора цветка.
                }
                else
                {
                    MessageBox.Show("Таких цветов нет в базе данных"); // Сообщение об ошибке.
                }
                // Проверка и преобразование даты поставки.
                postavka.data_postavki = IsDate(txbData.Text);
                // Преобразование количества цветов в числовой формат.
                postavka.kolichestvo = Convert.ToInt32(txbKolichestvo.Text);
                // Обновление состояния объекта поставки в контексте данных.
                context.Entry(postavka).State = EntityState.Modified;
                context.SaveChanges(); // Сохранение изменений в базе данных.
                MessageBox.Show("Данные изменены"); // Сообщение об успешном изменении данных.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Вывод сообщения об ошибке.
            }
        }

        // Метод для проверки корректности введенной даты.
        private DateTime IsDate(string dateInput)
        {
            DateTime date;
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            // Попытка преобразования строки в дату с использованием указанного формата.
            if (DateTime.TryParseExact(dateInput, "yyyy-mm-dd", cultureInfo, DateTimeStyles.None, out date))
            {
                // Если преобразование успешно, ничего не делаем.
            }
            else
            {
                // Если формат даты неверен, выводим сообщение об ошибке.
                MessageBox.Show("Используйте правильный формат yyyy-mm-dd ");
            }

            return date; // Возвращаем полученную дату.
        }

        // Обработчик события нажатия на кнопку добавления новой поставки.
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context = Shop_Model.GetContext(); // Получение контекста данных.
                Postavki postavka = new Postavki(); // Создание нового объекта поставки.
                // Генерация случайного идентификатора для новой поставки.
                postavka.id_postavki = new Random().Next(150, 1000);
                // Поиск поставщика по названию.
                var postavschik = context.Postavschiki.Where(p => p.naimenovanie == txbPostavschik.Text).FirstOrDefault();
                if (postavschik != null) // Если поставщик найден.
                {
                    postavka.id_postavschika = postavschik.id_postavschika; // Установка идентификатора поставщика.
                }
                else
                {
                    MessageBox.Show("Такого поставщика нет в базе данных"); // Сообщение об ошибке.
                }
                // Поиск цветка по имени.
                var zvetok = context.Zvety.Where(z => z.imya == txbZvety.Text).FirstOrDefault();
                if (zvetok != null) // Если цветок найден.
                {
                    postavka.id_zvetov = zvetok.id_zvetov; // Установка идентификатора цветка.
                }
                else
                {
                    MessageBox.Show("Таких цветов нет в базе данных"); // Сообщение об ошибке.
                }
                // Проверка и преобразование даты поставки.
                postavka.data_postavki = IsDate(txbData.Text);
                // Преобразование количества цветов в числовой формат.
                postavka.kolichestvo = Convert.ToInt32(txbKolichestvo.Text);
                if (context != null) // Если контекст данных существует.
                {
                    context.Postavki.Add(postavka);
                    context.SaveChanges();
                    MessageBox.Show("Поставка добавлена");
                }
                else 
                {
                    MessageBox.Show("Попробуйте снова");
                }
                
                
            }
            catch (Exception ex) 
            { 
            
            }
            
        }
    }
}
