﻿using System;
namespace Restaurant1.Classes
{
    [Serializable]
    public class Chef : Cooker, ICloneable
    {
        public Chef(params Quisine[] quisines) : base(quisines)
        {
        }
        public override void SetTimeCooking(Dish dish)
        {
            if (this.dish_queue.Count == 0)
            {
                dish.SetTimeCooking(dish.GetTime() / 2);
            }
            else
            {
                int result;
                result = dish_queue[dish_queue.Count - 1].GetTimeCooking() + (dish.GetTime() / 2);
                dish.SetTimeCooking(result);
            }
        }
    }
}
