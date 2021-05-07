/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE327_Use_Broken_Crypto__DES_06.cs
Label Definition File: CWE327_Use_Broken_Crypto.label.xml
Template File: point-flaw-06.tmpl.cs
*/
/*
* @description
* CWE: 327 Use of Broken or Risky Cryptographic Algorithm
* Sinks: DES
*    GoodSink: use AES
*    BadSink : use DES
* Flow Variant: 06 Control flow: if(PRIVATE_CONST_FIVE==5) and if(PRIVATE_CONST_FIVE!=5)
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Security.Cryptography;

namespace testcases.CWE327_Use_Broken_Crypto
{
class CWE327_Use_Broken_Crypto__DES_06 : AbstractTestCase
{
    /* The variable below is declared "const", so a tool should be able
     * to identify that reads of this will always give its initialized
     * value.
     */
    private const int PRIVATE_CONST_FIVE = 5;
#if (!OMITBAD)
    public override void Bad()
    {
        if (PRIVATE_CONST_FIVE == 5)
        {
            const string CIPHER_INPUT = "ABCDEFG123456";
            byte[] encrypted;
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                /* FLAW: Use a weak crypto algorithm, DES */
                ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(CIPHER_INPUT);
                        }
                        encrypted = ms.ToArray();
                    }
                }
            }
            string encPhrase = System.Text.Encoding.UTF8.GetString(encrypted);
            IO.WriteLine(IO.ToHex(encrypted));
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes PRIVATE_CONST_FIVE==5 to PRIVATE_CONST_FIVE!=5 */
    private void Good1()
    {
        if (PRIVATE_CONST_FIVE != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            const string CIPHER_INPUT = "ABCDEFG123456";
            byte[] encrypted;
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                /* FIX: Use a stronger crypto algorithm, AES */
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(CIPHER_INPUT);
                        }
                        encrypted = ms.ToArray();
                    }
                }
            }
            string encPhrase = System.Text.Encoding.UTF8.GetString(encrypted);
            IO.WriteLine(IO.ToHex(encrypted));
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (PRIVATE_CONST_FIVE == 5)
        {
            const string CIPHER_INPUT = "ABCDEFG123456";
            byte[] encrypted;
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                /* FIX: Use a stronger crypto algorithm, AES */
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(CIPHER_INPUT);
                        }
                        encrypted = ms.ToArray();
                    }
                }
            }
            string encPhrase = System.Text.Encoding.UTF8.GetString(encrypted);
            IO.WriteLine(IO.ToHex(encrypted));
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
