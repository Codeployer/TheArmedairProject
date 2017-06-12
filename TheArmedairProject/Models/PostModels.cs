using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheArmedairProject.Models
{
    public class PostModels
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}