namespace CalificacionesAlumnos;

public class ValidNumber : IValidatedData<int>
{
    private readonly bool _valid;
    private readonly int _value = 0;

    public ValidNumber(string? input)
    {
        _valid = int.TryParse(input, out _value);
    }

    public int GetValue() => _value;
    public bool IsValid() => _valid;
}