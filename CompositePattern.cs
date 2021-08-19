using System;
using System.Collections.Generic;
namespace CompositePattern
{
    /// <summary>
    /// 组合模式
    /// </summary>
    public class CompositePattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------CompositePattern Practice:----------------------------");

            #region Step2 使用 Employee 类来创建和打印员工的层次结构
            Employee CEO = new Employee("John", "CEO", 30000);
            Employee headSales = new Employee("Robert", "Head Sales", 20000);
            Employee headMarketing = new Employee("Michel", "Head Marketing", 20000);
            Employee clerk1 = new Employee("Laura", "Marketing", 10000);
            Employee clerk2 = new Employee("Bob", "Marketing", 10000);
            Employee salesExecutive1 = new Employee("Richard", "Sales", 10000);
            Employee salesExecutive2 = new Employee("Rob", "Sales", 10000);

            CEO.Add(headSales);
            CEO.Add(headMarketing);
            headSales.Add(salesExecutive1);
            headSales.Add(salesExecutive2);
            headMarketing.Add(clerk1);
            headMarketing.Add(clerk1);

            Console.WriteLine(CEO.ToString());
            foreach (Employee headEmployee in CEO.GetSubordinates())
            {
                Console.WriteLine(headEmployee.ToString());
                foreach (Employee employee in headEmployee.GetSubordinates())
                {
                    Console.WriteLine(employee.ToString());
                }
            }
            #endregion
        }
    }

    #region Step1 创建 Employee 类，该类带有 Employee 对象的列表
    public class Employee
    {
        private string name;
        private string dept;
        private int salary;
        private List<Employee> subordinates;

        public Employee(string name, string dept, int sal)
        {
            this.name = name;
            this.dept = dept;
            this.salary = sal;
            subordinates = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            subordinates.Add(employee);
        }

        public void Remove(Employee employee)
        {
            subordinates.Remove(employee);
        }

        public List<Employee> GetSubordinates()
        {
            return subordinates;
        }

        public override string ToString()
        {
            return $"Employee:[Name:{name},dept:{dept},salary:{salary}]";
        }
    }
    #endregion
}
