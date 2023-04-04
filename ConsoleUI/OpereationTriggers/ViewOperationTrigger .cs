using Communication.Client;
using Communication.Server;
using System.Net;
using ToDoListCommonItems.OperationHelperClasses;
using ToDoListCommonItems;
using System;

namespace ConsoleUI.OpereationTriggers
{
    public class ViewOperationTrigger
    {
        public static dynamic ViewToDoOperation(ToDoItem toDoWrapper, IPEndPoint endPoint)
        {
            ViewToDoRequest viewToDoRequest = new ViewToDoRequest();

            ClientConnect<ViewToDoRequest> viewMessageSender = new ClientConnect<ViewToDoRequest>(endPoint);
            viewToDoRequest.toDo = toDoWrapper;
            viewMessageSender.SendMessage(viewToDoRequest);

            IPEndPoint EndPoint = new(IPAddress.Parse("127.0.0.1"), 1235);
            ServerConnect messageReciver = new(EndPoint);
            dynamic message = messageReciver.RecivedMessage();
            foreach (var item in message)
                Console.WriteLine(item["Guid"] + " " + item["toDoItem"] + " " + (ToDoItemStatus)item["Status"]);

            return message;
            }
    }
}
