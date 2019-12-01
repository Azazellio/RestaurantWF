using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant1.Classes
{
    [Serializable]
    public class Quisine
    {
        public Quisine(string name)
        {
            this.name = name;
            this.dishes = new List<Dish>();
        }
        private Kitchen kitchen;
        private List<Dish> dishes;
        private string name;

        public void SetKitchen(Kitchen kitchen)
        {
            this.kitchen = kitchen;
        }
        public void AddDish(params Dish[] dishes_)
        {
            foreach (Dish dish in dishes_)
            {
                this.dishes.Add(dish);
                dish.SetQuisine(this);
            }
        }
        public List<Dish> GetDishes()
        {
            return this.dishes;
        }
        public string ShowDishes()
        {
            var res = "";
            foreach (Dish dish in this.dishes)
            {
                res += dish.GetName() + ", ";
            }
            return res;
        }
        public string GetName()
        {
            //Console.WriteLine(this.name);
            return this.name;
        }
    }
}
