namespace CalificacionesAlumnos;

public class ValidFloat : IValidatedData<float>
{
    private bool _valid;
    private float _value;

    public void SetValue(string? input) => _valid = float.TryParse(input, out _value);

    public float GetValue() => _value;
    public bool IsValid() => _valid;
}