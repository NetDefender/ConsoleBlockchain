using MessagePack;
using MessagePack.Resolvers;

namespace ConsoleBlockchain;

public static class ContentMessagePackSerializerOptions
{
    public static readonly MessagePackSerializerOptions Options;

    static ContentMessagePackSerializerOptions()
    {
        Options = ContractlessStandardResolver.Options
            .WithCompression(MessagePackCompression.Lz4BlockArray);
    }
}
