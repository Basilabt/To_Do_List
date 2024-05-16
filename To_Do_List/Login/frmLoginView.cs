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
using To_Do_List.Main;

namespace To_Do_List.Login
{
    public partial class frmLoginView : Form
    {
        public frmLoginView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            enLoginResult loginResult = this._login();

            if(loginResult == enLoginResult.UserDoesNotExist)
            {
                MessageBox.Show("User Does Not Exist !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(loginResult == enLoginResult.UserIsNotActive)
            {
                MessageBox.Show("User Is Not Active !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(loginResult == enLoginResult.LoginFailed)
            {
                MessageBox.Show("Username or Password is Incorrect", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            frmMainView form = new frmMainView();
            this.Hide();
            form.ShowDialog();
            

        }

        private enum enLoginResult
        {
            UserDoesNotExist = 0 , 
            UserIsNotActive = 1 , 
            LoginFailed = 2 , 
            LoginSuccessfull =  3
        }


        private enLoginResult _login()
        {
            string username = this.txtboxUsername.Text;
            string password = this.txtboxPassword.Text;


            if(!clsUser.isUserExist(username))
            {
                return enLoginResult.UserDoesNotExist;
            }

            if(!clsUser.isUserActive(username))
            {               
                return enLoginResult.UserIsNotActive;
            }


            clsUser user = clsUser.login(username, password);

            if(user == null)
            {                
                return enLoginResult.LoginFailed;
            }


            clsGlobal.loggedUser = user;

            return enLoginResult.LoginSuccessfull;

        }

    }
}
