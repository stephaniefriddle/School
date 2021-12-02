using System;
using static System.Console;

//Stephanie Friddle
//3.14.21
//Comprehensive project involing creating classes that contain inherited and polymorphic members.
//References: https://docs.microsoft.com/en-us/dotnet/api/system.string.tostring?view=net-5.0
//https://www.tutorialsteacher.com/csharp/csharp-datetime
//https://www.youtube.com/watch?v=GhQdlIFylQ8&list=PLCe2H3piSItlSafIqJBmuVCwSty8qvy4l
//https://docs.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=net-5.0
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties
//Farrell, J. (2018). Microsoft Visual C# 2017: An Introduction to Object-Oriented Programming, Seventh Edition. Mexico: Cengage.

namespace School
{
    class Person
    {
        public Person(string firstName, string lastName, char gender, DateTime dateOfBirth, string idNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            IdNumber = idNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} is a {Gender} born {DateOfBirth.ToShortDateString()} and the assigned ID number is {IdNumber}.";
        }
    }
    class Staff : Person
    {
        public Staff(string firstName, string lastName, char gender, DateTime dateOfBirth, string idNumber,
            string department, string position, string supervisor, DateTime dateHired, decimal salary)
            : base(firstName, lastName, gender, dateOfBirth, idNumber)
        {
            Department = department;
            Position = position;
            Supervisor = supervisor;
            DateHired = dateHired;
            Salary = salary;
        }

        public string Department { get; set; }
        public string Position { get; set; }
        public string Supervisor { get; set; }
        public DateTime DateHired { get; set; }
        public decimal Salary { get; set; }
        public override string ToString()
        {
            return $@"{FirstName} {LastName} is a {Gender} born {DateOfBirth.ToShortDateString()} and the assigned ID number is {IdNumber}. 
{FirstName} is a {Position} in the {Department} department. Their supervisor is {Supervisor}, they were hired {DateHired.ToShortDateString()} and make ${Salary} per year.";
        }
    }
    class Faculty : Person
    {
        public Faculty(string firstName, string lastName, char gender, DateTime dateOfBirth, string idNumber,
            string department, string specialty, string position, DateTime dateHired, decimal salary, bool isEligibleTenure)
            : base(firstName, lastName, gender, dateOfBirth, idNumber)
        {
            Department = department;
            Specialty = specialty;
            Position = position;
            DateHired = dateHired;
            Salary = salary;
            IsEligibleTenure = isEligibleTenure;
        }

        public DateTime TenureDate
        {
            get
            {
                if (IsEligibleTenure)
                {
                    return DateHired.AddYears(5);
                }
                 return DateTime.Today;
            }
        }
        public string Department { get; set; }
        public string Specialty { get; set; }
        public string Position { get; set; }
        public static DateTime DateHired { get; set; }
        public decimal Salary { get; set; }
        public bool IsEligibleTenure { get; set; }

        public override string ToString()
        {
            return $@"{FirstName} {LastName} is a {Gender} born {DateOfBirth.ToShortDateString()} and the assigned ID number is {IdNumber}. 
{FirstName} is a {Position} in the {Department} department specializing in {Specialty}. 
They were hired {DateHired.ToShortDateString()} and make ${Salary} per year. As of {TenureDate.ToShortDateString()} it is {IsEligibleTenure} they are tenured.";
        }
    }
    class Student : Person
    {
        public Student(string firstName, string lastName, char gender, DateTime dateOfBirth, string idNumber,
            string major, string advisor, double gpa, int creditsCompleted, decimal currentBalance)
            : base(firstName, lastName, gender, dateOfBirth, idNumber)
        {
            Major = major;
            Advisor = advisor;
            Gpa = gpa;
            CreditsCompleted = creditsCompleted;
            CurrentBalance = currentBalance;
        }
        public string Major { get; set; }
        public string Advisor { get; set; }
        public double Gpa { get; set; }
        public int CreditsCompleted { get; set; }
        public decimal CurrentBalance { get; set; }
        public override string ToString()
        {
            return $@"{FirstName} {LastName} is a {Gender} born {DateOfBirth.ToShortDateString()} and the assigned ID number is {IdNumber}.
{FirstName} is a {Major} major and their GPA is {Gpa}. Their advisor is {Advisor} and they have {CreditsCompleted} credits completed.
The current balance owed is ${CurrentBalance}.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Larry", "Larson", 'M', new DateTime(1990, 10, 2), "L324");
            WriteLine(person1.ToString());
            WriteLine("------------------------------------------");

            Staff staff1 = new Staff("Mary", "Filbert", 'F', new DateTime(1979, 1, 4), "F156", "admissions", "officer", "Susan", new DateTime(2000, 2, 15), 40000);
            WriteLine(staff1.ToString());
            WriteLine("------------------------------------------");


            Faculty faculty1 = new Faculty("Carol", "Fleck", 'F', new DateTime(1956, 4, 14), "F416", "communications", "speech", "professor", new DateTime(1997, 3, 25), 70000, true);
            WriteLine(faculty1.ToString());
            WriteLine("------------------------------------------");


            Student student1 = new Student("Bobby", "Wilmit", 'M', new DateTime(2005, 6, 1), "BW623", "biology", "Maci Burns", 3.5, 60, 2000);
            WriteLine(student1.ToString());
            WriteLine("------------------------------------------");

        }
    }
}
