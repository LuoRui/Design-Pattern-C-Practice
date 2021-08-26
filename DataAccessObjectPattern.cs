using System;
using System.Collections.Generic;
namespace DataAccessObjectPattern
{
    /// <summary>
    /// 数据访问对象模式
    /// </summary>
    public class DataAccessObjectPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------DataAccessObjectPattern Practice:----------------------------");

            #region Step4 演示数据访问对象模式的用法
            IStudentDao studentDao = new StudentDaoImpl();
            foreach (var student in studentDao.GetAllStudents())
            {
                Console.WriteLine($"Student:[RollNo:{student.GetRollNo()},Name:{student.GetName()}]");
            }

            Student student1 = studentDao.GetAllStudents()[0];
            student1.SetName("Michael");
            studentDao.UpdateStudent(student1);

            studentDao.GetStudent(0);
            Console.WriteLine($"Student:[RollNo:{student1.GetRollNo()},Name:{student1.GetName()}]");
            #endregion
        }
    }

    #region Step1 创建数值对象
    public class Student
    {
        private string name;
        private int rollNo;

        public Student(string name, int rollNo)
        {
            this.name = name;
            this.rollNo = rollNo;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetRollNo()
        {
            return rollNo;
        }

        public void SetRollNo(int rollNo)
        {
            this.rollNo = rollNo;
        }
    }
    #endregion

    #region Step2 创建数据访问对象接口
    public interface IStudentDao
    {
        List<Student> GetAllStudents();
        Student GetStudent(int rollNo);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
    #endregion

    #region Step3 创建实现了上述接口的实体类
    public class StudentDaoImpl : IStudentDao
    {
        List<Student> students;

        public StudentDaoImpl()
        {
            students = new List<Student>();
            Student student1 = new Student("Robert", 0);
            Student student2 = new Student("John", 1);
            students.Add(student1);
            students.Add(student2);
        }

        public void DeleteStudent(Student student)
        {
            students.Remove(student);
            Console.WriteLine($"Student:RollNo {student.GetRollNo()},delete from database");
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudent(int rollNo)
        {
            return students.Find(s => s.GetRollNo() == rollNo);
        }

        public void UpdateStudent(Student student)
        {
            students.Find(s => s.GetRollNo() == student.GetRollNo()).SetName(student.GetName());
            Console.WriteLine($"Student:RollNo {student.GetRollNo()},updated in the database");
        }
    }
    #endregion
}
