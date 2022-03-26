namespace ConsoleBlockchain;

public class BlockChain
{
    private readonly LinkedList<Block> _blocks;
    private readonly object _lock;

    public BlockChain(ChainHasher hasher)
    {
        _blocks = new LinkedList<Block>();
        _lock = new object();
        Hasher = hasher;
    }

    public IEnumerable<Block> Blocks => _blocks.AsEnumerable();

    public ChainHasher Hasher
    {
        get;
    }

    public BlockChain AppendBlock(Block block)
    {
        lock (_lock)
        {
            _blocks.AddLast(block);
            block.Chain = this;
            block.ChainHash = Hasher.Hash(this);
        }
        return this;
    }
}