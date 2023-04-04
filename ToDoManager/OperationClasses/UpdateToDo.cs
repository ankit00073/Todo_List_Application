using ToDoManager.DBConnection;
using ToDoListCommonItems;

namespace ToDoManager.OperationClasses
{
    public class UpdateToDo : IToDoOperations
    {
        public void operations(ToDoItem toDo)
        {
            DataBaseConnect dbOperations = new DataBaseConnect();
            dbOperations.UpdateTask(toDo);
        }
    }
}
