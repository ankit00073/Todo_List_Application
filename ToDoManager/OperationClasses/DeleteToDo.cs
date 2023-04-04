using ToDoManager.DBConnection;
using ToDoListCommonItems;


namespace ToDoManager.OperationClasses
{
    public class DeleteToDo : IToDoOperations
    {
        public void operations(Guid itemToDelete)
        {
            DataBaseConnect dbOperations = new DataBaseConnect();
            dbOperations.DeleteToDo(itemToDelete);
        }
    }
}
