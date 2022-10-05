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
            if (!validated.Valid) Console.WriteLine("Invalid string");
        } while (!validated.Valid);

        return validated.Value;
    }

    public static int Int(string msg)
    {
        ValidNumber validated;
        do
        {
            Console.WriteLine(msg);
            var input = Console.ReadLine();
            validated = new ValidNumber(input);
            if (!validated.Valid) Console.WriteLine($"\"{input}\" is not an integer");
        } while (!validated.Valid);

        return validated.Value;
    }
}