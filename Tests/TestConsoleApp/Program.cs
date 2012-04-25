using System;
using Buncis.Core.Services;
using Moq;

namespace TestConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int pid = 0;
            Mock<IProductService> ps = new Mock<IProductService>();
            ps.Setup(o => o.GetProductByProductId(pid)).Returns(new Buncis.Data.Models.Product()
            {
                ProductId = 111,
                ProductName = "wah",
                UnitPrice = 33.55M
            });

            var product = ps.Object.GetProductByProductId(pid);

            Console.ReadKey();
        }
    }
}