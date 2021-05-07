/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE325_Missing_Required_Cryptographic_Step__StreamWriter_17.cs
Label Definition File: CWE325_Missing_Required_Cryptographic_Step.label.xml
Template File: point-flaw-17.tmpl.cs
*/
/*
* @description
* CWE: 325 Missing Required Cryptographic Step
* Sinks: StreamWriter
*    GoodSink: Include call to swEncrypt.Write(plainText)
*    BadSink : Missing call to swEncrypt.Write(plainText)
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Security.Cryptography;

namespace testcases.CWE325_Missing_Required_Cryptographic_Step
{
class CWE325_Missing_Required_Cryptographic_Step__StreamWriter_17 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        for(int j = 0; j < 1; j++)
        {
            string plainText = "ABCDEFG123456";
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            /* FLAW: Missing call to swEncrypt.Write(plainText).  This will result in the hash being of no data */
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            IO.WriteLine(IO.ToHex(encrypted));
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() use the GoodSinkBody in the for statement */
    private void Good1()
    {
        for(int k = 0; k < 1; k++)
        {
            string plainText = "ABCDEFG123456";
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            /* FIX: Include call to swEncrypt.Write(plainText) */
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            IO.WriteLine(IO.ToHex(encrypted));
        }
    }

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
