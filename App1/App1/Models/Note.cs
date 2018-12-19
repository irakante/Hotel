using System;
using SQLite;


namespace App1
{
    [Table("NoteViewModel")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Title { get; set; }            
        public string Description { get; set; }            
        public DateTime Created { get; set; }           
        
    }
}
