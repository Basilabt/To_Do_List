namespace To_Do_List.Screens
{
    partial class frmAddNewTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtboxTask = new TextBox();
            btnAdd = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtboxTask
            // 
            txtboxTask.Location = new Point(12, 87);
            txtboxTask.Name = "txtboxTask";
            txtboxTask.Size = new Size(428, 23);
            txtboxTask.TabIndex = 2;
            txtboxTask.TextChanged += textBox1_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.White;
            btnAdd.ForeColor = Color.DodgerBlue;
            btnAdd.Location = new Point(108, 127);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(204, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(137, 9);
            label1.Name = "label1";
            label1.Size = new Size(175, 32);
            label1.TabIndex = 1;
            label1.Text = "Add New Task";
            // 
            // frmAddNewTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(452, 171);
            Controls.Add(btnAdd);
            Controls.Add(txtboxTask);
            Controls.Add(label1);
            Name = "frmAddNewTask";
            Text = "Add New Task";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtboxTask;
        private Button btnAdd;
        private Label label1;
    }
}