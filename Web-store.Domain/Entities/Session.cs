using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Domain.Entities
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int StatusId { get; set; }
        public DateTime FinishedAt {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public Session(int id, int userId)
        {
            Id = id;
            UserId = userId;
            StatusId = 1;
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}
