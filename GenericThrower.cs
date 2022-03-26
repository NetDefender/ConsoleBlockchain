namespace ConsoleBlockchain;

public static class GenericThrower
{
    public static void ThrowIfInvalidCast(Type type, Type expectedType)
    {
        ArgumentNullException.ThrowIfNull(type, nameof(type));
        ArgumentNullException.ThrowIfNull(expectedType, nameof(expectedType));
        if (type != expectedType)
        {
            throw new InvalidCastException("La conversión no es válida");
        }
    }
}
