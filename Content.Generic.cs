using System.Runtime.CompilerServices;

namespace ConsoleBlockchain;

public class Content<T> : Content
{
    public Content(ValueRepresentationConverterGeneric<T> converter) : base(converter)
    {
    }
    public T ValueTyped
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get => (T)Value;
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        set => Value = value;
    }
}