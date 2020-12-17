using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamaTodo.Models
{
    [Table("Todo")]
    public class ToDo
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(500)]
        public string TodoText { get; set; }
        [MaxLength(10)]
        public string TodoTime { get; set; }

        public bool Done { get; set; }

    }
}
