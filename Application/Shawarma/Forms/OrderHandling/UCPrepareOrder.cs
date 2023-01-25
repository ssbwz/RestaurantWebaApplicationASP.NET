using Shawarma.Models;
using Shawarma.Logic;
using Shawarma.DataAccess;
using Shawarma.Enum;

namespace Shawarma.Forms.OrderHandling
{
    public partial class UCPrepareOrder : UserControl
    {
        private OrderManager orderManager;
        private OrdersManager ordersManager;
        private List<Item> selcetedOrderItem;
        public UCPrepareOrder()
        {
            try
            {
                InitializeComponent();
                orderManager = new OrderManager();
                ordersManager = new OrdersManager(Connection.Connect);
                printOrders(lbShowOrder, ordersManager.Orders);
            }
            catch (Exception)
            {
                Message newMessage1 = new Message("Something went wrong.");
                newMessage1.ShowDialog();
                Connection.CloseConnection();
            }


        }

        private void lbShowOrder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                selcetedOrderItem = ordersManager.GetItemsPerOrder(GetIDInListBox(lbShowOrder));
                if (selcetedOrderItem == null)
                {
                    Message newMessage1 = new Message("This order doesn't have any items.");
                    newMessage1.ShowDialog();
                    return;
                }
                printItem(lbShowItems, selcetedOrderItem);
                rbAccepted.Enabled = true;
                rbSent.Enabled = true;
                rbPreparing.Enabled = true;
                rbDone.Enabled = true;

                OrderStatus orderStatus = orderManager.GetOrderStatus(GetIDInListBox(lbShowOrder));

                if (orderStatus == OrderStatus.SENT)
                {
                    rbSent.Checked = true;
                }
                if (orderStatus == OrderStatus.ACCEPTED)
                {
                    rbAccepted.Checked = true;
                }
                if (orderStatus == OrderStatus.PREPARING)
                {
                    rbPreparing.Checked = true;
                }
                if (orderStatus == OrderStatus.DONE)
                {
                    rbDone.Checked = true;
                }

            }
            catch (Exception)
            {
                Message newMessage1 = new Message("Something went wrong.");
                newMessage1.ShowDialog();
                Connection.CloseConnection();
            }
        }

        public void printOrders(ListBox listBox, List<Order> persons)
        {
            listBox.Items.Clear();
            foreach (Order objectone in persons)
            {
                listBox.Items.Add(objectone.ToString());
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


        private void btChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetIDInListBox(lbShowOrder) == -1) 
                {
                    Message newMessage1 = new Message("Please select order.");
                    newMessage1.ShowDialog();
                    return;
                }
                if (rbAccepted.Checked)
                {
                    orderManager.ChangeOrderStatus(GetIDInListBox(lbShowOrder), OrderStatus.ACCEPTED);
                    printOrders(lbShowOrder, ordersManager.Orders);
                }
                if (rbPreparing.Checked)
                {
                    orderManager.ChangeOrderStatus(GetIDInListBox(lbShowOrder), OrderStatus.PREPARING);
                    printOrders(lbShowOrder, ordersManager.Orders);
                }
                if (rbSent.Checked)
                {
                    orderManager.ChangeOrderStatus(GetIDInListBox(lbShowOrder), OrderStatus.SENT);
                    printOrders(lbShowOrder, ordersManager.Orders);
                }
                if (rbDone.Checked)
                {
                    orderManager.ChangeOrderStatus(GetIDInListBox(lbShowOrder), OrderStatus.DONE);
                    printOrders(lbShowOrder, ordersManager.Orders);
                }
            }
            catch (Exception)
            {
                Message newMessage1 = new Message("Something went wrong.");
                newMessage1.ShowDialog();
                Connection.CloseConnection();
            }
        }
    }
}
