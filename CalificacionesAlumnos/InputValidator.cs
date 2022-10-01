namespace CalificacionesAlumnos;

public static class InputValidator
{
    public static string String(string msg)
    {
        string? input;
        var valid = false;
        do
        {
            Console.WriteLine(msg);
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Invalid string");
            else valid = true;
        } while (!valid);

        return input;
    }

    public static int Int(string msg)
    {
        var valid = false;
        int n;
        do
        {
            Console.WriteLine(msg);
            var input = Console.ReadLine();
            if (int.TryParse(input, out n))
                valid = true;
            else Console.WriteLine($"\"{input}\" is not an integer");
        } while (!valid);

        return n;
    }
}