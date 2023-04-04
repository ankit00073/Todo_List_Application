using Communication.Client;
using Communication.Server;
using Microsoft.VisualBasic;
using System.Net;
using ToDoListCommonItems;
using ToDoListCommonItems.OperationHelperClasses;
using ToDoManager.OperationClasses;
namespace ToDoManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new(IPAddress.Parse("127.0.0.1"), 1234);
            ServerConnect messageReciver = new(endPoint);
            while (true)
            {   
                var message = messageReciver.RecivedMessage();


                if (message != null)
                {
                    if (message is AddToDoRequest add)
                    {
                        var operate = new AddToDo();
                        operate.Add(add.toDo);
                        IPEndPoint viewEndPoint = new(IPAddress.Parse("127.0.0.1"), 1235);
                        var addMessageSender = new ClientConnect<AddToDoResponce>(viewEndPoint);
                        addMessageSender.SendMessage(new AddToDoResponce { IsSuccess= true});
                    }
                    else if (message is ViewToDoRequest view)
                    {
                        var operate = new ViewToDo();
                        var toDos= operate.GetToDos();
                        IPEndPoint viewEndPoint = new(IPAddress.Parse("127.0.0.1"), 1235);
                        ClientConnect<List<ToDoItem>> addMessageSender = new ClientConnect<List<ToDoItem>>(viewEndPoint);
                        addMessageSender.SendMessage(toDos);

                    }
                    else if (message is UpdateToDoRequest update)
                    {
                        var operate = new UpdateToDo();
                        operate.operations(update.ToDo);
                    }
                    else if (message is DeleteToDoRequest delete)
                    {
                        var operate = new DeleteToDo();
                        operate.operations(delete.Id);
                    }
                }
            }
            
        }
    }
}


