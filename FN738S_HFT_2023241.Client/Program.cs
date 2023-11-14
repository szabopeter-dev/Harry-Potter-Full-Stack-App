using ConsoleTools;
using FN738S_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace FN738S_HFT_2023241.Client
{
    public class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Student")
            {
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();

                Console.Write($"Enter the HouseId of {name}: ");
                int houseid = int.Parse(Console.ReadLine());
                Console.Write($"Enter true/false if {name} is a quidditch player: ");
                bool isaquidditchplayer = bool.Parse(Console.ReadLine());
                rest.Post(new Student() { Name = name, HouseId =  houseid, Quidditch_player = isaquidditchplayer}, "student");
            }
        }
        static void List(string entity)
        {
            if (entity == "Student")
            {
                List<Student> Students = rest.Get<Student>("student");
                foreach (var item in Students)
                {
                    Console.Write(item.Name);
                    if (item.Quidditch_player == true)
                    {
                        Console.Write(":  Quidditch Player");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:3736/");

            var studentSubMeno = new ConsoleMenu(args, level: 1)
            .Add("List", () => List("Student"))
            .Add("Create", () => Create("Student"))
           
            .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Students", () => studentSubMeno.Show())
                .Add("Exit", ConsoleMenu.Close);


            menu.Show();

            

        }
    }
}
