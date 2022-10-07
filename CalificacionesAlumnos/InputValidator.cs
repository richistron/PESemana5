namespace CalificacionesAlumnos;

public class InputValidator<T>
{
    private readonly IValidatedData<T> _validator;
    private readonly string _msg = "Please add a value";
    private readonly string _error = "Invalid value";

    public InputValidator(IValidatedData<T> validator) => _validator = validator;

    public InputValidator(string msg, IValidatedData<T> validator)
    {
        _msg = msg;
        _validator = validator;
    }

    public InputValidator(string msg, string error, IValidatedData<T> validator)
    {
        _msg = msg;
        _error = error;
        _validator = validator;
    }

    public T Validate()
    {
        do
        {
            Console.WriteLine(_msg);
            var input = Console.ReadLine();
            _validator.SetValue(input);
            if (!_validator.IsValid()) Console.WriteLine(_error);
        } while (!_validator.IsValid());

        return _validator.GetValue();
    }
}