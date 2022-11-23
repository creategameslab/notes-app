using System.ComponentModel.DataAnnotations;

namespace Notes.Code.Entities
{
    public class Note
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string? RawText { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
    }
}
