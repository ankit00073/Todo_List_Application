using ToDoManager.DBConnection;
using ToDoListCommonItems;

namespace ToDoManager.OperationClasses
{
    public class AddToDo : IToDoOperations
    {
        public void Add(ToDoItem toDo)
        {
           
            DataBaseConnect dbOperations = new DataBaseConnect();
            dbOperations.AddTask(toDo);
        }
    }
}
