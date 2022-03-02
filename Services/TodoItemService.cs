using TodoApi.Models;

namespace TodoApi.Services
{
    public static class TodoItemService
    {
        static List<TodoItem> TodoList { get; }
        static int nextId = 3;
        static TodoItemService()
        {
            TodoList = new List<TodoItem>
            {
                new TodoItem{ Id = 1, Description="Walk the dog", IsComplete= false},
                new TodoItem{ Id = 2, Description="Do laundry", IsComplete= false },
            };
        }

        public static List<TodoItem> GetAll() => TodoList;

        public static TodoItem? Get(int id) => TodoList.FirstOrDefault(t => t.Id == id);

        public static void Add(TodoItem todoItem)
        {
            todoItem.Id = nextId++;
            TodoList.Add(todoItem);
        }

        public static void Delete(int id)
        {
            var todoItem = Get(id);
            if(todoItem is null)
            {
                return;
            }

            TodoList.Remove(todoItem);
        }

        public static void Update(TodoItem todoItem)
        {
            var index = TodoList.FindIndex(t => t.Id == todoItem.Id);
            if (index == -1)
            {
                return;
            }

            TodoList[index] = todoItem;
        }

    }
}
