using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Models
{
    public class Record
    {
        [Key]
        
        public int Id { get; set; }
        
        public int Day { get; set; }
        
        public string StrId { get; set; }

        [Required]
        public DateTime RecordDate { get; set; }

        [Required]
        public string Teacher { get; set; }

        [Required]
        public string Topic { get; set; }

        public string Type { get; set; }
        public int Minuets { get; set; }
        public int Segment { get; set; }
    }
}
