namespace CalificacionesAlumnos;

public class ValidString : IValidatedData<string>
{
    private readonly bool _valid = false;
    private readonly string _value = "";

    public ValidString(string? input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            _value = input;
            _valid = true;
        }
    }

    public string GetValue() => _value;
    public bool IsValid() => _valid;
}