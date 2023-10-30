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
            Houses = new HashSet<House>();
        }

        public Teacher(int id, string name, string subject)
        {
            Id = id;
            Name = name;
            Subject = subject;
            Houses = new HashSet<House>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }
}
