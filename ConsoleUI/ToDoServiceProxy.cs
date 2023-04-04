using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDoListCommonItems;

namespace ConsoleUI
{
    public class ToDoServiceProxy : IToDoService
    {
        private List<ToDoItem> list= new List<ToDoItem>();  
        public void AddToDo(ToDoItem todo)
        {
            list.Add(todo);
        }

        public List<ToDoItem> GetToDoItems()
        {
            return list.Where(x=>x.Status== ToDoItemStatus.Pending).ToList();
        }

        public void MarkComplete(Guid id)
        {
            var listtodo = list.FirstOrDefault(x=>x.ID== id);
            if(listtodo!=null)
            {
                listtodo.Status= ToDoItemStatus.Complete;
            }
        }

        public void RemoveFromToDo(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateText(Guid id, string updateText)
        {
            var listtodo = list.FirstOrDefault(x => x.ID == id);
            if (listtodo != null)
            {
                listtodo.Status = ToDoItemStatus.Complete;
            }
        }
    }
}
