using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models;

    public class Article

    {   [Required]
        public int ArticleId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string? Body { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string ContributorUsername { get; set; }

        // Automatically sets the creation date when an article is created
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;


    }
