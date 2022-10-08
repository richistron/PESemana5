// See https://aka.ms/new-console-template for more information

using CalificacionesAlumnos;

InputValidator<int> inputValidator = new("Please add the number of students", new ValidNumber());
var studentsNumber = inputValidator.Validate();
List<Student> students = new();
List<Student> highAchievers = new();
float highest = 0;
float total = 0;

for (var i = 0; i < studentsNumber; i++)
{
    InputValidator<string> nameValidator = new("Please type the student name", new ValidString());
    var name = nameValidator.Validate();
    InputValidator<float> gradeValidator = new("Please type the student grade",
        "Invalid number, it must be a value between 0 and 10", new ValidFloat(0, 10));
    var grade = gradeValidator.Validate();
    Student student = new(name, grade);
    students.Add(student);
    total += student.Grade;
    if (student.Grade > highest)
    {
        highest = student.Grade;
        highAchievers.Clear();
        highAchievers.Add(student);
    }
    else if (student.Grade == highest)
        highAchievers.Add(student);
}

Console.WriteLine($"The average was {(total / students.Count).ToString("n1")}");
Console.WriteLine("The highest achieving students are:");
highAchievers.ForEach(s => Console.WriteLine("\t * {0}", s.Name));