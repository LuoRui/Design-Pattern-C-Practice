using System;
using System.Collections.Generic;
namespace FilterPattern
{
    /// <summary>
    /// 过滤器模式
    /// </summary>
    public class FilterPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------FilterPattern Practice:----------------------------");

            #region Step4 使用不同的标准（Criteria）和它们的结合来过滤 Person 对象的列表
            List<Person> persons = new List<Person>();
            persons.Add(new Person("Robert", "Male", "Single"));
            persons.Add(new Person("John", "Male", "Married"));
            persons.Add(new Person("Laura", "Female", "Married"));
            persons.Add(new Person("Diana", "Female", "Single"));
            persons.Add(new Person("Mike", "Male", "Single"));
            persons.Add(new Person("Bobby", "Male", "Single"));

            Criteria male = new CriteriaMale();
            Criteria female = new CriteriaFemale();
            Criteria single = new CriteriaSingle();
            Criteria singleMale = new AndCriteria(single, male);
            Criteria singleOrFemale = new OrCriteria(single, female);

            PrintPersons("Males", male.MeetCriteria(persons));
            PrintPersons("Females", female.MeetCriteria(persons));
            PrintPersons("Single Males", singleMale.MeetCriteria(persons));
            PrintPersons("Single Or Females", singleOrFemale.MeetCriteria(persons));
            #endregion
        }

        public static void PrintPersons(string title, List<Person> persons)
        {
            Console.WriteLine($"---{title}---");
            foreach (var person in persons)
            {
                Console.WriteLine($"Name:{person.GetName()},Gender:{person.GetGender()},Marital Status:{person.GetMaritalStatus()}");
            }
        }
    }

    #region Step1 创建一个类，在该类上应用标准
    public class Person
    {
        private string Name;
        private string Gender;
        private string MaritalStatus;

        public Person(string name, string gender, string maritalStatus)
        {
            this.Name = name;
            this.Gender = gender;
            this.MaritalStatus = maritalStatus;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetGender()
        {
            return Gender;
        }

        public string GetMaritalStatus()
        {
            return MaritalStatus;
        }
    }
    #endregion

    #region Step2 为标准（Criteria）创建一个接口
    public interface Criteria
    {
        List<Person> MeetCriteria(List<Person> persons);
    }
    #endregion

    #region Step3 创建实现了 Criteria 接口的实体类
    public class CriteriaMale : Criteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> malePersons = new List<Person>();
            foreach (var person in persons)
            {
                if (person.GetGender().ToLower().Equals("male"))
                {
                    malePersons.Add(person);
                }
            }
            return malePersons;
        }
    }

    public class CriteriaFemale : Criteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> femalePersons = new List<Person>();
            foreach (var person in persons)
            {
                if (person.GetGender().ToLower().Equals("female"))
                {
                    femalePersons.Add(person);
                }
            }
            return femalePersons;
        }
    }

    public class CriteriaSingle : Criteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> singlePersons = new List<Person>();
            foreach (var person in persons)
            {
                if (person.GetMaritalStatus().ToLower().Equals("single"))
                {
                    singlePersons.Add(person);
                }
            }
            return singlePersons;
        }
    }

    public class AndCriteria : Criteria
    {
        private Criteria criteria;
        private Criteria otherCriteria;
        public AndCriteria(Criteria criteria, Criteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = criteria.MeetCriteria(persons);
            return otherCriteria.MeetCriteria(firstCriteriaPersons);
        }
    }

    public class OrCriteria : Criteria
    {
        private Criteria criteria;
        private Criteria otherCriteria;

        public OrCriteria(Criteria criteria, Criteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaItems = criteria.MeetCriteria(persons);
            List<Person> otherCriteriaItems = otherCriteria.MeetCriteria(persons);
            foreach (var person in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(person))
                {
                    firstCriteriaItems.Add(person);
                }
            }
            return firstCriteriaItems;
        }
    }
    #endregion
}
