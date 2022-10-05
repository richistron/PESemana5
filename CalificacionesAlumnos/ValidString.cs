namespace CalificacionesAlumnos;

public struct ValidString
{
    public bool Valid = false;
    public string Value = "";

    public ValidString(string? input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            Value = input;
            Valid = true;
        }
    }
}
