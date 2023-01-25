using Shawarma.Enum;
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
    public partial class UCCreateItem : UserControl
    {

        public UCCreateItem()
        {
            InitializeComponent();
            AddingCatergory();
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
        
        private void btCreate_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string description = tbDescription.Text;
            double price = 0;

            if (string.IsNullOrEmpty(name)) 
            {
                Message newMessage = new Message("Please fill name");
                newMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrEmpty(description)) 
            {
                Message newMessage = new Message("Please fill description");
                newMessage.ShowDialog();
                return;
            }
            if (cbCatergory.SelectedIndex == -1) 
            {
                Message newMessage = new Message("Please fill category");
                newMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrEmpty(tbPrice.Text))
            {
                Message newMessage = new Message("Please fill price");
                newMessage.ShowDialog();
                return;
            }
            if (!double.TryParse(tbPrice.Text, out price)) 
            {
                Message newMessage = new Message("Please fill number");
                newMessage.ShowDialog();
                return;
            }
            Category category = (Category)cbCatergory.SelectedItem;

            if (rdHoildayItem.Checked)
            {
              Login.ItemManager.AddItem(new HoildayItem(name, description, price, category));
            }
            else if (rdSummerItem.Checked)
            {
               Login.ItemManager.AddItem(new SummerItem(name, description, price, category));
            }
            else 
            {
               Login.ItemManager.AddItem(new NormalItem(name, description, price, category));
            }
            printItem(lbShowItems, Login.ItemManager.GetItems());
        }

        private void printItem(ListBox listBox, List<Item> items)
        {
            listBox.Items.Clear();
            try
            {
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
            catch (Exception) 
            {
                Message newMessage = new Message("Something went wrong.");
                newMessage.ShowDialog();
            }
        }
    }
}
