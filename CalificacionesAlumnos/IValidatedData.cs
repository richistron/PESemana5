namespace CalificacionesAlumnos;

public interface IValidatedData<out T>
{
    public bool IsValid();
    public T GetValue();
}