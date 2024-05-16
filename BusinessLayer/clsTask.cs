using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTask
    {

        public enum enMode
        {
            AddNew = 0 , 
            Update = 1 , 
            Delete = 2
        }

        public int taskID { get; set; }

        public string task { get; set; }

        public bool isCompleted { get; set; }

        public enMode mode { get; set; }

        public clsTask()
        {
            this.taskID = -1;
            this.task = "-";
            this.isCompleted = false;
            this.mode = enMode.AddNew;
           
        }

        private clsTask(int taskID , string task , bool isCompleted)
        {
            this.taskID = taskID;
            this.task = task;
            this.isCompleted = isCompleted;
            this.mode = enMode.Update;
        }

        // Implement save method to save or delete task.


        // Static Methods

        public static DataTable getAllTasks()
        { 
            return  clsTasksDataAccess.getAllTasks();
        }


        public static bool deleteAllTasks()
        {
            return clsTasksDataAccess.deleteAllTasks() ;
        }


        public static bool addNewTask(string s)
        {
            return clsTasksDataAccess.addTask(s);
        }

        public static bool deleteTask(int taskID)
        {
            return clsTasksDataAccess.deleteTask(taskID);
        }
    }
}
