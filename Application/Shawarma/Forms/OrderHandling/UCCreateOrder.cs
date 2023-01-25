using Shawarma.DataAccess;
using Shawarma.Enum;
using Shawarma.Logic;
using Shawarma.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shawarma
{
    public partial class UCCreateOrder : UserControl
    {
        private Order order;
        private Person person;
        private OrderManager orderManager = new OrderManager(); 
        private ItemManager itemManager = new ItemManager();
        public UCCreateOrder()
        {
            InitializeComponent();
            order = new Order();
            lbShowOrderNumber.Text += Convert.ToString(order.Id);
            person = Login.CurrentPerson;
            lbShowUserWhoMadeOrder.Text += $"({person.Id}) {person.FirstName} {person.LastName}";
            AddingCatergory();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            string name = tbName.Text;
         //  printItem(lbShowItems, itemManager.SearchItemStatic(name, " ", " ", " ", " "));
        }
        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            string price = tbPrice.Text;

        //    printItem(lbShowItems, ItemManager.SearchItemStatic(" ", " ",price, " ", " "));
        }
        
        private void cbCatergory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = Convert.ToString(cbCatergory.SelectedItem);

           // printItem(lbShowItems, ItemManager.SearchItemStatic(" ", " "," ",category, " "));
        }

        private void rdHoildayItem_CheckedChanged(object sender, EventArgs e)
        {
        //  printItem(lbShowItems, ItemManager.SearchItemStatic(" ", " ", " ", " ",GetSelected()));
        }

        private void rdNormalItem_CheckedChanged(object sender, EventArgs e)
        {
        //  printItem(lbShowItems, ItemManager.SearchItemStatic(" ", " ", " ", " ", GetSelected()));
        }

        private void rdSummerItem_CheckedChanged(object sender, EventArgs e)
        {
         // printItem(lbShowItems, ItemManager.SearchItemStatic(" ", " ", " ", " ", GetSelected()));
        }

        private void AddingCatergory()
        {
            cbCatergory.Items.Add(Category.POPULARDISHES);
            cbCatergory.Items.Add(Category.STARTERS);
            cbCatergory.Items.Add(Category.SANDWICHES);
            cbCatergory.Items.Add(Category.BURGERS);
            cbCatergory.Items.Add(Category.DISHES);
            cbCatergory.Items.Add(Category.DRINKS);
            cbCatergory.Items.Add(Category.COCKTAILS);
        }

        private void printItem(ListBox listBox, List<Item> items)
        {
            listBox.Items.Clear();
            foreach (Item item in items)
            {
                if (item is NormalItem normal)
                {
                    listBox.Items.Add(normal.ToString());
                }
                if (item is HoildayItem hoilday)
                {
                    listBox.Items.Add(hoilday.ToString());
                }
                if (item is SummerItem summer)
                {
                    listBox.Items.Add(summer.ToString());
                }
            }
        }

        private string GetSelected()
        {
            if (rdHoildayItem.Checked)
            {
                return "Holiday";
            }
            else if (rdSummerItem.Checked)
            {
                return "Summar";
            }
            else
            {
                return "Normal";
            }
        }

        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
           // printItem(lbShowItems, ItemManager.SearchItemStatic(" ", " ", " ", " "," "));
        }

    }
}
