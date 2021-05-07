/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE327_Use_Broken_Crypto__3DES_01.cs
Label Definition File: CWE327_Use_Broken_Crypto.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 327 Use of Broken or Risky Cryptographic Algorithm
* Sinks: 3DES
*    GoodSink: use AES
*    BadSink : use 3DES
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Security.Cryptography;

namespace testcases.CWE327_Use_Broken_Crypto
{
class CWE327_Use_Broken_Crypto__3DES_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        const string CIPHER_INPUT = "ABCDEFG123456";
        byte[] encrypted;
        using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
        {
            /* FLAW: Use a weak crypto algorithm, 3DES */
            ICryptoTransform encryptor = tdes.CreateEncryptor(tdes.Key, tdes.IV);
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
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
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
#endif //omitgood
}
}
