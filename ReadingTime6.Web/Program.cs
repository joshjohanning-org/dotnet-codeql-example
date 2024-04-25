using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Security.Cryptography;

namespace ReadingTime6.Web
{
    public class Program
    {
    public static byte[] encryptString()
        {
            SymmetricAlgorithm serviceProvider = new DESCryptoServiceProvider();
            byte[] key = { 16, 22, 240, 11, 18, 150, 192, 21 };
            serviceProvider.Key = key;
            ICryptoTransform encryptor = serviceProvider.CreateEncryptor();
            String message = "Hello World";
            byte[] messageB = System.Text.Encoding.ASCII.GetBytes(message);
            return encryptor.TransformFinalBlock(messageB, 0, messageB.Length);
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
