using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Data
{
    internal sealed class Post
    {
        [Key]
        public int PostID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(10000)]
        public string Content { get; set; } = string.Empty;

    }
}
