using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        /// <summary>
        /// The description of the item.
        /// </summary>
        [Required]
        public string? Description { get; set; }

        /// <summary>
        /// A boolean value that signifies whether the to-do task has been completed or not.
        /// </summary>
        [DefaultValue(false)]
        public bool IsComplete { get; set; }


        public int ListId { get; set; }
        public virtual TodoList TodoList { get; set; }
    }
}
