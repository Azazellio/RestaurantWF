using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Linq;

namespace Restaurant1.Classes
{
    [DataContract, Serializable]
    public class Order
    {
        private static int ID = 0;
        public Order(params Dish[] dishes)
        {
            this.time_created = DateTime.Now;
            this.time_createdS = DateTime.Now.ToString("hh:mm tt");
            this.id = ID;
            ID++;
            this.dishes = new List<Dish>();
            this.ready_dishes = new List<Dish>();
            this.dishesArr = dishes;
            foreach (Dish dish in dishes)
            {
                this.AddDish(dish);
            }
            this.time = this.CountTime();
            this.price = this.GetPrice();
        }
        public Order(int id, int time, int price, params Dish[] dishes)
        {
            this.time_created = DateTime.Now;
            this.time_createdS = DateTime.Now.ToString("hh:mm tt");
            this.id = id;
            this.time = time;
            this.price = price;
            this.dishes = new List<Dish>();
            this.ready_dishes = new List<Dish>();
            this.dishesArr = dishes;
            foreach (Dish dish in dishes)
            {
                this.AddDish(dish);
            }
        }
        public Order()
        {
            this.id = ID;
            ID++;
            this.dishes = new List<Dish>();
            this.ready_dishes = new List<Dish>();
            this.time_created = DateTime.Now;
            this.time_createdS = DateTime.Now.ToString("hh:mm tt");
        }
        public Order(int id)
        {
            this.time_created = DateTime.Now;
            this.time_createdS = DateTime.Now.ToString("hh:mm tt");
            this.id = id;
            this.dishes = new List<Dish>();
            this.ready_dishes = new List<Dish>();
        }
        [JsonIgnore]
        private string idS;
        [DataMember]
        private DateTime time_created;
        [JsonIgnore]
        private string time_createdS;
        [DataMember]
        public float price;
        [JsonIgnore]
        private List<Dish> ready_dishes;
        [JsonIgnore]
        private List<Dish> dishes { get; set; }
        [DataMember]
        private Dish[] dishesArr;
        [DataMember]
        private int time;
        [DataMember]
        private int id;
        [JsonIgnore]
        private Kitchen kitchen;

        public void SetKitchen(Kitchen kitchen)
        {
            this.kitchen = kitchen;
        }
        public List<Dish> GetDishes()
        {
            return this.dishes;
        }
        public Dish[] GetArr()
        {
            return dishesArr;
        }
        public string PrintArr()
        {
            var res = "";
            foreach (Dish dish in this.dishesArr)
            {
                res += dish.GetName() + ", ";
            }
            return res;
        }
        public string GetDishesS()
        {
            string res = "";
            foreach (Dish dish in this.dishes)
            {
                res += dish.GetName() + "-";
            }
            return res;
        }
        public int GetTime()
        {
            return this.time;
        }
        public int GetTimeCooking()
        {
            int res = 0;
            foreach(Dish dish in this.dishes)
            {
                if (res < dish.GetTimeCooking())
                    res = dish.GetTimeCooking();
            }
            return res;
        }
        public String GetDishesInfo()
        {
            var res = "";
            foreach (Dish dish in this.GetDishes())
            {
                res += dish.GetName() + ", time left: " + dish.GetTime().ToString() + "/n";
            }
            return res;
        }
        public DateTime GetTimeCreated()
        {
            return this.time_created;
        }
        public void AddDish(Dish dish1)
        {
            var dish = (Dish)dish1.Clone();
            this.dishes.Add(dish);
            this.dishesArr = this.dishes.ToArray();
            dish.SetOrder(this);
            this.time = this.CountTime();
            this.price = this.GetPrice();
        }
        private int CountTime()
        {
            var res = 0;
            foreach (Dish dish in this.dishes)
            {
                res += dish.GetTime();
            }
            return res;
        }
        public float GetPrice()
        {
            float res = 0;
            foreach (Dish dish in this.dishes)
            {
                res += dish.GetPrice();
            }
            return res;
        }
        public int GetId()
        {
            return this.id;
        }
        public string GetTimeCreatedS()
        {
            return this.time_createdS;
        }
        public void SetReady(Dish dish)
        {
            this.ready_dishes.Add(dish);
        }
        public bool IsReady()
        {
            foreach (Dish dish in this.dishes)
            {
                if (!this.ready_dishes.Contains(dish))
                    return false;
            }
            return true;
        }
        public void ResetKitchen(Kitchen newkitchen)
        {
            this.kitchen = newkitchen;
        }
        public void SetPropsAfterJDeserealization(Kitchen kitchen)
        {
            this.dishes = this.dishesArr.ToList();
            this.idS = this.id.ToString();
            this.SetKitchen(kitchen);
        }

        public XmlSchema GetSchema() { return null; }
        /*
        public Dictionary<string, Object> ReadXml(XmlNode node)
        {
            var dict = new Dictionary<string, Object>();
            id = int.Parse(node.Attributes[0].Value);
            price = int.Parse(node.Attributes[1].Value);
            time = int.Parse(node.Attributes[2].Value);

            dict.Add("id", id);
            dict.Add("price", price);
            dict.Add("time", time);

            var dishesList = new List<Dish>();

            foreach (XmlNode child in node)
            {
                Dish di = new Dish();
                di.ReadXml(child.Attributes);
                dishesList.Add(di);
            }
            dict.Add("dishes", dishesList);
            return dict;
        }*/

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("order");
            writer.WriteAttributeString("ID", this.id.ToString());
            writer.WriteAttributeString("price", price.ToString());
            writer.WriteAttributeString("time", time.ToString());

            foreach (Dish dish in dishes)
            {
                writer.WriteStartElement("dish");
                dish.WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}
