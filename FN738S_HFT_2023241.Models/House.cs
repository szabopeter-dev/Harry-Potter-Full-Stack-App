using FN738S_HFT_2023241.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Models
{
   
    public class House
    {
        public House()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public House(int iD, HouseType house_name, string founder_name, int house_point )
        {
            ID = iD;
            House_name = house_name;
            Founder_name = founder_name;
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
            House_points = house_point;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public HouseType House_name {  get; set; }
        public string Founder_name {  get; set; }
        public int House_points { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }


        public class WhoIsInGryffindor
        {
            public WhoIsInGryffindor()
            {
            }
            public string studentname { get; set; }

            public override string ToString()
            {
                return $"{studentname}";
            }

            public override bool Equals(object obj)
            {
                WhoIsInGryffindor b = obj as WhoIsInGryffindor;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.studentname == b.studentname;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.studentname);
            }
        }
    }
}
