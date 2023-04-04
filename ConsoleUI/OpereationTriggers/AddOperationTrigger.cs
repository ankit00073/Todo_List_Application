using Communication.Client;
using System.Net;
using ToDoListCommonItems.OperationHelperClasses;
using ToDoListCommonItems;

namespace ConsoleUI.OpereationTriggers
{
    public class AddOperationTrigger
    {
        public static void AddToDoOperation(ToDoItem toDoWrapper, IPEndPoint endPoint , string toDoItem)
        {
            AddToDoRequest addToDoRequest = new AddToDoRequest();

            toDoWrapper.toDoItem = toDoItem;
            addToDoRequest.toDo = toDoWrapper;

            ClientConnect<AddToDoRequest> addMessageSender = new ClientConnect<AddToDoRequest>(endPoint);
            addMessageSender.SendMessage(addToDoRequest);
        }
    }
}
