using Communication.Client;
using System.Net;
using ToDoListCommonItems.OperationHelperClasses;
using ToDoListCommonItems;

namespace ConsoleUI.OpereationTriggers
{
    public class DeleteOperationTrigger
    {
        public static void DeleteToDoOperation(IPEndPoint endPoint, Guid id)
        {
                if (id == Guid.Empty)
                {
                var deleteToDoRequest = new DeleteToDoRequest() { Id = id };
                    ClientConnect<DeleteToDoRequest> deleteMessageSender = new ClientConnect<DeleteToDoRequest>(endPoint);
                    deleteMessageSender.SendMessage(deleteToDoRequest);
                }
            
        }
    }
}
