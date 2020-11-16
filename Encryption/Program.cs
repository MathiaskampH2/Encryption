using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        //private static char[] codestring;


        static void Main(string[] args)
        {
            Encryption encryption = new Encryption();

            Console.Write("Type the text you want to get encrypted :");
            string userPlainText = Console.ReadLine();
            string userPlainTextToUpper = userPlainText.ToUpper();
            Console.Write("Type the keyword you want to use for encryption / decryption :");
            string userKeyWord = Console.ReadLine();
            string userKeyWordToUpper = userKeyWord.ToUpper();
            
            string encryptedMessage = encryption.EncryptPlainText(userPlainTextToUpper, userKeyWordToUpper);
            Console.WriteLine($"The encrypted text is :" + encryptedMessage);
            
            
            char[] keyWordString = encryption.CreateCodeString(encryptedMessage, userKeyWordToUpper);

            string decryptedMsg = encryption.DecryptEncryptedMessage(encryptedMessage,keyWordString);

            Console.WriteLine($"The encrypted text is :" + decryptedMsg);
        }
    }
}
