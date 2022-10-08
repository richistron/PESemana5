namespace CalificacionesAlumnos;

public abstract class ValidNumberBase
{
    private protected readonly int? Min = null;
    private protected readonly int? Max = null;

    protected ValidNumberBase()
    {
    }

    protected ValidNumberBase(int min, int max)
    {
        Min = min;
        Max = max;
    }
}