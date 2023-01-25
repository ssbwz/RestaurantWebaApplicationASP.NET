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
    public partial class UCSearchItem : UserControl
    {
        private ItemManager itemManager = new ItemManager();

        public UCSearchItem()
        {
            InitializeComponent();
            AddingCategory();

        }

        private void AddingCategory()
        {
            cbCatergory.Items.Add(Category.POPULARDISHES);
            cbCatergory.Items.Add(Category.STARTERS);
            cbCatergory.Items.Add(Category.SANDWICHES);
            cbCatergory.Items.Add(Category.BURGERS);
            cbCatergory.Items.Add(Category.DISHES);
            cbCatergory.Items.Add(Category.DRINKS);
            cbCatergory.Items.Add(Category.COCKTAILS);
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string description = tbDescription.Text;
            string price = tbPrice.Text;
            string category = cbCatergory.Text;

            printItem(lbShowItems, itemManager.SearchItem(name, description, price, category, GetSelected()));

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

        public void printItem(ListBox listBox, List<Item> items)
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
    }
}
