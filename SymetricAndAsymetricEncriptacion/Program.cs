using System.Security.Cryptography;
using System.Text;
/*Console.WriteLine("Porporcione texto a cifrar");
var ByteConverter = new UnicodeEncoding();
byte[] dataToEncrypt = ByteConverter.GetBytes(Console.ReadLine() ?? "");
string? containerName = "SecretContainer";
var csp = new CspParameters() { KeyContainerName = containerName ?? "" };
byte[] encryptedData2;
using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
{
    encryptedData2 = RSA.Encrypt(dataToEncrypt, false);
}
File.WriteAllBytes(@"D:\\MyTest.txt", encryptedData2);*/
Console.WriteLine("Presiona una tecla para comenzar decifrado.");
Console.ReadKey();
byte[] encryptedData = File.ReadAllBytes(@"D:\\MyTest.txt");
string containerName = "SecretContainer";
var csp = new CspParameters() { KeyContainerName = containerName };
byte[] decryptedData;
using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
{
    decryptedData = RSA.Decrypt(encryptedData, false);
}
UnicodeEncoding TextConverter = new UnicodeEncoding();
Console.WriteLine(TextConverter.GetString(decryptedData));
Console.ReadKey();