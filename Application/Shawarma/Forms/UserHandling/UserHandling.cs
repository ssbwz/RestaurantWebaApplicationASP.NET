using Shawarma.DataAccess;



namespace Shawarma
{
    public partial class UserHandling : Form
    {
        public UserHandling()
        {
            InitializeComponent();
            ucCreateUser.Visible = false;
            ucSearchUser.Visible = false;
            ucUpdateUser.Visible = false;
            ucUserRemove.Visible = false;
        }

        private void btCreateUser_Click(object sender, EventArgs e)
        {
            flibing(ucCreateUser);
            ucSearchUser.Visible = false;
            ucUpdateUser.Visible = false;
            ucUserRemove.Visible = false;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            flibing(ucSearchUser);
            ucCreateUser.Visible = false;
            ucUpdateUser.Visible = false;
            ucUserRemove.Visible = false;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            flibing(ucUpdateUser);
            ucCreateUser.Visible = false;
            ucSearchUser.Visible = false;
            ucUserRemove.Visible = false;
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            flibing(ucUserRemove);
            ucCreateUser.Visible = false;
            ucSearchUser.Visible = false;
            ucUpdateUser.Visible = false;
        }

        private void flibing(UserControl userControl)
        {
            if (userControl.Visible == false)
            {
                userControl.Visible = true;
                return;
            }

            if (userControl.Visible == true)
            {
                userControl.Visible = false;
                return;
            }
        }

        private void UserHandling_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to close the application?",
                    "Shawarma",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    Connection.CloseConnection();
                    Application.Exit();
                }
                else
                    e.Cancel = true;
            }
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.ShowDialog();
            this.Close();
        }

    }
}
