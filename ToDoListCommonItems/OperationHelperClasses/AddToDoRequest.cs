
namespace ToDoListCommonItems.OperationHelperClasses
{
    public class AddToDoRequest : IMessage
    {
        public ToDoItem toDo { get; set; }

    }
}
