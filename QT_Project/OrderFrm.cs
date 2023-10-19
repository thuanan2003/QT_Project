using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QT_Project
{
    public partial class OrderFrm : Form
    {
        public OrderFrm()
        {
            InitializeComponent();
        }
        float total = 0;
        private void bExit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to return to Menuform?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Hide();
                Menufrm f = new Menufrm();
                f.Show();
            }
            else
            {
                this.Show();
            }
        }
        void form_load()
        {
            dgv.DataSource = OrderDetailDAO.Load_OD();
            cbItem.DataSource = ItemDAO.Load_Item();
            cbItem.DisplayMember = "ItemName";
            cbItem.ValueMember = "ItemID";
            cbCust.DataSource = CustomerDAO.Load_Cust();
            cbCust.DisplayMember = "CustName";
            cbCust.ValueMember = "CustID";
        }
        private void OrderFrm_Load(object sender, EventArgs e)
        {
            form_load();
        }

        private void cbItem_TextChanged(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)cbItem.SelectedItem;
            if (row != null)
            {
                txtID.Text = row[0].ToString();
                txtName.Text = row[1].ToString();
                txtSize.Text = row[2].ToString();
                txtPrice.Text = row[3].ToString();
                
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bRemove.Enabled = true;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtID.Text == "" && cbCust.Text == "" && txtOID.Text == "")
                {
                    MessageBox.Show("Invalid input", "Notification");
                }
                else
                {
                    //int year = DateTime.Now.Year;
                    //int month = DateTime.Now.Month;
                    //int day = DateTime.Now.Day;
                    string id = txtODID.Text;
                    string itemid = txtID.Text;
                    string custid = cbCust.ValueMember.ToString();
                    string orderid = txtOID.Text;
                    int quantity = int.Parse(txtNum.Text);
                    float ua = float.Parse(txtPrice.Text);
                    OrderDetailDAO.Insert_OD(id, orderid, itemid, quantity, ua);
                    MessageBox.Show("The item was added successfully!", "Notification", MessageBoxButtons.OK);
                    total += quantity * ua;
                    txtTotal.Text = total.ToString();
                    form_load();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            try
            {
                
                string id = dgv.CurrentRow.Cells[0].Value.ToString();
                OrderDetailDAO.Del_OD(id);
                form_load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
