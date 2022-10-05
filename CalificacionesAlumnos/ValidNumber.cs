namespace CalificacionesAlumnos;

public struct ValidNumber
{
    public bool Valid;
    public int Value = 0;

    public ValidNumber(string? input)
    {
        Valid = int.TryParse(input, out Value);
    }
}