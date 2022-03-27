using MessagePack;
using System.Security.Cryptography;

namespace ConsoleBlockchain;

public class BlockHasher
{
    public virtual byte[] Hash(Block block)
    {
        using SHA512 sha = SHA512.Create();
        HashAppend(sha, block.Id);
        HashAppend(sha, block.Created);
        return HashFinalRaw(sha, block.Content.ValueRepresentation);
    }

    private void HashAppend<T>(SHA512 sha, T value)
    {
        byte[] buffer = MessagePackSerializer.Serialize(value, ContentMessagePackSerializerOptions.Options);
        sha.TransformBlock(buffer, 0, buffer.Length, null, 0);
    }

    private byte[] HashFinalRaw(SHA512 sha, byte[] data)
    {
        sha.TransformFinalBlock(data, 0, data.Length);
        return sha.Hash!;
    }
}