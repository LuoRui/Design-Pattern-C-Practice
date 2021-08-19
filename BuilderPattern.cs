using System;
using System.Collections.Generic;
namespace BuilderPattern
{
    /// <summary>
    /// 建造者模式
    /// </summary>
    public class BuilderPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------BuilderPattern Practice:----------------------------");

            #region Step7 使用 MealBuilder 来演示建造者模式
            MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.PrepareVegMeal();
            vegMeal.ShowMealInfo("Veg Meal");

            Meal nonVegMeal = mealBuilder.PrepareNonVegMeal();
            nonVegMeal.ShowMealInfo("NonVeg Meal");
            #endregion
        }
    }

    #region Step1 创建表示食物条目和食物包装的接口
    public interface IPacking
    {
        string Pack();
    }

    public interface IItem
    {
        string name();
        IPacking packing();
        float price();
    }
    #endregion

    #region Step2 创建实现 Packing 接口的实体类
    public class Wrapper : IPacking
    {
        public string Pack()
        {
            return "Wrapper";
        }
    }

    public class Bottle : IPacking
    {
        public string Pack()
        {
            return "Bottle";
        }
    }
    #endregion

    #region Step3 创建实现 Item 接口的抽象类，该类提供了默认的功能
    public abstract class Burger : IItem
    {
        public abstract string name();
        public abstract float price();

        public IPacking packing()
        {
            return new Wrapper();
        }
    }

    public abstract class ColdDrink : IItem
    {
        public abstract string name();
        public abstract float price();

        public IPacking packing()
        {
            return new Bottle();
        }
    }
    #endregion

    #region Step4 创建扩展了 Burger 和 ColdDrink 的实体类
    public class VegBurger : Burger
    {
        public override string name()
        {
            return "Veg Burger";
        }

        public override float price()
        {
            return 25.0f;
        }
    }

    public class ChickenBurger : Burger
    {
        public override string name()
        {
            return "Chicken Burger";
        }

        public override float price()
        {
            return 50.5f;
        }
    }

    public class Coke : ColdDrink
    {
        public override string name()
        {
            return "Coke";
        }

        public override float price()
        {
            return 30.0f;
        }
    }

    public class Pepsi : ColdDrink
    {
        public override string name()
        {
            return "Pepsi";
        }

        public override float price()
        {
            return 35.0f;
        }
    }
    #endregion

    #region Step5 创建一个 Meal 类，带有上面定义的 Item 对象
    public class Meal
    {
        private List<IItem> items = new List<IItem>();
        public void AddItem(IItem item)
        {
            items.Add(item);
        }

        public float GetCost()
        {
            float cost = 0f;
            items.ForEach(i => cost += i.price());
            return cost;
        }

        public void ShowItems()
        {
            foreach (IItem item in items)
            {
                Console.WriteLine($"Item:{item.name()},Packing:{item.packing()},Price:{item.price()}");
            }
        }

        public void ShowMealInfo(string mealName)
        {
            Console.WriteLine(mealName);
            ShowItems();
            Console.WriteLine($"Total Cost:{GetCost()}");
        }
    }
    #endregion

    #region Step6 创建一个 MealBuilder 类，实际的 builder 类负责创建 Meal 对象
    public class MealBuilder
    {
        public Meal PrepareVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new VegBurger());
            meal.AddItem(new Coke());
            return meal;
        }

        public Meal PrepareNonVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new ChickenBurger());
            meal.AddItem(new Pepsi());
            return meal;
        }
    }
    #endregion
}
