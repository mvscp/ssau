using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace LR03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 3. Перечисления");
            Console.WriteLine("по курсу \"Основы программирования\"");
            Console.WriteLine("Выполнил студент группы 6104 Лукашевич Р.К.");
            Console.WriteLine("Введите длину массива");
            int n = Int32.Parse(Console.ReadLine());
            Employee[] employees = new Employee[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Заполнение данных {0} сотрудника: ", i + 1);
                Console.Write("Введите имя сотрудника в формате Фамилия И.О.: ");
                employees[i].Name = Convert.ToString(Console.ReadLine());
                Console.Write("Введите доход: ");
                try
                {
                    int salary = Int32.Parse(Console.ReadLine());
                    employees[i].Salary = salary;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Требуется ввести целое значение");
                }
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Введите должность: ");
                    Console.WriteLine("1 - Менеджер\n2 - Босс\n3 - Клерк\n4 - Продавец");
                    int v = Int32.Parse(Console.ReadLine());
                    switch (v)
                    {
                        case 1:
                            employees[i].Vacancy = Vacancies.Manager;
                            flag = false;
                            break;
                        case 2:
                            employees[i].Vacancy = Vacancies.Boss;
                            flag = false;
                            break;
                        case 3:
                            employees[i].Vacancy = Vacancies.Clerk;
                            flag = false;
                            break;
                        case 4:
                            employees[i].Vacancy = Vacancies.Salesman;
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Некорректное значение");
                            break;
                    }
                }
                Console.Write("Введите дату приема на работу в формате дд.мм.гг: ");
                string d = Convert.ToString(Console.ReadLine());
                CultureInfo enUS = new CultureInfo("en-US");
                try
                {
                    DateTime value = DateTime.ParseExact(d, "dd.MM.yy", enUS, System.Globalization.DateTimeStyles.None);
                    employees[i].Hiredate = value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат даты");
                }
            }
            bool flag1 = true;
            while (flag1)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Вывести информацию обо всех сотрудниках\n2 - Вывести информацию о сотрудниках указанной должности\n" +
                    "3 - Найти в массиве всех менеджеров, зарплата которых больше средней зарплаты всех клерков," +
                    " вывести на экран полную информацию о таких менеджерах, отсортировать в алфавитном порядке по фамилии\n" +
                    "4 - Вывести полную информацию обо всех сотрудниках, принятых на работу позже босса, отсортированную в алфавитном порядке по фамилии сотрудника\n" +
                    "0 - Выход");
                string menu = Convert.ToString(Console.ReadLine());
                switch (menu)
                {
                    case "1":
                        for (int i = 0; i < n; i++)
                            Console.WriteLine(employees[i].ToString());
                        break;
                    case "2":
                        Vacancies choice = Vacancies.Manager;
                        bool flag = true;
                        while (flag)
                        {
                            Console.WriteLine("Введите должность: ");
                            Console.WriteLine("1 - Менеджер\n2 - Босс\n3 - Клерк\n4 - Продавец");
                            int v = Int32.Parse(Console.ReadLine());
                            switch (v)
                            {
                                case 1:
                                    choice = Vacancies.Manager;
                                    flag = false;
                                    break;
                                case 2:
                                    choice = Vacancies.Boss;
                                    flag = false;
                                    break;
                                case 3:
                                    choice = Vacancies.Clerk;
                                    flag = false;
                                    break;
                                case 4:
                                    choice = Vacancies.Salesman;
                                    flag = false;
                                    break;
                                default:
                                    Console.WriteLine("Некорректное значение");
                                    break;
                            }
                        }
                        int c = 0;
                        for (int i = 0; i < n; i++)
                        {
                            if (employees[i].Vacancy == choice)
                            {
                                Console.WriteLine(employees[i].ToString());
                                c++;
                            }
                        }
                        if (c == 0)
                            Console.WriteLine("Сотрудники указанной должности не найдены");
                        break;
                    case "3":
                        List<Employee> x1 = new List<Employee>();
                        double salaryClerk = 0;
                        int clerkCount = 0;
                        int managerCount = 0;
                        for (int i = 0; i < n; i++)
                        {
                            if (employees[i].Vacancy == Vacancies.Clerk)
                            {
                                salaryClerk += employees[i].Salary;
                                clerkCount++;
                            }
                            else if (employees[i].Vacancy == Vacancies.Manager)
                            {
                                x1.Add(employees[i]);
                                managerCount++;
                            }
                        }
                        salaryClerk /= clerkCount;
                        foreach (Employee i in x1)
                        {
                            if (i.Salary < salaryClerk)
                            {
                                x1.Remove(i);
                                managerCount--;
                            }
                        }
                        Employee[] managers = new Employee[managerCount];
                        x1.CopyTo(managers);
                        Employee.Sort(managers);
                        foreach (Employee i in managers)
                            Console.WriteLine(i.ToString());
                        break;
                    case "4":
                        List<Employee> x2 = new List<Employee>();
                        Employee boss = new Employee();
                        for (int i = 0; i < n; i++)
                        {
                            if (employees[i].Vacancy == Vacancies.Boss)
                                boss = employees[i];
                        }
                        if (boss.Salary == 0)
                        {
                            Console.WriteLine("Босса нет");
                            break;
                        }
                        int count = 0;
                        for (int i = 0; i < n; i++)
                        {
                            if (employees[i].Hiredate > boss.Hiredate)
                            {
                                x2.Add(employees[i]);
                                count++;
                            }
                        }
                        Employee[] mas = new Employee[count];
                        x2.CopyTo(mas);
                        Employee.Sort(mas);
                        foreach (Employee i in mas)
                            Console.WriteLine(i.ToString());
                        break;
                    case "0":
                        flag1 = false;
                        break;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
            }
        }
    }
}
