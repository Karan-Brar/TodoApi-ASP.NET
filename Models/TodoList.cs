using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TodoApi.Models
{
    public class TodoList
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ListId { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
