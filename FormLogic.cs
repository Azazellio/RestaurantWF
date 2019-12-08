using Newtonsoft.Json;
using Restaurant0.DataHandlers;
using Restaurant1.Classes;
using Restaurant1.DataHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Restaurant1
{
    class FormLogic
    {
        public static readonly string filename = "order";
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

        public Order DeserializeOrder(string path) //
        {
            var order = TxtSerealizer.DeserializeOrder(path, kitchen);
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
        public int CountSumLV(ListView lv, int index)
        {
            int sum = 0;
            foreach(ListViewItem item in lv.Items)
            {
                sum += int.Parse(item.SubItems[index].Text);
            }
            return sum;
        }
        public List<String> CollectDishes(ListView lv)
        {
            var res = new List<string>();
            foreach(ListViewItem item in lv.Items)
            {
                res.Add(item.SubItems[0].Text);
            }
            res.RemoveAt(res.Count - 1);
            return res;
        }
        public void XmlSerialize(ListView lv)
        {
            EnsureDirectoryExists("XMLOrders");
            Order order = this.CreateOrder(this.CollectDishes(lv).ToArray());
            XmlWriterSettings settingsxml = new XmlWriterSettings();
            settingsxml.Indent = true;
            settingsxml.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create("XMLOrders/" + FormLogic.filename + order.GetId().ToString() + ".xml", settingsxml);
            writer.WriteStartElement("orders");
            order.WriteXml(writer);
            writer.WriteEndElement();
            writer.Close();
            writer.Flush();
        }
        public void JsonSerialize(ListView lv)
        {
            EnsureDirectoryExists("JSONOrders");
            Order order = this.CreateOrder(this.CollectDishes(lv).ToArray());
            var settingsjson = new JsonSerializerSettings() { ContractResolver = new MyContractResolver() };
            var json = JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented, settingsjson);
            TxtSerealizer.WriteTo(json, "JSONOrders/" + FormLogic.filename + order.GetId().ToString() + ".json");
        }
        public void TxtSerialize(ListView lv)
        {
            EnsureDirectoryExists("TXTOrders");
            Order order = this.CreateOrder(this.CollectDishes(lv).ToArray());
            var serealized = TxtSerealizer.Serialize(order);
            TxtSerealizer.WriteTo(serealized, "TXTOrders/" + FormLogic.filename + order.GetId().ToString() + ".txt");
        }
        private static void EnsureDirectoryExists(string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
        }
    }
}
