using ConsoleTools;
using FN738S_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            else if (entity == "Teacher")
            {
                Console.Write("Enter Teacher Name: ");
                string name = Console.ReadLine();
                Console.Write($"Enter the HouseId of {name}: ");
                int houseid = int.Parse(Console.ReadLine());
                Console.Write($"Enter true/false if {name} is an animagus: ");
                bool isananimagus = bool.Parse(Console.ReadLine());
                Console.Write($"Enter true/false if {name} is a retired teacher: ");
                bool isretired = bool.Parse(Console.ReadLine());
                rest.Post(new Teacher() {Name = name, House_Id = houseid, Animagus = isananimagus, IsRetired = isretired }, "teacher");
            }
            else if (entity == "Subject")
            {
                Console.Write("Enter Subject Name: ");
                string name = Console.ReadLine();
                rest.Post(new Subject() { Subject_Name = name }, "subject");
            }
        }
        static void List(string entity)
        {
            if (entity == "Student")
            {
                List<Student> Students = rest.Get<Student>("student");
                foreach (var item in Students)
                {
                    Console.Write(item.Id+":"+ item.Name);
                    if (item.Quidditch_player == true)
                    {
                        Console.Write(":  Quidditch Player");
                    }
                    Console.WriteLine();
                }
            }
            else if (entity == "Teacher")
            {
                List<Teacher> Teachers = rest.Get<Teacher>("teacher");
                foreach (var item in Teachers)
                {
                    Console.Write(item.Id + ":" + item.Name);
                    if (item.Animagus == true)
                    {
                        Console.Write(":  Animagus");
                    }
                    if (item.IsRetired == true)
                    {
                        Console.Write(": Retired teacher");
                    }
                    Console.WriteLine();
                }
            }
            else if (entity == "Subject")
            {
                List<Subject> Subjects = rest.Get<Subject>("subject");
                foreach(var item in Subjects)
                {
                    Console.WriteLine(item.Id+":"+item.Subject_Name);
                }
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Student")
            {
                Console.Write("Enter Student's Id to update: ");
                int id = int.Parse(Console.ReadLine());
                Student one = rest.Get<Student>(id, "student");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "student");
            }
            else if (entity == "Teacher")
            {
                Console.Write("Enter Teacher's Id to update: ");
                int id = int.Parse(Console.ReadLine());
                Teacher one = rest.Get<Teacher>(id, "teacher");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "teacher");
            }
            else if (entity == "Subject")
            {
                Console.Write("Enter Subject's Id to update: ");
                int id = int.Parse(Console.ReadLine());
                Subject one = rest.Get<Subject>(id, "subject");
                Console.Write($"New name [old: {one.Subject_Name}]: ");
                string name = Console.ReadLine();
                one.Subject_Name = name;
                rest.Put(one, "subject");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Student")
            {
                Console.Write("Enter Student's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "student");
            }
            else if (entity == "Teacher")
            {
                Console.Write("Enter Teacher's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "teacher");
            }
            else if (entity == "Subject")
            {
                Console.Write("Enter Subject's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "subject");
            }

        }


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:3736/");

            var studentSubMenu = new ConsoleMenu(args, level: 1)
            .Add("List",   () => List("Student"))
            .Add("Create", () => Create("Student"))
            .Add("Update", () => Update("Student"))
            .Add("Delete", () => Delete("Student"))
            .Add("Exit", ConsoleMenu.Close);

            var teacherSubMenu = new ConsoleMenu(args, level: 1)
            .Add("List", () => List("Teacher"))
            .Add("Create", () => Create("Teacher"))
            .Add("Update", () => Update("Teacher"))
            .Add("Delete", () => Delete("Teacher"))
            .Add("Exit", ConsoleMenu.Close);

            var subjectSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Subject"))
                .Add("Create", () => Create("Subject"))
                .Add("Delete", () => Delete("Subject"))
                .Add("Update", () => Update("Subject"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Students", () => studentSubMenu.Show())
                //tobbi 
                .Add("Teachers", () => teacherSubMenu.Show())
                .Add("Subjects", () => subjectSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);


            menu.Show();

            

        }
    }
}
