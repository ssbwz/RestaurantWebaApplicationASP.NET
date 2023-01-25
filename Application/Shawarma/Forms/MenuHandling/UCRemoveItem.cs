using Shawarma.Enum;
using Shawarma.Models;
using Shawarma.Logic;
using Shawarma.DataAccess;

namespace Shawarma
{
    public partial class UCRemoveItem : UserControl
    {
        private Item deletedItem;

        public UCRemoveItem()
        {
            InitializeComponent();
            AddingCatergory(cbCatergory);
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string description = tbDescription.Text;
            string price = tbPrice.Text;
            string category = cbCatergory.Text;

            printItem(lbShowItems, Login.ItemManager.SearchItem(name, description, price, category, GetSelected()));
            lbselectedItemInfo.Text = " ";
            lbselectedItemInfo.Visible = false;
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            Login.ItemManager.RemoveItem(deletedItem.Id);
            lbselectedItemInfo.Text = " ";
            lbselectedItemInfo.Visible = false;
            lbselectedItemInfo.Text = $"Item number: {deletedItem.Id} - successcuflly deleted.";
            lbselectedItemInfo.Visible = true;
            btSearch_Click(sender, e);
            btRemove.Enabled = false;
        }

        private void lbShowItems_DoubleClick(object sender, EventArgs e)
        {
            deletedItem = Login.ItemManager.GetItem(GetIDInListBox(lbShowItems));
            if (deletedItem == null) 
            {
                return;
            }
            btRemove.Enabled = true;
            lbselectedItemInfo.Text = deletedItem.ToString();

            lbselectedItemInfo.Visible = true;
        }

        private void AddingCatergory(ComboBox comboBox)
        {
            comboBox.Items.Add(Category.POPULARDISHES);
            comboBox.Items.Add(Category.STARTERS);
            comboBox.Items.Add(Category.SANDWICHES);
            comboBox.Items.Add(Category.BURGERS);
            comboBox.Items.Add(Category.DISHES);
            comboBox.Items.Add(Category.DRINKS);
            comboBox.Items.Add(Category.COCKTAILS);
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

        private int GetIDInListBox(ListBox listBox)
        {
            string selectedIndex = (string)listBox.SelectedItem;
            if (selectedIndex == null)
            {
                return -1;
            }
            int Lenght = selectedIndex.Length;
            if (listBox.SelectedItem == null)
            {
                return -1;
            }

            while (0 < Lenght)
            {
                string IDInString = selectedIndex.Substring(0, Lenght--);
                if (int.TryParse(IDInString, out int ID))
                {
                    ID = Convert.ToInt32(IDInString);
                    return ID;
                }
            }
            return -1;
        }

    }
}
