// See https://aka.ms/new-console-template for more information

using CalificacionesAlumnos;

var inputValidator = new InputValidator<int>("Please add the number of students", new ValidNumber());
var studentsNumber = inputValidator.Validate();
var students = new List<Student>();
float highest = 0;
float total = 0;

for (var i = 0; i < studentsNumber; i++)
{
    var nameValidator = new InputValidator<string>("Please type the student name", new ValidString());
    var name = nameValidator.Validate();
    var gradeValidator = new InputValidator<float>("Please type the student grade", new ValidFloat());
    var grade = gradeValidator.Validate();
    var student = new Student(name, grade);
    students.Add(student);
    total += student.Grade;
    highest = student.Grade > highest ? student.Grade : highest;
}

Console.WriteLine($"The avarage was {(total / students.Count).ToString("n1")}");
Console.WriteLine("The highest achieving students are:");

var highestStudents = students.FindAll(s => s.Grade == highest);
highestStudents.ForEach(s => Console.WriteLine("\t * {0}", s.Name));