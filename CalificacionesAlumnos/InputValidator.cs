namespace CalificacionesAlumnos;

public static class InputValidator
{
    public static string String(string msg)
    {
        ValidString validated;
        do
        {
            Console.WriteLine(msg);
            var input = Console.ReadLine();
            validated = new ValidString(input);
            if (!validated.IsValid()) Console.WriteLine("Invalid string");
        } while (!validated.IsValid());

        return validated.GetValue();
    }

    public static int Int(string msg)
    {
        ValidNumber validated;
        do
        {
            Console.WriteLine(msg);
            var input = Console.ReadLine();
            validated = new ValidNumber(input);
            if (!validated.IsValid()) Console.WriteLine($"\"{input}\" is not an integer");
        } while (!validated.IsValid());

        return validated.GetValue();
    }
}