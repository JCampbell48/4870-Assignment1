using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public DateTime CreateDate { get; set; }

        public string ContributorUsername { get; set; } = string.Empty;
    }
}
