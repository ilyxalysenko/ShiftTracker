using ShiftTracker.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models
{
    public class DataManager
    {
        internal List<City> Cities;
        internal List<Workshop> AllWorkshops;
        internal List<Employee> AllEmployees;
        internal List<Brigade> Brigades;

        public void InitializeData()
        {
            

            AllWorkshops = new List<Workshop>();
            AllEmployees = new List<Employee>();

            // Создание списка городов
            Cities = new List<City>
            {
                new City("<>"),
                new City("Москва (City 1)"),
                new City("С-Петербург (City 2)")
            };
            
            // Создание списка цехов
            Cities[1].Workshops = new List<Workshop>
            {
                new Workshop("Империя красок (Workshop 1.1)"),
                new Workshop("Золотые руки (Workshop 1.2)")
            };

            Cities[2].Workshops = new List<Workshop>
            {
                new Workshop("Мастерская творчества (Workshop 2.1)"),
                new Workshop("Художественное разнообразие (Workshop 2.2)")
            };

            // Создание списка сотрудников
            Cities[1].Workshops[0].Employees = new List<Employee>
            {
                new Employee("Александр (Employee 1.1.1)"),
                new Employee("Елена (Employee 1.1.2)")
            };
            Cities[1].Workshops[1].Employees = new List<Employee>
            {
                new Employee("Иван (Employee 1.2.1)"),
                new Employee("Катерина (Employee 1.2.2)")
            };
            Cities[2].Workshops[0].Employees = new List<Employee>
            {
                new Employee("Максим (Employee 2.1.1)"),
                new Employee("Наталья (Employee 2.1.2)")
            };
            Cities[2].Workshops[1].Employees = new List<Employee>
            {
                new Employee("Олег (Employee 2.2.1)"),
                new Employee("София (Employee 2.2.2)")
            };
            // Создание бригад
            Brigades = new List<Brigade>
            {
                new Brigade("Точные техники"),
                new Brigade("Команда спасения")
            };
            Cities[0].Workshops = new List<Workshop>(); 
            //foreach (var work in Cities[0].Workshops) { work.Employees = AllEmployees; }
            foreach (var city in Cities)
            {
                for (int i = 0; i < city.Workshops.Count; i++)
                {
                    var workshop = city.Workshops[i];
                    workshop.City = city;
                    AllWorkshops.Add(workshop);

                    for (int j = 0; j < workshop.Employees.Count; j++)
                    {
                        var employee = workshop.Employees[j];
                        employee.Workshop = workshop;
                        employee.City = workshop.City;
                        AllEmployees.Add(employee);
                    }
                }
            }
        }
    }
}
