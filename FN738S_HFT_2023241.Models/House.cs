using FN738S_HFT_2023241.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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

        public House(int iD, HouseType house_name, string founder_name )
        {
            ID = iD;
            House_name = house_name;
            Founder_name = founder_name;
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public HouseType House_name {  get; set; }
        public string Founder_name {  get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        
    }
}
