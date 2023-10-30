using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Subjects = new HashSet<Subject>();
        }

        public Teacher(int id, int houseid, string name)
        {
            Id = id;
            Name = name;
            House_Id = houseid;
            Subjects = new HashSet<Subject>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(House))]
        public int House_Id { get; set; }
        public string Name { get; set; }
        public virtual House House { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
      
    }
}
