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

        [StringLength(240)]
        public string Name { get; set; }
        public bool Quidditch_player { get; set; }
        
        public virtual House House { get; set; }

        public class WhoIsAQuidditchPlayer
        {
            public WhoIsAQuidditchPlayer()
            {
            }
            public string studentname { get; set; }
          
            public override string ToString()
            {
                return $"{studentname}";
            }

            public override bool Equals(object obj)
            {
                WhoIsAQuidditchPlayer b = obj as WhoIsAQuidditchPlayer;
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
