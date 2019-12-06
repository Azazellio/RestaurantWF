using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Restaurant1.Classes
{
    [Serializable]
    public class Kitchen:ICloneable
    {
        public Kitchen(params Quisine[] quisines)
        {
            this.quisines = new List<Quisine>();
            foreach (Quisine quisine in quisines)
            {
                quisine.SetKitchen(this);
                this.AddQuisine(quisine);
            }
            this.cookers = new List<Cooker>();
            this.menu = new List<Dish>();
            this.orders = new List<Order>();
            this.ready_orders = new List<Order>();
            this.TimePoint = DateTime.Now;
            this.UpdateMenu();
        }
        private List<Order> orders;
        private List<Order> ready_orders;
        private List<Cooker> cookers;
        private List<Dish> menu;
        private List<Quisine> quisines;
        private DateTime TimePoint;

        public string GetInfo()
        {
            string res = "Menu:\n";
            res += this.ShowMenu();
            res += "Cuisines:\n" + this.ShowQuisines();
            res += "Cookers;\n" + this.PrintCookers() + "\n";
            res += "Orders:\n" + this.ShowOrders();
            return res;
        }
        public string ShowOrders()
        {
            string res = "";
            foreach (Order order in orders)
            {
                res += string.Format("order {0}\t", order.GetId().ToString());
            }
            return res;
        }
        public void AddQuisine(params Quisine[] quisines)
        {
            foreach (Quisine quisine in quisines)
                this.quisines.Add(quisine);
            this.UpdateMenu();
        }
        public void AddCooker(params Cooker[] cookers)
        {
            foreach (Cooker cook in cookers)
            {
                this.cookers.Add(cook);
            }
        }
        public void AddCooker(Cooker cook)
        {
            this.cookers.Add(cook);
            cook.SetKitchen(this);
        }
        public string PrintCookers()
        {
            var res = "";
            foreach (Cooker cook in this.cookers)
            {
                res += "Cooker " + cook.GetId().ToString()+ "\t" + cook.GetQueueS() + Environment.NewLine;
            }
            return res;
        }
        public void AddOrder(Order order)
        {
            order.SetKitchen(this);
            orders.Add(order);
        }
        public void AddOrder(params Order[] ordersArr)
        {
            foreach (Order order in ordersArr)
            {
                order.SetKitchen(this);
                orders.Add(order);
            }
        }
        public void AddQuisine(Quisine quisine)
        {
            this.quisines.Add(quisine);
            this.UpdateMenu();
        }
        //private
        public void UpdateMenu()
        {
            var menu_ = new List<Dish>();
            foreach (Quisine quisine in this.quisines)
            {
                foreach (Dish dish in quisine.GetDishes())
                {
                    menu_.Add(dish);
                }
            }
            this.menu = menu_;
        }
        private Cooker FindOptimal(Dish dish)
        {
            Cooker cook = new Cooker();
            foreach (Cooker cooker in this.cookers)
            {
                if (cooker.GetQuisines().Contains(dish.GetQuisine()))
                {
                    cook = cooker;
                    break;
                }
            }
            foreach (Cooker cooker_ in this.cookers)
            {
                if (cooker_.GetBusyFor() < cook.GetBusyFor() && cooker_.GetQuisines().Contains(dish.GetQuisine()))
                    cook = cooker_;
            }
            return cook;
        }
        /////////
        public string GetAllQueues()
        {
            string res = "";
            foreach (Cooker cook in this.cookers)
            {
                res += "\ncooker number " + cook.GetId() + " queue: " + cook.GetQueueS();
            }
            return res;
        }
        public void Start()
        {
            foreach (Order order in orders)
            {
                foreach (Dish dish in order.GetDishes())
                {
                    FindOptimal(dish).AddToQueue(dish);
                }
            }
        }
        public void Continue(Order order)   // Cast when processing new Orders after kitchen.Start()
        {
            foreach (Dish dish in order.GetDishes())
            {
                FindOptimal(dish).AddToQueue(dish);
            }
        }
        public int CheckOrder(Order order)
        {
            var result = 0;
            foreach (Dish dish in order.GetDishes())
            {
                if (dish.GetTimeCooking() > result)
                    result = dish.GetTimeCooking();
            }
            return result;
        }
        public int CheckOrder(int Id)
        {
            Order order = this.GetOrderById(Id);
            var result = 0;
            foreach (Dish dish in order.GetDishes())
            {
                if (dish.GetTimeCooking() > result)
                    result = dish.GetTimeCooking();
            }
            return result;
        }
        //TimePoint
        public String SetTimePoint()
        {
            var oldTimePoint = this.TimePoint;
            this.TimePoint = DateTime.Now;
            TimeSpan difference = this.TimePoint - oldTimePoint;
            this.ProcessTimeDifference(difference);
            this.SetReadyOrders();
            return (difference.Minutes + " minutes have passed");
        }
        private void ProcessTimeDifference(TimeSpan difference)
        {
            int minute_difference = difference.Minutes;
            foreach (Cooker cook in this.cookers)
            {
                foreach (Dish dish in cook.GetQueue())
                {
                    dish.ReduceTimeCooking(minute_difference);
                }
            }
            this.UpdateQueues();
        }
        private void UpdateQueues()
        {
            foreach (Cooker cook in this.cookers)
            {
                foreach (Dish dish in cook.GetQueue().ToList())
                {
                    if (dish.GetTimeCooking() == 0)
                    {
                        cook.SetDishReady(dish);
                        dish.GetOrder().SetReady(dish);
                    }
                }
            }
        }
        private void SetReadyOrders()
        {
            foreach (Order order in orders.ToList())
            {
                if (order.IsReady())
                {
                    orders.Remove(order);
                    this.ready_orders.Add(order);
                }
            }
        }
        /////
        public Dish GetDishByName(string name)
        {
            return this.menu.First(n => n.GetName() == name);
        }
        public string GetTimes()
        {
            string result = "";
            foreach (Cooker cook in this.cookers)
            {
                result += "\n" + cook.GetQueueTimes();
            }
            return result;
        }
        public string GetReadyOrders()
        {
            var res = "Orders:\n";
            foreach (Order order in orders)
            {
                res += order.GetId() + "\n";
            }
            res += "ready Orders:\n";
            foreach (Order order1 in this.ready_orders)
            {
                res += order1.GetId() + "\n";
            }
            return res;
        }
        public List<Order> GetOrders()
        {
            return orders;
        }
        public List<Dish> GetMenu()
        {
            return this.menu;
        }
        public string ShowMenu()
        {
            var res = "";
            foreach (Dish dish in this.menu)
                res += dish.GetName() + "\n";

            return res;
        }
        public string ShowQuisines()
        {
            var res = "";

            foreach (Quisine quisine in this.quisines)
            {
                res += quisine.GetName() + "\n";
            }
            return res;
        }
        public Order GetOrderById(string idS)
        {
            var id = int.Parse(idS);
            var order = orders.First(n => n.GetId() == id);
            return order;
        }
        public Quisine GetQuisineByName(string name)
        {
            return this.quisines.First(n => n.GetName() == name);
        }
        public Order GetOrderById(int Id)
        {
            return orders.First(m => m.GetId() == Id);
        }
        public string GetStatistics(int num)
        {
            var res = "";
            foreach (Order order in orders)
            {
                if (order.GetPrice() > num)
                    res += order.GetId() + ", ";
            }
            return res;
        }
        public int GetTempOrderTime(Order order)
        {
            Kitchen tempkitchen = (Kitchen)this.Clone();
            tempkitchen.AddOrder(order);
            tempkitchen.Start();
            int res = tempkitchen.CheckOrder(order);
            return res;
        }
        public List<Order> DeserializeXml(string filename)
        {
            XmlDocument xml = new XmlDocument();

            xml.Load(filename);

            var res = new List<Order>();

            foreach (XmlNode node in xml.SelectNodes("//order"))
            {
                var ord = new Order();
                ord.ReadXml(node);
                res.Add(ord);
            }
            return res;
        }

        public object Clone()
        {
            var isStarted = false;
            var newkitchen = new Kitchen();
            var newOrders = new List<Order>(this.orders);
            var newReadyOrders = new List<Order>();
            var newQuisines = new List<Quisine>(this.quisines);

            foreach (Quisine quisine in newQuisines)
            {
                newkitchen.AddQuisine(quisine);
            }
            foreach (Order order in newOrders)
            {
                Order neworder = new Order();
                foreach (Dish dish in order.GetDishes())
                {
                    var name = dish.GetName();
                    try
                    {
                        neworder.AddDish(newkitchen.GetDishByName(name));
                    }
                    catch { }
                }
                newkitchen.AddOrder(order);
                if (isStarted)
                    newkitchen.Continue(order);
                else
                    newkitchen.Start();
            }
            foreach (Order order in newReadyOrders)
            {
                Order neworder = new Order();
                foreach (Dish dish in order.GetDishes())
                {
                    neworder.AddDish(dish);
                }
                newkitchen.AddOrder(order);
            }
            foreach (Cooker cook in this.cookers)
            {
                newkitchen.AddCooker((Cooker)cook.Clone());
            }
            newkitchen.TimePoint = this.TimePoint;
            return newkitchen;
        }
    }
}
