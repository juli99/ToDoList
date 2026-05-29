using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<TodoList> Lists { get; set; } = new();
    }
}
