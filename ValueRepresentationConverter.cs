using MessagePack;

namespace ConsoleBlockchain;

public class ValueRepresentationConverter
{
    public ValueRepresentationConverter(Type type)
    {
        Type = type;
    }

    public Type Type
    {
        get;
    }

    public virtual byte[] ConvertValueToRepresentation(object value) => MessagePackSerializer.Serialize(Type, value, ContentMessagePackSerializerOptions.Options);

    public virtual object ConvertRepresentationToValue(byte[] data) => MessagePackSerializer.Deserialize(Type, data, ContentMessagePackSerializerOptions.Options);
}
