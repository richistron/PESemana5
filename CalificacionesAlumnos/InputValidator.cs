namespace CalificacionesAlumnos;

public class InputValidator
{
    public static string String(string msg)
    {
        string? input;
        do
        {
            Console.WriteLine(msg);
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input));

        return input;
    }
}