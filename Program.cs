using ConsoleBlockchain;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ServiceCollection();
services.AddSingleton<ChainHasher>(sp => new ChainHasher(sp.GetRequiredService<BlockHasher>(), new byte[] { 0x12, 0x34, 0x56 }));
services.AddSingleton<BlockHasher>();
services.AddTransient<BlockChain>();
services.AddSingleton(typeof(ValueRepresentationConverterGeneric<>));
ServiceProvider provider = services.BuildServiceProvider();

BlockChain chain = provider.GetRequiredService<BlockChain>()!;
Block block1 = new Block(new Content<int>(provider.GetRequiredService<ValueRepresentationConverterGeneric<int>>()) { ValueTyped = 10 }, provider.GetRequiredService<BlockHasher>());
chain.AppendBlock(block1);
Block block2 = new Block(new Content<int>(provider.GetRequiredService<ValueRepresentationConverterGeneric<int>>()) { ValueTyped = 10 }, provider.GetRequiredService<BlockHasher>());
chain.AppendBlock(block2);

Console.WriteLine(BitConverter.ToString(block2.BlockHash));
Console.WriteLine(BitConverter.ToString(block1.BlockHash));

Console.WriteLine(BitConverter.ToString(block1.ChainHash));
Console.WriteLine(BitConverter.ToString(block2.ChainHash));
