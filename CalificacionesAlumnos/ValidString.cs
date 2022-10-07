namespace CalificacionesAlumnos;

public class ValidString : IValidatedData<string>
{
    private bool _valid = false;
    private string _value = "";

    public void SetValue(string? input)
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