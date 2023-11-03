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

        public Teacher(int id, int houseid, string name, bool animagus)
        {
            Id = id;
            Name = name;
            House_Id = houseid;
            Subjects = new HashSet<Subject>();
            Animagus = animagus;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(House))]
        public int House_Id { get; set; }
        public string Name { get; set; }
        public bool Animagus { get; set; }
        public virtual House House { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Subject_teacher> Subject_Teachers { get; }

        public class WhoIsAnAnimagus
        {
            public WhoIsAnAnimagus()
            {
            }
            public string teachername { get; set; }

            public override string ToString()
            {
                return $"{teachername}";
            }

            public override bool Equals(object obj)
            {
                WhoIsAnAnimagus b = obj as WhoIsAnAnimagus;
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
