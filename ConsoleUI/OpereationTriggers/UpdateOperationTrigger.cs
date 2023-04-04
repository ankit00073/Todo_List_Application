using Communication.Client;
using System.Net;
using ToDoListCommonItems.OperationHelperClasses;
using ToDoListCommonItems;

namespace ConsoleUI.OpereationTriggers
{
    public class UpdateOperationTrigger
    {
        public static void MarkComplete(IPEndPoint endPoint, string id, string updatedText)
        {
            
            
                if (Guid.TryParse(id, out Guid guid)) //to check if id is null or not 
                {
                    UpdateToDoRequest updateToDoRequest = new UpdateToDoRequest();
                    ClientConnect<UpdateToDoRequest> updateMessageSender = new ClientConnect<UpdateToDoRequest>(endPoint);
                    updateToDoRequest.ToDo = new ToDoItem() { ID= guid,toDoItem=updatedText, Status=ToDoItemStatus.Complete};
                    updateMessageSender.SendMessage(updateToDoRequest);
                }
            
            
        }
    }
}
