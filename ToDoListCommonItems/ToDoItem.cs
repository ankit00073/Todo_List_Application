namespace ToDoListCommonItems
{
    public class ToDoItem
    {
        public string toDoItem { get; set; }
        public ToDoItemStatus Status { get; set; } = ToDoItemStatus.Pending;
        public Guid ID { get; set; }
        public ToDoItem() 
        {
           
        }
        

        public ToDoItem(string guid, string itemName, ToDoItemStatus status)
        {
            ID = Guid.Parse(guid);
            toDoItem = itemName;
            Status = status;
        }


     
       
        
    }
}
