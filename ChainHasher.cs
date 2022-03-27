using System.Security.Cryptography;

namespace ConsoleBlockchain;

public class ChainHasher
{
    private readonly BlockHasher _blockHasher;
    private readonly byte[] _salt;

    public ChainHasher(BlockHasher blockHasher, byte[] salt)
    {
        _blockHasher = blockHasher;
        _salt = salt;
    }

    public virtual byte[] Hash(BlockChain chain)
    {
        using SHA512 sha = SHA512.Create();
        foreach (Block block in chain.Blocks)
        {
            sha.TransformBlock(block.BlockHash, 0, block.BlockHash.Length, block.BlockHash, 0);
        }
        sha.TransformFinalBlock(_salt, 0, _salt.Length);
        return sha.Hash!;
    }
}
