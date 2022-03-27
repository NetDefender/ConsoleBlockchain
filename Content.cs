using System.Runtime.CompilerServices;

namespace ConsoleBlockchain;

public abstract class Content
{
    private object? _value;
    protected Content(ValueRepresentationConverter converter)
    {
        ArgumentNullException.ThrowIfNull(converter, nameof(converter));
        Converter = converter!;
    }

    public object? Value
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get => _value;
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        protected set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _value = value;
            ValueRepresentation = Converter.ConvertValueToRepresentation(_value);
        }
    }

    public ValueRepresentationConverter Converter
    {
        get;
    }

    public byte[]? ValueRepresentation
    {
        get;
        private set;
    }
}