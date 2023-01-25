using Shawarma.Enum;
using Shawarma.Models;
using Shawarma.Logic;
using Shawarma.DataAccess;

namespace Shawarma
{
    public partial class UCUpdateItem : UserControl
    {
        private Item AdjustItem;
        private ItemManager itemManager;

        public UCUpdateItem()
        {
            try
            {
                InitializeComponent();
                itemManager = new ItemManager();
                AddingCatergory(cbCatergory);
                AddingCatergory(cbCategoryUpdate);
                UserInfoLocking(lbShowItems.SelectedIndex);
            }
            catch (Exception)
            {
                Message newMessage = new Message("Something went wrong");
                newMessage.ShowDialog();
                return;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Text;
                string description = tbDescription.Text;
                string price = tbPrice.Text;
                string category = cbCatergory.Text;

                printItem(lbShowItems, itemManager.SearchItem(name, description, price, category, GetSelected()));
            }
            catch (Exception)
            {
                Message newMessage = new Message("Something went wrong");
                newMessage.ShowDialog();
                return;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                AdjustItem.Name = tbNameUpdate.Text;
                AdjustItem.Description = tbDescriptionUpdate.Text;
                AdjustItem.Price = Convert.ToDouble(tbPriceUpdate.Text);
                AdjustItem.Category = (Category)cbCategoryUpdate.SelectedItem; 
                if (!String.IsNullOrEmpty(tbDiscountUpdate.Text))
                {
                    AdjustItem.Discount = Convert.ToDouble(tbDiscountUpdate.Text);
                }
                if (String.IsNullOrEmpty(tbDiscountUpdate.Text))
                {
                    AdjustItem.Discount = 0;
                }
                if (Login.ItemManager.AdjustItem(AdjustItem))
                {
                    Message newMessage = new Message("Item got successfully updated");
                    newMessage.ShowDialog();
                }
            }
            catch (FormatException)
            {

                Message newMessage = new Message("Please fill all of the fields correct");
                newMessage.ShowDialog();
                return;

            }
            catch (NullReferenceException)
            {
                Message newMessage = new Message("Sorry, couldn't find the item");
                newMessage.ShowDialog();
                return;
            }
            catch (Exception)
            {
                Message newMessage = new Message("Something went wrong");
                newMessage.ShowDialog();
                return;
            }
        }

        private void lbShowItems_DoubleClick(object sender, EventArgs e)
        {
            AdjustItem = Login.ItemManager.GetItem(GetIDInListBox(lbShowItems));
            UserInfoLocking(lbShowItems.SelectedIndex);
            tbNameUpdate.Text = AdjustItem.Name;
            tbDescriptionUpdate.Text = AdjustItem.Description;
            tbPriceUpdate.Text = Convert.ToString(AdjustItem.Price);
            cbCategoryUpdate.Text = Convert.ToString(AdjustItem.Category);
            if (AdjustItem is SummerItem)
            {
                rdSummarItemUpdate.Checked = true;
            }
            else if (AdjustItem is HoildayItem)
            {
                rdHolidayItemUpdate.Checked = true;
            }
            else
            {
                rdNormalItemUpdate.Checked = true;
            }
            rdSummarItemUpdate.Enabled = false;
            rdNormalItemUpdate.Enabled = false;
            rdHolidayItemUpdate.Enabled = false;
        }

        private void UserInfoLocking(int selectedIndex)
        {
            if (selectedIndex == -1)
            {
                gbUpdateItem.Enabled = false;
            }
            else
            {
                gbUpdateItem.Enabled = true;
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
    }
}
