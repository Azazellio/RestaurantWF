using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Restaurant1.Classes;

namespace Restaurant0.DataHandlers
{
    public class TxtSerealizer
    {
        public static string Serialize(List<Order> ordersList)
        {
            var res = "";
            foreach (Order order in ordersList)
            {
                res += Serialize(order);
            }
            return res;
        }
        private static string Serialize(Order order)
        {
            var result = "";
            result += order.GetId().ToString();
            result += "-";
            foreach (Dish dish in order.GetDishes())
            {
                result += dish.GetName();
                result += ",";
            }
            return result + "\n";
        }
        public static List<Order> Deserialize(string lines, Kitchen kitchen)
        {
            var orderList = new List<Order>();
            string[] splittedLines = lines.Split('\n');
            foreach (var line in splittedLines)
            {
                if (line != "")
                {
                    string[] splittedLine = line.Split('-');
                    Order order = new Order(int.Parse(splittedLine[0]));
                    string[] dishesLines = splittedLine[1].Split(',');
                    foreach (var dishLine in dishesLines)
                    {
                        if (dishLine != "")
                        {
                            var newdish = DeserializeDish(dishLine, kitchen);
                            order.AddDish(newdish);
                        }
                    }
                    orderList.Add(order);
                }
            }
            kitchen.AddOrder(orderList.ToArray());
            return orderList;
        }
        private static Dish DeserializeDish(string line, Kitchen kitchen)
        {
            var name = line.Split(',')[0];
            var newDish = kitchen.GetDishByName(name);
            return newDish;
        }
        public static void WriteTo(string lines, string fileName)
        {
            try
            {
                using (StreamWriter Swriter = new StreamWriter(fileName))
                {
                    Swriter.Write(lines);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
        public static string ReadFrom(string fileName)
        {
            var lines = "";
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (true)
                {
                    var line = "";
                    line = reader.ReadLine();
                    lines += line + "\n";
                    if (line == null)
                    {
                        break;
                    }
                }
            }
            return lines;
        }
        private static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
        private static void ClearArr(string[] array)
        {
            var list = array.ToList();
            foreach (string elem in array)
            {
                if (elem == "" || elem == "\n" || elem == "\t")
                    list.Remove(elem);
            }
            array = list.ToArray();
        }
        public static void SetProps(List<Order> orders, Kitchen kitchen)
        {
            foreach (Order order in orders)
            {
                order.SetPropsAfterJDeserealization(kitchen);
            }
        }
    }
}
