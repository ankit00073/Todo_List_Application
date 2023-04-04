using ToDoManager.DBConnection;
using ToDoListCommonItems;
using Communication.Client;
using System.Net;
using ToDoListCommonItems.OperationHelperClasses;

namespace ToDoManager.OperationClasses
{
    public class ViewToDo : IToDoOperations
    {
        public List<ToDoItem> GetToDos()
        {
            DataBaseConnect dbOperations = new DataBaseConnect();
            var ToDoList = dbOperations.ViewAllTasks();
            
            return ToDoList;
        }
    }
}
