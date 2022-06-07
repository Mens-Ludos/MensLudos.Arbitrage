using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace Arbitrage.Dexes.Contracts.Models.UniswapV2.Callee
{


    public partial class IUniswapV2CalleeDeployment : IUniswapV2CalleeDeploymentBase
    {
        public IUniswapV2CalleeDeployment() : base(BYTECODE) { }
        public IUniswapV2CalleeDeployment(string byteCode) : base(byteCode) { }
    }

    public class IUniswapV2CalleeDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public IUniswapV2CalleeDeploymentBase() : base(BYTECODE) { }
        public IUniswapV2CalleeDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class UniswapV2CallFunction : UniswapV2CallFunctionBase { }

    [Function("uniswapV2Call")]
    public class UniswapV2CallFunctionBase : FunctionMessage
    {
        [Parameter("address", "sender", 1)]
        public virtual string Sender { get; set; }
        [Parameter("uint256", "amount0", 2)]
        public virtual BigInteger Amount0 { get; set; }
        [Parameter("uint256", "amount1", 3)]
        public virtual BigInteger Amount1 { get; set; }
        [Parameter("bytes", "data", 4)]
        public virtual byte[] Data { get; set; }
    }


}
