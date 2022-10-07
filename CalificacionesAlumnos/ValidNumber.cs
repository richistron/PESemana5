namespace CalificacionesAlumnos;

public class ValidNumber : IValidatedData<int>
{
    private bool _valid;
    private int _value = 0;

    public void SetValue(string? input) => _valid = int.TryParse(input, out _value);

    public int GetValue() => _value;
    public bool IsValid() => _valid;
}