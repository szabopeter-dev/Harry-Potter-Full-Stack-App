using FN738S_HFT_2023241.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Models
{
    public class Student
    {
        public Student()
        {
        }

        public Student(int id, int houseId, string name)
        {
            Id = id;
            HouseId = houseId;
            Name = name;
            
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(House))]
        public int HouseId { get; set; }

        [StringLength(240)]
        public string Name { get; set; }
        
       
        public virtual House House { get; set; }

    }
}
