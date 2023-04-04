using Communication.Client;
using Communication.Server;
using ConsoleUI.OpereationTriggers;
using Newtonsoft.Json.Linq;
using System.Net;
using ToDoListCommonItems;
using ToDoListCommonItems.OperationHelperClasses;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IToDoService todoService = new ToDoServiceProxy();

            IPEndPoint endPoint = new(IPAddress.Parse("127.0.0.1"), 1234);
            var flag = true;
            while (flag)
            {
                DisplayOperations.DisplayToDoOperations();

                Console.WriteLine("Select an option listed above : ");
                if (!int.TryParse(Console.ReadLine(), out int inputValue))
                {
                    continue;
                }
                Console.WriteLine((ToDoOperationChoice)inputValue);

                ToDoItem toDoWrapper = new ToDoItem();
                

                switch ((ToDoOperationChoice)inputValue)
                {
                    case ToDoOperationChoice.Add:
                        Console.Write("Please enter the todo item: ");
                        var todoItem = Console.ReadLine();
                        todoService.AddToDo(new ToDoItem() { ID= Guid.NewGuid(), toDoItem= todoItem }); //empty constructor is called and these are additional props
                        AddOperationTrigger.AddToDoOperation(toDoWrapper, endPoint, todoItem);
                        break;

                    case ToDoOperationChoice.View:
                        var toDos = todoService.GetToDoItems();
                        DisplayToDosonConsole(toDos);
                        break;
                    case ToDoOperationChoice.Update:
                        {
                            Console.WriteLine("Please enter the Id of the todo to that is updated: ");
                            var idToUpdate = Console.ReadLine();
                            Console.WriteLine("Enter the updated text:");
                            var updatedText = Console.ReadLine();
                            if (Guid.TryParse(idToUpdate, out Guid id))
                            {
                                Console.WriteLine();
                            }
                            todoService.UpdateText(id, updatedText);
                            break;
                        }

                    case ToDoOperationChoice.Delete:
                        {
                            Console.WriteLine("Please enter the Id of the todo to be completed: ");
                            var idUpdate = Console.ReadLine();
                            
                            if (Guid.TryParse(idUpdate, out Guid id))
                            {
                                Console.WriteLine();
                            }
                            todoService.MarkComplete(id);
                            break;
                        }
                       
                    case ToDoOperationChoice.Exit:
                        flag = false;
                        break;
                }
            }
        }

        private static void DisplayToDosonConsole(List<ToDoItem> toDos)
        {
            foreach (var toDo in toDos)
            {
                Console.WriteLine($"{toDo.ID} {toDo.toDoItem}");
            }
        }
    }
}