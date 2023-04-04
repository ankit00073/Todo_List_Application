using System.Data.SqlClient;
using ToDoListCommonItems;
using ToDoListCommonItems.OperationHelperClasses;

namespace ToDoManager.DBConnection
{
    public class DataBaseConnect
    {   private static string _connectionString = "Data Source=LAPTOP-2JOFI7CP\\SQLEXPRESS;Initial Catalog=TODO;Integrated Security=True";
        private SqlConnection connect=new SqlConnection(_connectionString);

        // whenever a new object of this class is created, a connection will be created with the DB. The user need to provide the address of the DB he wants to connect with
        public DataBaseConnect()
        {
           // SqlConnection connect = new SqlConnection(_connectionString);
            connect.Open();
        }

        // The user need to call this method to free the resources and close the connection
        public void CloseConnection()
        {
            connect.Dispose();
            connect.Close();
        }

        public void AddTask(ToDoItem toDoItem)
        {
            Guid guid = Guid.NewGuid();
            string insertQuery = $"INSERT INTO ListTODO (GUID, Name, Status) VALUES ('{guid}','{toDoItem.toDoItem}','{toDoItem.Status}')";

            SqlCommand insertCommand = new SqlCommand(insertQuery, connect);
            insertCommand.ExecuteNonQuery();
        }

        public List<ToDoItem> ViewAllTasks()
        {
            List<ToDoItem> list = new List<ToDoItem>();

            string displayQuery = "select * from ListTODO";
            SqlCommand displayCommand = new SqlCommand(displayQuery, connect);
            SqlDataReader dataReader = displayCommand.ExecuteReader();
            while (dataReader.Read())
            {
                string guid = dataReader.GetValue(0).ToString();
                string toDoItem = dataReader.GetValue(1).ToString();
                string status = dataReader.GetValue(2).ToString();
                if ( Enum.TryParse<ToDoItemStatus>(status, true, out ToDoItemStatus todoItemStatus))
                {
                    list.Add(new ToDoItem(guid, toDoItem, todoItemStatus));
                }
                
            }
            dataReader.Close();
            return list;
        }

        public void UpdateTask(ToDoItem todo)
        {
            if (todo.toDoItem == null)
            {
                string updateQuery = $"UPDATE ListTODO SET Name='{todo.toDoItem}' WHERE GUID='{todo.ID}'";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connect);
                updateCommand.ExecuteNonQuery();
            }
            else
            {
                string updateQuery = $"UPDATE ListTODO SET Name='{todo.toDoItem}' WHERE GUID='{todo.ID}";
            }



            // "ExecuteNonQuery" method returns the number of rows effected by an operation. If the user entered a wrong guid, then no item will be selected and we need to convey this error to the user
            /*  if (updateCommand.ExecuteNonQuery() == 0)
              {
                  Console.WriteLine("No item was selected. Enter valid id");
              }
          */
        }

        public void DeleteToDo(Guid id)
        {
            string updateQuery = $"DELETE FROM ListTODO WHERE GUID='{id}'";
            SqlCommand updateCommand = new SqlCommand(updateQuery, connect);
            if (updateCommand.ExecuteNonQuery() == 0)
            {
                Console.WriteLine("No item was selected. Enter valid id");
            }
        }
    }
}





































