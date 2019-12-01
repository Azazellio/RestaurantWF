using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            //textB.Text = kitchen.GetOrders()[0].GetDishesS();
            var res = new List<String>();
            foreach(ListViewItem item in Bucket.Items)
            {
                res.Add(item.SubItems[0].Text);
            }
            Bucket.Items.Clear();
            Bucket.Refresh();
            var order = formLogic.CreateOrder(res.ToArray());
            kitchen.AddOrder(order);
            textB.Text = kitchen.GetOrders()[0].GetDishesS();
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
            Dish dish = kitchen.GetDishByName(e.Data.GetData(DataFormats.Text).ToString());
            string time = dish.GetTime().ToString();
            string[] itemArr = new string[] { e.Data.GetData(DataFormats.Text).ToString(), time };
            ListViewItem item = new ListViewItem(itemArr);
            Bucket.Items.Add(item);
            //Bucket.Items.Add(e.Data.GetData(DataFormats.Text).ToString(), time);

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
            var resL = new List<string>();
            foreach (ListViewItem item in Bucket.Items)
            {
                resL.Add(item.SubItems[0].Text);
            }
            var order = formLogic.CreateOrder(resL.ToArray());
            var res = kitchen.GetTempOrderTime(order).ToString();
            TempOrderTimeLabel.Text = res;
        }

        private void RemoveB_Click(object sender, EventArgs e)
        {
            try
            {
                Bucket.Items.Remove(Bucket.SelectedItems[0]);
            }
            catch { }
        }
    }
}
