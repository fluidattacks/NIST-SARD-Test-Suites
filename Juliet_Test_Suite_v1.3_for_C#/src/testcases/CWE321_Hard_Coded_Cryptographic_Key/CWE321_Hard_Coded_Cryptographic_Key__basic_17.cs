/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE321_Hard_Coded_Cryptographic_Key__basic_17.cs
Label Definition File: CWE321_Hard_Coded_Cryptographic_Key__basic.label.xml
Template File: sources-sink-17.tmpl.cs
*/
/*
* @description
* CWE: 321 Hard coded crypto key
* BadSource:  Set data to a hardcoded value
* GoodSource: Read data from the console using readLine()
* BadSink:  Use data as a cryptographic key
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.Security.Cryptography;
using System.Text;
using System.IO;


namespace testcases.CWE321_Hard_Coded_Cryptographic_Key
{

class CWE321_Hard_Coded_Cryptographic_Key__basic_17 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad()
    {
        string data;
        /* FLAW: Set data to a hardcoded value */
        data = "23 ~j;asn!@#/>as";
        for (int i = 0; i < 1; i++)
        {
            if (data != null)
            {
                string stringToEncrypt = "Super secret Squirrel";
                byte[] byteCipherText = null;
                /* POTENTIAL FLAW: Use data as a cryptographic key */
                using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
                {
                    // Create an encryptor to perform the stream transform.
                    ICryptoTransform encryptor = aes.CreateEncryptor(Encoding.UTF8.GetBytes(data), aes.IV);
                    // Create the streams used for encryption.
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(stringToEncrypt);
                            }
                            byteCipherText = msEncrypt.ToArray();
                        }
                    }
                }
                IO.WriteLine(IO.ToHex(byteCipherText)); /* Write encrypted data to console */
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink by reversing the block outside the
     * for statement with the one in the for statement */
    private void GoodG2B()
    {
        string data;
        data = ""; /* Initialize data */
        /* read user input from console with readLine */
        try
        {
            /* FIX: Read data from the console using readLine() */
            data = Console.ReadLine();
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
        }
        for (int i = 0; i < 1; i++)
        {
            if (data != null)
            {
                string stringToEncrypt = "Super secret Squirrel";
                byte[] byteCipherText = null;
                /* POTENTIAL FLAW: Use data as a cryptographic key */
                using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
                {
                    // Create an encryptor to perform the stream transform.
                    ICryptoTransform encryptor = aes.CreateEncryptor(Encoding.UTF8.GetBytes(data), aes.IV);
                    // Create the streams used for encryption.
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(stringToEncrypt);
                            }
                            byteCipherText = msEncrypt.ToArray();
                        }
                    }
                }
                IO.WriteLine(IO.ToHex(byteCipherText)); /* Write encrypted data to console */
            }
        }
    }

    public override void Good()
    {
        GoodG2B();
    }
#endif //omitgood
}
}
