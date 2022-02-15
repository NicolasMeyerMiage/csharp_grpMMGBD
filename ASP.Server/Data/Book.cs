using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASP.Server.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public string Price { get; set; }
        public string Contenu { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
