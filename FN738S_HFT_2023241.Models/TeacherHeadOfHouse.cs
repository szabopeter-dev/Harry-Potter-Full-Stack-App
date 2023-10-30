using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Models
{
    public class TeacherHeadOfHouse
    {
        public TeacherHeadOfHouse()
        {

        }

        public TeacherHeadOfHouse(int teacher_ID, int house_ID, int year_Commenced)
        {
            Teacher_ID = teacher_ID;
            House_ID = house_ID;
            Year_Commenced = year_Commenced;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        [ForeignKey(nameof(Teacher.Id))]
        public int Teacher_ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey(nameof(House))]
        public int House_ID { get; set; }

        public int Year_Commenced { get; set; }

        public virtual Teacher Teacher { get; private set; }
        public virtual House House { get; private set; }
    }
}
