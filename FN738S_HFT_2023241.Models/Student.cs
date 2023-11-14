using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FN738S_HFT_2023241.Models
{
    public class Student
    {
        public Student()
        {
        }

        public Student(int id, int houseId, string name, bool quidditch_player)
        {
            Id = id;
            HouseId = houseId;
            Name = name;
            Quidditch_player = quidditch_player;


        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(House))]
        public int HouseId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public bool Quidditch_player { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual House House { get; set; }

        
    }
}
