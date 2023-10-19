using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

using System.Xml.Linq;

namespace QT_Project
{
    public partial class ManageFrm : Form
    {
        public ManageFrm()
        {
            InitializeComponent();
        }

        private void ManageFrm_Load(object sender, EventArgs e)
        {
            load_data();

        }
        void load_data()
        {
            dgv1.DataSource = ItemDAO.Load_Item();
            dgv2.DataSource = CustomerDAO.Load_Cust();
        }
        private void bAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("You must enter the ID", "Notification");
                    txtID.Focus();
                }
                else
                {
                    string id = txtID.Text;
                    string name = txtName.Text;
                    string size = txtSize.Text;
                    float price = float.Parse(txtPrice.Text);
                    ItemDAO.Insert_Item(id, name, size, price);
                    load_data();
                    txtID.Clear();
                    txtName.Clear();
                    txtSize.Clear();
                    txtPrice.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void bCancel_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtSize.Clear();
            txtPrice.Clear();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                txtSize.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
                txtPrice.Text = dgv1.CurrentRow.Cells[3].Value.ToString();
                bDel.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            try
            {
                String id = "";
                id = dgv1.CurrentRow.Cells[0].Value.ToString();
                ItemDAO.Del_Item(id);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void bNew_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            txtID.Clear();
            txtName.Clear();
            txtSize.Clear();
            txtPrice.Clear();
            bNew.Enabled = true;
            txtID.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            txtCustID.Clear();
            txtCustName.Clear();
            txtAddress.Clear();
            btnAdd.Enabled = true;
            txtCustID.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustID.Text == "")
                {
                    MessageBox.Show("You must enter the Customer ID", "Notification");
                    txtCustID.Focus();
                }
                else
                {
                    string id = txtCustID.Text;
                    string name = txtCustName.Text;
                    string address = txtAddress.Text;
                    CustomerDAO.Insert_Cust(id, name, address);
                    load_data();
                    txtCustID.Clear();
                    txtCustName.Clear();
                    txtAddress.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                String id = "";
                id = dgv2.CurrentRow.Cells[0].Value.ToString();
                CustomerDAO.Del_Cust(id);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCustID.Clear();
            txtCustName.Clear();
            txtAddress.Clear();
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCustID.Text = dgv2.CurrentRow.Cells[0].Value.ToString();
                txtCustName.Text = dgv2.CurrentRow.Cells[1].Value.ToString();
                txtAddress.Text = dgv2.CurrentRow.Cells[2].Value.ToString();
                btnDel.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}

