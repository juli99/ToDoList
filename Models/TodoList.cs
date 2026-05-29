using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class TodoList
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<TodoItem> Items { get; set; } = new();
    }
}
