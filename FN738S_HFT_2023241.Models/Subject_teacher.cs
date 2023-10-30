using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Models
{
    public class Subject_teacher
    {
        public Subject_teacher()
        {
        }

        public Subject_teacher(int teacher_ID, int subject_ID, int year_taught)
        {
            Teacher_ID = teacher_ID;
            Subject_ID = subject_ID;
            Year_taught = year_taught;
        }

        [ForeignKey(nameof(Teacher))]
        public int Teacher_ID { get; set; }

        [ForeignKey(nameof(Subject))]
        public int Subject_ID { get; set; }
        public int Year_taught { get; set; }
        public virtual Subject Subject { get; private set; }
        public virtual Teacher Teacher { get; private set; }
    }
}
