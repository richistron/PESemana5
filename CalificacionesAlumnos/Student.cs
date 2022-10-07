namespace CalificacionesAlumnos;

public struct Student
{
    public readonly string Name;
    public readonly float Grade;

    public Student(string name, float grade)
    {
        Name = name;
        Grade = grade;
    }
}