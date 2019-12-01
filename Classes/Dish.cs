using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Restaurant1.Classes
{
    [DataContract, Serializable]
    public class Dish : ICloneable
    {
        public Dish(string name, float price, int time, Quisine quisine, params string[] ingredients)
        {
            this.name = name;
            this.price = price;
            this.ingredients = ingredients;
            this.time = time;
            this.time_cooking = time;
            this.quisine = quisine;
            this.quisineName = quisine.GetName();
            this.quisine.AddDish(this);
        }
        public Dish() { }
        [JsonIgnore]
        private Order order;
        [DataMember]
        private int orderId;
        [DataMember]
        private Cooker cooker;
        [DataMember]
        private int cookerId;
        [DataMember]
        private int time;
        [DataMember]
        private int time_cooking;
        [DataMember]
        private string[] ingredients;
        [DataMember]
        private string name;
        [DataMember]
        private float price;
        [JsonIgnore]
        private Quisine quisine;
        [DataMember]
        private string quisineName;

        public string InfoForm()
        {
            var res = "";
            res += this.name + Environment.NewLine;
            res += this.price + Environment.NewLine;
            res += this.PrintIngredients() + Environment.NewLine;
            res += this.time.ToString();
            return res;
        }
        public string PrintIngredients()
        {
            string res = string.Join(", ", this.ingredients);
            return res;
        }
        public void SetQuisine(Quisine quisine)
        {
            this.quisine = quisine;
            this.quisineName = quisine.GetName();
        }
        public Quisine GetQuisine()
        {
            return this.quisine;
        }
        public void SetCooker(Cooker cook)
        {
            this.cooker = cook;
            this.cookerId = cook.GetId();
        }
        public string GetQuisineName()
        {
            this.quisineName = quisine.GetName();
            return this.quisineName;
        }
        public string[] GetIngredients()
        {
            return this.ingredients;
        }
        public int GetCookerId()
        {
            return this.cookerId;
        }
        public int GetTime()
        {
            return this.time;
        }
        public int GetTimeCooking()
        {
            return this.time_cooking;
        }
        public void SetTimeCooking(int time)
        {
            this.time_cooking = time;
        }
        public float GetPrice()
        {
            return this.price;
        }
        public string GetName()
        {
            return this.name;
        }
        public Order GetOrder()
        {
            return this.order;
        }
        public int GetOrderId()
        {
            return this.order.GetId();
        }
        public void SetOrder(Order order)
        {
            this.order = order;
        }

        public void ReduceTimeCooking(int minutes)
        {
            if (minutes < this.time_cooking)
                this.time_cooking -= minutes;
            else
                this.time_cooking = 0;
        }

        public void SetPropsAfterJsonDeser(Order order)
        {

        }

        public object Clone()
        {
            var dish = new Dish();
            dish.name = this.name;
            dish.price = this.price;
            dish.ingredients = this.ingredients;
            dish.time = this.time;
            dish.time_cooking = this.time;
            dish.order = this.order;
            dish.cooker = this.cooker;
            dish.quisine = this.quisine;
            return dish;
        }

        public XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlAttributeCollection attributes)
        {
            name = attributes[0].Value;
            price = int.Parse(attributes[2].Value);
            time = int.Parse(attributes[1].Value);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("price", price.ToString());
            writer.WriteAttributeString("time", time.ToString());
        }
    }
}
