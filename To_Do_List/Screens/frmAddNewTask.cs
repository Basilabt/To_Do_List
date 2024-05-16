using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List.Screens
{
    public partial class frmAddNewTask : Form
    {
        public frmAddNewTask()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(this._addTask())
            {
                MessageBox.Show("Added Succesfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);                               
            } else
            {
                MessageBox.Show("Failed To Add Task", "", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }

            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private bool _addTask()
        {
            string task = txtboxTask.Text.Trim();

           return clsTask.addNewTask(task);
        }
    }
}
