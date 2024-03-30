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
        City SelectedCityObj = new City("");
        Workshop SelectedWorkshopObj = new Workshop("");
        Employee SelectedEmployeeObj = new Employee("");

        DataManager Base = new DataManager();

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация данных
            Base.InitializeData();

            // Заполнение ComboBox'ов
            foreach (var city in Base.Cities)
            {
                CityBox.Items.Add(city.Name);
                foreach (var workshop in city.Workshops)
                {
                    WorkshopBox.Items.Add(workshop.Name);
                    foreach (var employee in workshop.Employees)
                    {
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
            SelectedCityObj = Base.Cities.FirstOrDefault(c => c.Name == CityBox.SelectedItem as string);
            WorkshopBox.Items.Clear();
            if (SelectedCityObj != null)
            {
                //
                if (SelectedCityObj.Workshops.Any())
                {
                    foreach (var workshop in SelectedCityObj.Workshops)
                    {
                        WorkshopBox.Items.Add(workshop.Name);
                    }
                    EmployeeBox.Items.Clear();
                    foreach (var workshop in SelectedCityObj.Workshops)
                    {
                        foreach (var employee in workshop.Employees)
                        {
                            EmployeeBox.Items.Add(employee.Name);
                        }
                    }
                }
                else
                {
                    EmployeeBox.Items.Clear();
                    foreach (var work in Base.AllWorkshops)
                    {
                        WorkshopBox.Items.Add(work.Name);
                    }
                    foreach (var emp in Base.AllEmployees)
                    {
                        EmployeeBox.Items.Add(emp.Name);
                    }
                }
            }
        }
        private void WorkshopBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (SelectedCityObj == null)
            {
                SelectedWorkshopObj = SelectedCityObj.Workshops.FirstOrDefault(w => w.Name == WorkshopBox.SelectedItem as string);
                EmployeeToBox();
            }
            else if (WorkshopBox.SelectedItem != null)
            {
                SelectedWorkshopObj = Base.AllWorkshops.FirstOrDefault(w => w.Name == WorkshopBox.SelectedItem as string);
                EmployeeToBox();
            }
        }
        private void EmployeeBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string selectedEmployeeName = EmployeeBox.SelectedItem as string;
            SelectedEmployeeObj = Base.AllEmployees.FirstOrDefault(em => em.Name == selectedEmployeeName);

            if (SelectedEmployeeObj != null && SelectedEmployeeObj.Workshop != null && SelectedEmployeeObj.Workshop.City != null)
            {
                string selectedCityName = SelectedEmployeeObj.Workshop.City.Name;
                string selectedWorkshopName = SelectedEmployeeObj.Workshop.Name;
                CityBox.SelectedItem = selectedCityName;
                WorkshopBox.SelectedItem = selectedWorkshopName;
                EmployeeBox.SelectedItem = selectedEmployeeName;
            }
        }
        public void BrigadeBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var SelectedBrigadeObj = Base.Brigades.FirstOrDefault(b => b.Name == BrigadeBox.SelectedItem as string);
        }
        public void ShiftString_SomeWrote(object sender, RoutedEventArgs e)
        {
            if (ShiftString.Text.Length >= 6 && ShiftString.Text.Length < 7)
            {
                Right.IsChecked = true;
            }
            else
            {
                Right.IsChecked = false;
            }
        }
        void EmployeeToBox()
        {
            EmployeeBox.Items.Clear();
            if (SelectedWorkshopObj != null)
            {
                foreach (var employee in SelectedWorkshopObj.Employees)
                {
                    EmployeeBox.Items.Add(employee.Name);
                }
            }
        }
    }
}
