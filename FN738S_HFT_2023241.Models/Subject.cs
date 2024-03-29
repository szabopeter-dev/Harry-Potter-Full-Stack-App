﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [MaxLength(100)]
        public string Subject_Name { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Teacher> Teachers { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Subject_teacher> Subject_Teachers { get; set; }

        public class WhoTeachesTheSubject
        {
            public WhoTeachesTheSubject()
            {
            }
            public string teachername { get; set; }
            public string subjectname { get; set; }
            public override string ToString()
            {
                return $"{teachername}:  {subjectname}";
            }

            public override bool Equals(object obj)
            {
                WhoTeachesTheSubject b = obj as WhoTeachesTheSubject;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.teachername == b.teachername
                        && this.subjectname == b.subjectname;
                    


                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.teachername, this.subjectname);
            }
            
        }

    }
}
