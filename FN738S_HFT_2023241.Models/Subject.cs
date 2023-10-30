using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Models
{
    public class Subject
    {
        public Subject()
        {
            Teachers = new HashSet<Teacher>();
        }

        public Subject(int id, string subject_Name)
        {
            Id = id;
            Subject_Name = subject_Name;
            Teachers = new HashSet<Teacher>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Subject_Name { get; set; }
        public virtual ICollection<Teacher> Teachers { get;}


    }
}
