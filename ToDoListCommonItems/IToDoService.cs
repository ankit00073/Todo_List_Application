using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListCommonItems
{
    public interface IToDoService
    {
        void AddToDo(ToDoItem todo);
        
        List<ToDoItem> GetToDoItems();

        void RemoveFromToDo(Guid id);


        void MarkComplete(Guid id);

        void UpdateText(Guid id, string updateText);
   

        
    }
}
