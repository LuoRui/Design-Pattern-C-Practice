using System;
namespace MVCPattern
{
    /// <summary>
    /// MVC模式
    /// </summary>
    public class MVCPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------MVCPattern Practice:----------------------------");

            #region Step4 使用StudentController方法来演示MVC设计模式的用法
            Student model = RetrieveStudentFromDatabase();
            StudentView view = new StudentView();
            StudentController controller = new StudentController(model, view);
            controller.UpdateView();

            controller.SetStudentName("Roger");
            controller.UpdateView();
            #endregion
        }

        private static Student RetrieveStudentFromDatabase()
        {
            Student student = new Student();
            student.SetName("StrayCat");
            student.SetRollNo("10");
            return student;
        }
    }

    #region Step1 创建模型
    public class Student
    {
        private string rollNo;
        private string name;
        public string GetRollNo()
        {
            return rollNo;
        }
        public void SetRollNo(string rollNo)
        {
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
    }
    #endregion

    #region Step2 创建视图
    public class StudentView
    {
        public void PrintStudentDetails(string studentName, string studentRollNo)
        {
            Console.WriteLine("Student:");
            Console.WriteLine($"Name:{studentName}");
            Console.WriteLine($"Roll No:{studentRollNo}");
        }
    }
    #endregion

    #region Step3 创建控制器
    public class StudentController
    {
        private Student model;
        private StudentView view;

        public StudentController(Student model, StudentView view)
        {
            this.model = model;
            this.view = view;
        }

        public void SetStudentName(string name)
        {
            model.SetName(name);
        }

        public string GetStudentName()
        {
            return model.GetName();
        }

        public void SetStudentRollNo(string rollNo)
        {
            model.SetRollNo(rollNo);
        }

        public string GetStudentRollNo()
        {
            return model.GetRollNo();
        }

        public void UpdateView()
        {
            view.PrintStudentDetails(model.GetName(), model.GetRollNo());
        }
    }
    #endregion
}
