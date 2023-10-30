using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FN738S_HFT_2023241.Models
{
    public class TeacherHeadOfHouse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]

        [ForeignKey(nameof(Teacher.Id))]
        public int Teacher_ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey(nameof(House))]
        public int House_ID { get; set; }

        public int Year_Commenced { get; set; }
    }

}
