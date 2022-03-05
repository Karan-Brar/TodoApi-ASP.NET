using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    /// <summary>
    /// This is the Database context class for the API and it will be used to establish and manage a connection with the database.
    /// </summary>
    public class TodoContext: DbContext
    {
        /// <summary>
        /// Initializes an instance of the DatabaseContext.
        /// </summary>
        /// <param name="options">The options you can configure will instantiating the database context.</param>
        public TodoContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// This database set represents a collection of the To-do item entities which will be stored in a relation.
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
