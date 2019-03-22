using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        public string LessonId { get; set; }
        public string LessonName { get; set; }
    }
}
