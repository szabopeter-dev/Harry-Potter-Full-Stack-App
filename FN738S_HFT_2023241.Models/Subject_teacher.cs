using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Subject_teacher(int subject_teacher_id, int teacher_ID, int subject_ID, int year_taught)
        {
            Subject_teacher_id = subject_teacher_id;
            Teacher_ID = teacher_ID;
            Subject_ID = subject_ID;
            Year_taught = year_taught;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Subject_teacher_id { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int Teacher_ID { get; set; }

        [ForeignKey(nameof(Subject))]
        public int Subject_ID { get; set; }
        public int Year_taught { get; set; }
        [NotMapped]
        public virtual Subject Subject { get; private set; }
        [NotMapped]
        public virtual Teacher Teacher { get; private set; }

        public class WhoTaughtInThisYear
        {
            public WhoTaughtInThisYear()
            {
            }
            public string teachername { get; set; }

            public override string ToString()
            {
                return $"{teachername}";
            }

            public override bool Equals(object obj)
            {
                WhoTaughtInThisYear b = obj as WhoTaughtInThisYear;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.teachername == b.teachername;



                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.teachername);
            }

        }
    }
}
