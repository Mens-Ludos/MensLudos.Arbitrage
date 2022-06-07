using System.Numerics;
using Arbitrage.Dexes.Contracts.Models.UniswapV2.Callee;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.RPC.Eth.DTOs;

namespace Arbitrage.Dexes.Contracts.Services.UniswapV2.Callee
{
    public partial class IUniswapV2CalleeService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IUniswapV2CalleeDeployment iUniswapV2CalleeDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV2CalleeDeployment>().SendRequestAndWaitForReceiptAsync(iUniswapV2CalleeDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IUniswapV2CalleeDeployment iUniswapV2CalleeDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV2CalleeDeployment>().SendRequestAsync(iUniswapV2CalleeDeployment);
        }

        public static async Task<IUniswapV2CalleeService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IUniswapV2CalleeDeployment iUniswapV2CalleeDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iUniswapV2CalleeDeployment, cancellationTokenSource);
            return new IUniswapV2CalleeService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IUniswapV2CalleeService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> UniswapV2CallRequestAsync(UniswapV2CallFunction uniswapV2CallFunction)
        {
             return ContractHandler.SendRequestAsync(uniswapV2CallFunction);
        }

        public Task<TransactionReceipt> UniswapV2CallRequestAndWaitForReceiptAsync(UniswapV2CallFunction uniswapV2CallFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(uniswapV2CallFunction, cancellationToken);
        }

        public Task<string> UniswapV2CallRequestAsync(string sender, BigInteger amount0, BigInteger amount1, byte[] data)
        {
            var uniswapV2CallFunction = new UniswapV2CallFunction();
                uniswapV2CallFunction.Sender = sender;
                uniswapV2CallFunction.Amount0 = amount0;
                uniswapV2CallFunction.Amount1 = amount1;
                uniswapV2CallFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(uniswapV2CallFunction);
        }

        public Task<TransactionReceipt> UniswapV2CallRequestAndWaitForReceiptAsync(string sender, BigInteger amount0, BigInteger amount1, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var uniswapV2CallFunction = new UniswapV2CallFunction();
                uniswapV2CallFunction.Sender = sender;
                uniswapV2CallFunction.Amount0 = amount0;
                uniswapV2CallFunction.Amount1 = amount1;
                uniswapV2CallFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(uniswapV2CallFunction, cancellationToken);
        }
    }
}
