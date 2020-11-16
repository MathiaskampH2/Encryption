using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class Encryption
    {
        private readonly char[,] encryptionTable = new char[26, 26]
             {
                {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','X','R','S','T','U','V','W','X','Y','Z'},
                {'B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A'},
                {'C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B'},
                {'D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C'},
                {'E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D'},
                {'F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E'},
                {'G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F'},
                {'H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G'},
                {'I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H'},
                {'J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I'},
                {'K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J'},
                {'L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K'},
                {'M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L'},
                {'N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M'},
                {'O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N'},
                {'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O'},
                {'Q','R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P'},
                {'R','S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q'},
                {'S','T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R'},
                {'T','U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S'},
                {'U','V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T'},
                {'V','W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U'},
                {'W','X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V'},
                {'X','Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W'},
                {'Y','Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X'},
                {'Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y'}};


        public int GetIndexOfxAxis(char x)
        {
            for (int i = 0; i < 26; i++)
            {
                if (encryptionTable[i,0] == x)
                {
                    return i;
                }
            }
            return 0;
        }

        public int GetIndexOfyAxis(char y)
        {
            for (int i = 0; i < 26; i++)
            {
                if (encryptionTable[0, i] == y)
                {
                    return i;
                }
            }
            return 0;
        }

        public char DecryptPlainText(char arrayLetter, char plainTextLetter)
        {
            int x = GetIndexOfxAxis(arrayLetter);
            int y = GetIndexOfyAxis(plainTextLetter);

            int endValue = x - y;

            if (endValue < 0)
            {
                endValue += 26;
            }

            return encryptionTable[endValue, 0];
        }

        public char[] CreateCodeString(string plainText, string keyWord)
        {
            int maxKeyWordLength = plainText.Length / keyWord.Length + keyWord.Length;
            
            string finalString = "";

            for (int i = 0; i < maxKeyWordLength; i++)
            {
                finalString += keyWord;
            }

            return finalString.ToCharArray();
        }


        public string EncryptPlainText(string plainText, string keyWord)
        {
            char[] plainTextArray = plainText.ToCharArray();
            char[] codeTextArray = CreateCodeString(plainText, keyWord);
            string encryptedMessage = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                int tmpKeyWordIndex = (int)GetIndexOfxAxis(codeTextArray[i]);
                int tmpPlainTextIndex = (int)GetIndexOfyAxis(plainTextArray[i]);

                encryptedMessage += encryptionTable[tmpKeyWordIndex, tmpPlainTextIndex];
            }

            return encryptedMessage;
        }

        public string DecryptEncryptedMessage(string encryptedMsg, char [] keyWord)
        {

            char[] encryptedMessageCharArray = encryptedMsg.ToCharArray();
            char[] encryptionCodeText = keyWord;
            string decryptedMessage = "";
            for (int i = 0; i < encryptedMessageCharArray.Length; i++)
            {
                decryptedMessage += DecryptPlainText(encryptedMessageCharArray[i], encryptionCodeText[i]);
            }

            return decryptedMessage;
        }
    }
}
