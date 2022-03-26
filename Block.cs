namespace ConsoleBlockchain;

public class Block
{
    public Block(Content content, BlockHasher hasher)
    {
        Content = content;
        Created = DateTimeOffset.Now;
        Id = Guid.NewGuid();
        BlockHash = hasher.Hash(this);
    }
    #region properties
    public Guid Id
    {
        get;
    }

    public byte[] BlockHash
    {
        get;
    }

    public byte[] ChainHash
    {
        get;
        internal set;
    }

    public DateTimeOffset Created
    {
        get;
    }

    public Content Content
    {
        get;
    }
    public BlockChain Chain
    {
        get;
        internal set;
    }
    #endregion
}