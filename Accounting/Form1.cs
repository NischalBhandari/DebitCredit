using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Accounting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ManageCsv manager = new ManageCsv();
           String[] hello = manager.Import();
            MessageBox.Show(manager.Validate());
            if (manager.isBalanced())
            {
                balanceBool.Text = " It is balanced";
            }
            else
            {
                balanceBool.Text = " It is not balanced";
            }

            for(int i=0; i < hello.Length-2; i+=3)
            {
                dataGridView1.Rows.Add(hello[i],hello[i+1],hello[i+2]);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ManageXml manager = new ManageXml();
            String[] hello = manager.Import();
            MessageBox.Show(manager.Validate());
            if (manager.isBalanced())
            {
                balanceBool.Text = " It is balanced";
            }
            else
            {
                balanceBool.Text = " It is not balanced";
            }

            for (int i = 0; i < hello.Length - 2; i += 3)
            {
                dataGridView1.Rows.Add(hello[i], hello[i + 1], hello[i + 2]);
            }
        }
    }
}
