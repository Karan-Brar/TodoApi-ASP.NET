namespace TodoApi.Models
{
    /// <summary>
    /// This a model class that represents a To-do item and its structure.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// The id of the item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The description of the item.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// A boolean value that signifies whether the to-do task has been completed or not.
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
