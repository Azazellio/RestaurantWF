using Restaurant1.Classes;
using Restaurant1.DataHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant1
{
    class FormLogic
    {
        public static readonly string filenamexml = "order1.xml";
        public static readonly string filenamejson = "orders.json";
        public static readonly string filenametxt = "orders.txt";
        public static readonly string filenamebinary = "noOrders.lol";
        public static bool isKitchenStarted = false;
        private Kitchen kitchen;
        private BinarySerializer bs;
        public FormLogic()
        {
            this.bs = new BinarySerializer(filenamebinary);
        }
        public static void KitchenStarted()
        {
            isKitchenStarted = true;
        }
        public Order ProcessInputDishes(string unsplitted)
        {
            var splitted = unsplitted.Split(' ');
            var dishesL = new List<Dish>();
            foreach (string dish in splitted)
            {
                if (dish != "")
                {
                    try
                    {
                        dishesL.Add(kitchen.GetDishByName(dish));
                    }
                    catch { }
                }
            }
            var order = new Order(dishesL.ToArray());
            return order;
        }
        public String GetOrderInfo(String id)
        {
            var order = kitchen.GetOrderById(id);
            var res = order.GetDishesInfo();
            return res;
        }
        public Kitchen Load()
        {
            kitchen = this.bs.Read();
            //kitchen.SetTimePoint();
            return kitchen;
        }
        public Order CreateOrder(params string[] dishesS)
        {
            Order order = new Order();
            foreach (string dishS in dishesS)
            {
                order.AddDish(kitchen.GetDishByName(dishS));
            }
            return order;
        }
        public Order CreateTempOrder(params string[] dishesS)
        {
            Order order = new Order();
            Kitchen newKitchen = (Kitchen)kitchen.Clone();
            foreach (string dishS in dishesS)
            {
                order.AddDish(newKitchen.GetDishByName(dishS));
            }
            return order;
        }
        public String GetDishInfo(string name)
        {
            Dish dish = kitchen.GetDishByName(name);
            return dish.InfoForm();
        }
        public String GetTempTime(Order order)
        {
            return kitchen.GetTempOrderTime(order).ToString();
        }
        public string GetAllTime()
        {
            var res = "";
            foreach (Order order in kitchen.GetOrders())
            {
                res += "Order: " + order.GetId().ToString() + " checkorder: "+ kitchen.CheckOrder(order).ToString() + " " + "order time_cooking: " +
                    order.GetTimeCooking().ToString() + Environment.NewLine;
            }
            return res;
        }
    }
}
