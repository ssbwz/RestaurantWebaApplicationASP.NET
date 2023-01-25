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
    public partial class Message : Form
    {
        public Message(string Message)
        {
            InitializeComponent();
            lbMessage.Items.Add(Message);
        }
    }
}
