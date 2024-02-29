using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR03
{
    enum Vacancies
    {
        Manager,
        Boss,
        Clerk,
        Salesman
    }
    struct Employee
    {
        public string Name { get; set; }
        public Vacancies Vacancy { get; set; }
        public int Salary { get; set; }
        public DateTime Hiredate { get; set; }
        public Employee(string name, Vacancies vacancy, int salary, DateTime hiredate)
        {
            Name = name;
            Vacancy = vacancy;
            Salary = salary;
            Hiredate = hiredate;
        }
        public override string ToString()
        {
            string info = "Имя сотрудника: " + Name + "\n" + "Должность: " + Vacancy + "\n" +
                 "Доход: " + Salary + "\n" + "Дата приема на работу: " + Hiredate.ToShortDateString();
            return info;
        }
        public static void Sort(Employee[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                for (int j = 0; j < employees.Length - 1; j++)
                {
                    if (String.Compare(employees[j].Name, employees[j + 1].Name) > 0)
                    {
                        Employee swap = employees[j];
                        employees[j] = employees[j + 1];
                        employees[j + 1] = swap;
                    }
                }
            }
        }
    }
}
