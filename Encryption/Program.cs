using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Type the text you want to get encrypted :");
            string userInput = Console.ReadLine();

            Encryption encryption = new Encryption();

            encryption.EncryptionKey(userInput);

        }
    }
}
