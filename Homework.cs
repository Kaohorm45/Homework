using System.Collections.Generic;
using System;
enum Menu
{
    RegisterNewStudent = 1,
    RegisterNewTeacher,
    GetListPersons
}

namespace HomeWork
{
    class Program
    {
       
        static void Main(string[] args)
        {
            PrintMenuScreen();
        }
        static void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeader();
            PrintListMenu();
            InputMenuFromKeyboard();
        }
        static void PrintHeader()
        {
            Console.WriteLine("Welcome to registration new user school application.");
            Console.WriteLine(".................................");
        }
        static void PrintListMenu()
        {
            Console.WriteLine("1. Register new Student");
            Console.WriteLine("2. Register new Teacher");
            Console.WriteLine("3. Get List Persons");
        }
        static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);

        }

        static PersonList personList;
        static void PreparePersonListWhenProgramsLoad()
        {
            Program.personList = new PersonList();
        }

        static void PresentMenu(Menu menu)
        {
          if(menu == Menu.RegisterNewStudent)
            {
                ShowInputRegisterNewStudentScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }
        static void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            PrintHeaderRegisterStudent();

            int totalStudent = TotalNewStudents();
            InputNewStudentFromKeyboard(totalStudent);
        }
        static void TotalNewStudents()
        {
            Console.WriteLine("Input Total new Student");
            int.Parse(Console.ReadLine());
        }
        static void InputNewStudentFromKeyboard(int totalStudent)
        {
           for(int i = 0; i< totalStudent; i++)
            {
                Console.Clear();
                PrintHeaderRegisterStudent();
                Student student = CreateNewStudent();

                Program.personList.AddNewPerson(student);
            }
            Console.Clear();
            PrintMenuScreen();
        }
        static void CreateNewStudent()
        {
            new Student(InputName(),
                InputAddress(),
                InputCitizenID(),
               InputStudentID());
        }
        static string InputName()
        {
            Console.WriteLine("Name");
            return Console.ReadLine();
        }
        static string InputStudentID(){  
            Console.WriteLine("StudentID:");
            return Console.ReadLine();
        }
        static string InputAddress()
        {
            Console.WriteLine("Address:");
            return Console.ReadLine();
        }
        
        static string InputCitizenID()
        {
            Console.WriteLine("CitizenID:");
            return Console.ReadLine();
        }
        static void PrintHeaderRegisterStudent()
        {
            Console.WriteLine("Register New Student.");
            Console.WriteLine(".................");
        }
        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu incorrect please try again");
            InputMenuFromKeyboard();
        }

    }
    class Person
    {
        protected string name;
        protected string address;
        protected string citizenID;
        public Person(string name,string address , string citizenID)
        {
            this.name = name;
            this.address= address;
            this.citizenID = citizenID;
        }
        public string GetName()
        {
            return this.name;
        }
    }
    class Student : Person { 
    private string studentID;

    public Student (string name, string address, string citizenID, string studentID)
    :base(name , address , citizenID){

        this.studentID = studentID;
    }
    }

    class Teacher : Person
    {
        private string employeeID;
        public Teacher(string name, string address, string citizenID , string employeeID)
        :base (name,address,citizenID)
        {
            this.employeeID = employeeID;
        }
    }
    
    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }
        public void  AddNewPerson(Person person)
        {
            this.personList.Add(person);
        }

        public void FetchPersonsList()
        {
            Console.WriteLine("List Persons");
            Console.WriteLine("...........");
            foreach(Person person in this.personList)
            {
                if (person is Student)
                {
                    Console.WriteLine("Name:{0)\n Type:Student\n", person.GetName());
                } else if (person is Teacher)
                {
                    Console.WriteLine("Name:{0)\n Type:Teacher\n", person.GetName());
                }
            }
        }
    }

    class Activity
    {
        public string workshop;
        public string detail;

        public Activity (string workshop,string detail)
        {
            this.workshop = workshop;
            this.detail = detail;
        }
    }
}

