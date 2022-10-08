namespace CalificacionesAlumnos;

public class ValidFloat : ValidNumberBase, IValidatedData<float>
{
    private bool _valid;
    private float _value;
    
    public ValidFloat()
    {
    }
    
    public ValidFloat(int min, int max) : base(min, max)
    {
    }

    public void SetValue(string? input)
    {
        _valid = float.TryParse(input, out _value);
        if ((Min != null && _value < Min) || (Max != null && _value > Max))
            _valid = false;
    }

    public float GetValue() => _value;
    public bool IsValid() => _valid;
}