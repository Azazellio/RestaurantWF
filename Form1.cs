using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Restaurant0.DataHandlers;
using Restaurant1.Classes;
using Restaurant1.DataHandlers;

namespace Restaurant1
{
    public partial class Form1 : Form
    {
        private static Kitchen kitchen;
        private static FormLogic formLogic;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            formLogic = new FormLogic();
            kitchen = new Kitchen();
            kitchen = formLogic.Load();
            foreach (var dish in kitchen.GetMenu())
            {
                menu.Items.Add(dish.GetName());
            }
            Bucket.Items.Add("Drag Dishes here");
        }
        private void SubmitOrderButton_Click(object sender, EventArgs e)
        {
            var res = new List<String>();
            foreach(ListViewItem item in Bucket.Items)
            {
                res.Add(item.SubItems[0].Text);
            }
            Bucket.Items.Clear();
            Bucket.Refresh();
            res.Remove(res[res.Count - 1]);
            var order = formLogic.CreateOrder(res.ToArray());
            kitchen.AddOrder(order);
            textB.Text = kitchen.GetOrders()[0].GetDishesS();
            if (FormLogic.isKitchenStarted)
                kitchen.Continue(order);
            else
            {
                kitchen.SetTimePoint();
                kitchen.Start();
                FormLogic.KitchenStarted();
            }
        }
        private void Menu_ItemDrag(object sender, ItemDragEventArgs e)
        {
            menu.DoDragDrop(menu.SelectedItems[0].Text, DragDropEffects.Copy);
        }
        private void Bucket_DragDrop(object sender, DragEventArgs e)
        {
            if (Bucket.Items.Count > 0 && Bucket.Items[0].SubItems[0].Text == "Drag Dishes here")
            {
                Bucket.Items[0].Remove();
            }
            else
            {
                if (Bucket.Items.Count > 0)
                {
                    Bucket.Items[Bucket.Items.Count - 1].SubItems[2].ResetStyle();
                    Bucket.Items.RemoveAt(Bucket.Items.Count - 1);
                }

            }
            Dish dish = kitchen.GetDishByName(e.Data.GetData(DataFormats.Text).ToString());
            string time = dish.GetTime().ToString();
            string price = dish.GetPrice().ToString();
            string[] itemArr = new string[] { e.Data.GetData(DataFormats.Text).ToString(), time, price };
            ListViewItem item = new ListViewItem(itemArr);
            Bucket.Items.Add(item);
            var sum = formLogic.CountSumLV(Bucket, 2);
            var sumarr = new string[] {"", "", sum.ToString() };

            ListViewItem sumItem = new ListViewItem(sumarr);
            sumItem.SubItems[2].BackColor = Color.LightGreen;
            sumItem.UseItemStyleForSubItems = false;
            Bucket.Items.Add(sumItem);
        }
        private void Bucket_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }
        private void Menu_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                textB.Text = formLogic.GetDishInfo(menu.SelectedItems[0].Text);
            }
            catch { }
        }
        private void TempOrderTimeCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var resL = new List<string>();
                foreach (ListViewItem item in Bucket.Items)
                {
                    resL.Add(item.SubItems[0].Text);
                }
                resL.RemoveAt(resL.Count - 1);
                var order = formLogic.CreateTempOrder(resL.ToArray());
                var res = kitchen.GetTempOrderTime(order).ToString();
                TempOrderTimeLabel.Text = res;
            }
            catch { }
        }

        private void RemoveB_Click(object sender, EventArgs e)
        {
            try
            {
                Bucket.Items.Remove(Bucket.SelectedItems[0]);
                Bucket.Items.RemoveAt(Bucket.Items.Count - 1);
                var sum = formLogic.CountSumLV(Bucket, 2);
                var sumarr = new string[3] { "", "", sum.ToString() };
                var item = new ListViewItem(sumarr);
                item.SubItems[2].BackColor = Color.LightGreen;
                item.UseItemStyleForSubItems = false;
                Bucket.Items.Add(item);

            }
            catch { }
        }
        private void TabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            OrdersList.Items.Clear();
            OrdersList.Refresh();
            foreach (Order order in kitchen.GetOrders())
            {
                var item = new ListViewItem(new string[4] { order.GetId().ToString(),
                    kitchen.CheckOrder(order).ToString(), order.GetDishes().Count().ToString(),
                    order.GetPrice().ToString() });

                OrdersList.Items.Add(item);
            }
            ReadyOrdersList.Items.Clear();
            ReadyOrdersList.Refresh();
            foreach (Order order in kitchen.GetReadyOrders())
            {
                var item = new ListViewItem(new string[2] { order.GetId().ToString(), order.GetPrice().ToString() });
                ReadyOrdersList.Items.Add(item);
            }
        }
        private void TempB1_Click(object sender, EventArgs e)
        {
            textB.Text = formLogic.GetAllTime();
        }

        private void TempB2_Click(object sender, EventArgs e)
        {
            textB.Text = kitchen.PrintCookers();
        }

        private void TempB3_Click(object sender, EventArgs e)
        {
            kitchen.SetTimePoint();
        }

        private void TxtMenuItem_Click(object sender, EventArgs e)
        {
            Order order = formLogic.CreateOrder(formLogic.CollectDishes(Bucket).ToArray());
            var serealized = TxtSerealizer.Serialize(order);
            TxtSerealizer.WriteTo(serealized, FormLogic.filenametxt);
        }
        private void JsonMenuItem_Click(object sender, EventArgs e)
        {
            Order order = formLogic.CreateOrder(formLogic.CollectDishes(Bucket).ToArray());
            var settingsjson = new JsonSerializerSettings() { ContractResolver = new MyContractResolver() };
            var json = JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented, settingsjson);
            TxtSerealizer.WriteTo(json, FormLogic.filenamejson);
        }

        private void XmlMenuItem_Click(object sender, EventArgs e)
        {
            Order order = formLogic.CreateOrder(formLogic.CollectDishes(Bucket).ToArray());
            var orderList = new List<Order> { order };
            XmlWriterSettings settingsxml = new XmlWriterSettings();
            settingsxml.Indent = true;
            settingsxml.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create(FormLogic.filenamexml, settingsxml);
            writer.WriteStartElement("orders");
            order.WriteXml(writer);
            writer.WriteEndElement();
            writer.Close();
            //formLogic.XmlSerialize(Bucket);
        }
    }
}
