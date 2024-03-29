using ShiftTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
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

namespace ShiftTracker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string SelectedCityName;
        string SelectedWorkshopName;
        City SelectedCityObj;
        Workshop SelectedWorkshopObj;
        IEnumerable<Workshop> SelectedCityWorkshops;

        DataManager Base = new DataManager();

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация данных
            Base.InitializeData();

            // Заполнение
            foreach (var city in Base.Cities)
            {
                CityBox.Items.Add(city.Name);
                for (int i = 0; i < city.Workshops.Count; i++)
                {
                    var workshop = city.Workshops[i];
                    WorkshopBox.Items.Add(workshop.Name);

                    for (int j = 0; j < workshop.Employees.Count; j++)
                    {
                        var employee = workshop.Employees[j];
                        EmployeeBox.Items.Add(employee.Name);
                    }
                }
            }
            foreach (var brigade in Base.Brigades)
            {
                BrigadeBox.Items.Add(brigade.Name);
            }
        }



        private void CityBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            SelectedCityName = CityBox.SelectedItem as string;

            // Очистка списка цехов
            WorkshopBox.Items.Clear();

            // Получение объекта выбранного города
            SelectedCityObj = Base.Cities.FirstOrDefault(c => c.Name == SelectedCityName);

            if (SelectedCityObj != null)
            {
                // Заполнение выпадающего списка цехов на основе выбранного города
                SelectedCityWorkshops = Base.AllWorkshops.Where(w => w.City.Name == SelectedCityName);

                if (SelectedCityWorkshops.Count() > 0)
                {
                    foreach (var workshop in SelectedCityWorkshops)
                    {
                        WorkshopBox.Items.Add(workshop.Name);
                    }
                }
                else
                {
                    WorkshopBox.Items.Add("Нет доступных цехов для выбранного города");
                }
            }
            // Заполнение выпадающего списка сотрудников на основе выбранного города
            // Очистка списка сотрудников
            if (SelectedCityObj != null)
            {
                EmployeeBox.Items.Clear();
                foreach (var workshop in SelectedCityObj.Workshops)
                {
                    foreach (var employee in workshop.Employees)
                    {
                        EmployeeBox.Items.Add(employee.Name);
                    }
                }
            }
        }


        private void WorkshopBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            SelectedWorkshopName = WorkshopBox.SelectedItem as string;

            // Получение объекта выбранного города
            SelectedCityObj = Base.Cities.FirstOrDefault(c => c.Name == CityBox.SelectedItem as string);

            if (SelectedCityObj != null)
            {
                // Получение объекта выбранного цеха
                SelectedWorkshopObj = SelectedCityObj.Workshops.FirstOrDefault(w => w.Name == SelectedWorkshopName);

                // Очистка списка сотрудников
                EmployeeBox.Items.Clear();
                if (SelectedWorkshopObj != null)
                {
                    // Заполнение выпадающего списка сотрудников на основе выбранного цеха
                    foreach (var employee in SelectedWorkshopObj.Employees)
                    {
                        EmployeeBox.Items.Add(employee.Name);
                    }
                }
            }
        }



        public void EmployeeBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        public void BrigadeBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        public void ShiftString_SomeWrote(object sender, RoutedEventArgs e)
        {
            if (ShiftString.Text.Length >= 6)
            {
                string text = ShiftString.Text;
                Right.IsChecked = true;
                ShiftString.IsReadOnly = true;
            }

        }
    }
}
