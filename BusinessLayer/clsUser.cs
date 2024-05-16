using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUser
    {
       public enum enMode
        {
            AddNew = 0 ,
            Update = 1 ,
            Delete = 2
        }

        public int userID { set; get; }
        public string username { set; get; }
        public string password { set; get;}
        bool isActive { set; get; }

        public enMode mode;


        clsUser()
        {
            this.userID = 0;
            this.username = "-";
            this.password = "-";
            this.isActive = false;
            this.mode = enMode.AddNew;
        }

        private clsUser(int userID , string username , string password, bool isActive)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.isActive = isActive;
            this.mode = enMode.Update;
        }

        // Implement save method here .. 



        // Static methods

        public static bool isUserExist(string username)
        {
            return clsUserDataAccess.isUserExist(username);
        }


        public static bool isUserActive(string username)
        {
            return clsUserDataAccess.isUserActive(username);
        }

        public static clsUser login(string username , string password)
        {
            int userID = -1;
            bool isActive = false;

            if(clsUserDataAccess.login(ref userID,username,password, ref isActive))
            {
                return new clsUser(userID,username,password,isActive);
            }

            return null;
        }
    
    }
}
