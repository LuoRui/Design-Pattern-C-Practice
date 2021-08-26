using System;
using System.Collections.Generic;
namespace TransferObjectPattern
{
    /// <summary>
    /// 传输对象模式
    /// </summary>
    public class TransferObjectPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------TransferObjectPattern Practice:----------------------------");

            #region Step3 使用StudeontBO来演示传输对象模式
            StudentBO studentBusinessObject = new StudentBO();

            foreach (StudentVO student in studentBusinessObject.GetAllStudents())
            {
                Console.WriteLine($"Student:[RollNo:{student.GetRollNo()},Name:{student.GetName()}]");
            }

            StudentVO student1 = studentBusinessObject.GetAllStudents()[0];
            student1.SetName("MasterKing");
            studentBusinessObject.UpdateStudent(student1);

            student1 = studentBusinessObject.GetStudent(0);
            Console.WriteLine($"Student:[RollNo:{student1.GetRollNo()},Name:{student1.GetName()}]");
            #endregion
        }
    }

    #region Step1 创建传输对象
    public class StudentVO
    {
        private string name;
        private int rollNo;

        public StudentVO(string name, int rollNo)
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

    #region Step2 创建业务对象
    public class StudentBO
    {
        List<StudentVO> students;

        public StudentBO()
        {
            students = new List<StudentVO>();
            StudentVO student1 = new StudentVO("StrayCat", 0);
            StudentVO student2 = new StudentVO("Roger", 1);
            students.Add(student1);
            students.Add(student2);
        }

        public void DeleteStudent(StudentVO student)
        {
            students.Remove(student);
            Console.WriteLine($"Student:RollNo {student.GetRollNo()},deleted from database");
        }

        public List<StudentVO> GetAllStudents()
        {
            return students;
        }

        public StudentVO GetStudent(int rollNo)
        {
            return students.Find(s => s.GetRollNo() == rollNo);
        }

        public void UpdateStudent(StudentVO student)
        {
            students.Find(s => s.GetRollNo() == student.GetRollNo()).SetName(student.GetName());
            Console.WriteLine($"Student:RollNo {student.GetRollNo()},update in the database");
        }
    }
    #endregion
}
