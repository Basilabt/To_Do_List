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
using System.Xml.Serialization;
using To_Do_List.Screens;

namespace To_Do_List.Main
{
    public partial class frmMainView : Form
    {

        private DataTable _dataTable = new DataTable();

        public frmMainView()
        {
            InitializeComponent();



            this._fillTableWithTasks();

            this._resizeDataGridSize();
        }





        private void btnClear_Click(object sender, EventArgs e)
        {
            this._deleteAllTasks();
            this._refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmAddNewTask form = new frmAddNewTask();
            form.ShowDialog();

            this._refresh();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int taskID = int.Parse(txtboxTaskId.Text.Trim());

            if(this._deleteTask(taskID))
            {
                MessageBox.Show("Deleted Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this._refresh();
                return;
            }


            MessageBox.Show("Failed To Delete Task", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




        // Methods

        private void _resizeDataGridSize()
        {
            dgvTasks.Columns[0].Width = 55;
            dgvTasks.Columns[1].Width = 450;
            dgvTasks.Columns[2].Width = 120;
        }

        private void _hideTaskIDColumn()
        {
            dgvTasks.Columns[0].Visible = false;
        }

        private void _fillTableWithTasks()
        {
            this._dataTable = clsTask.getAllTasks();

            this.dgvTasks.DataSource = this._dataTable;


        }

        private bool _deleteTask(int taskID)
        {
            return clsTask.deleteTask(taskID);
        }

        private void _deleteAllTasks()
        {

            if (this._isEmptyTasksList())
            {
                MessageBox.Show("Empty List", "there is no tasks to delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (clsTask.deleteAllTasks())
            {
                MessageBox.Show("Deleted Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error Ocurred", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _isEmptyTasksList()
        {
            return this._dataTable.Rows.Count == 0;
        }

        private void _refresh()
        {
            this._fillTableWithTasks();
        }

      
    }
}
