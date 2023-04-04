namespace ToDoListCommonItems.OperationHelperClasses
{
    public class DeleteToDoRequest : IMessage
    {
        public Guid Id { get; set; }
    }
}
