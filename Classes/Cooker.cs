using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant1.Classes
{
    [Serializable]
    public class Cooker
    {
        private static int ID = 0;
        public Cooker(params Quisine[] quisines)
        {
            this.id = ID;
            ID++;
            this.quisines = quisines.ToList();
            this.busy_for = 0;
            this.dish_queue = new List<Dish>();
        }
        private List<Quisine> quisines;
        private readonly int id;
        protected List<Dish> dish_queue;
        private Kitchen kitchen;
        private int busy_for;

        public void SetKitchen(Kitchen kitchen)
        {
            this.kitchen = kitchen;
        }
        public int GetId()
        {
            return this.id;
        }
        public int PrintId()
        {
            return this.id;
        }
        public void AddQuisine(Quisine quisine)
        {
            this.quisines.Add(quisine);
        }
        public void AddToQueue(Dish dish)
        {
            this.SetTimeCooking(dish);
            this.dish_queue.Add(dish);
            dish.SetCooker(this);
        }
        public virtual void SetTimeCooking(Dish dish)
        {
            if (this.dish_queue.Count == 0)
            {
                dish.SetTimeCooking(dish.GetTimeCooking());
            }
            else
            {
                var result = dish_queue[dish_queue.Count - 1].GetTimeCooking() + (dish.GetTime());
                dish.SetTimeCooking(result);
            }
        }
        public List<Quisine> GetQuisines()
        {
            return this.quisines;
        }
        public int GetBusyFor()
        {
            if (this.dish_queue.Count > 0)
                return this.dish_queue[dish_queue.Count - 1].GetTimeCooking();
            else
                return 0;
        }
        public string GetQueueS()
        {
            var res = "";
            foreach (Dish dish in dish_queue)
            {
                res += dish.GetName() + ", ";
            }
            return res;
        }
        public List<Dish> GetQueue()
        {
            return this.dish_queue;
        }
        public void SetDishReady(Dish dish)
        {
            this.dish_queue.Remove(dish);
        }
        public string GetQueueTimes()
        {
            List<string> result = new List<string>();
            foreach (Dish dish in this.dish_queue)
            {
                result.Add(dish.GetTimeCooking().ToString());
            }
            return "cooker " + this.id + ": " + string.Join(", ", result);
        }
        public void ResetKitchen(Kitchen newkitchen)
        {
            this.kitchen = newkitchen;
        }
    }
}
