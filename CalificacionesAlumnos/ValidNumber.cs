namespace CalificacionesAlumnos;

public class ValidNumber : ValidNumberBase, IValidatedData<int>
{
    private bool _valid;
    private int _value = 0;

    public ValidNumber()
    {
    }

    public ValidNumber(int min, int max) : base(min, max)
    {
    }

    public void SetValue(string? input)
    {
        _valid = int.TryParse(input, out _value);
        if ((Min != null && _value < Min) || (Max != null && _value > Max))
            _valid = false;
    }
    
    public int GetValue() => _value;
    public bool IsValid() => _valid;
}