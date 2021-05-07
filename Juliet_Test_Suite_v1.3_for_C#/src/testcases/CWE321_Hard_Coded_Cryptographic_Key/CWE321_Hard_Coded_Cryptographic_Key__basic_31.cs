/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE321_Hard_Coded_Cryptographic_Key__basic_31.cs
Label Definition File: CWE321_Hard_Coded_Cryptographic_Key__basic.label.xml
Template File: sources-sink-31.tmpl.cs
*/
/*
 * @description
 * CWE: 321 Hard coded crypto key
 * BadSource:  Set data to a hardcoded value
 * GoodSource: Read data from the console using readLine()
 * Sinks:
 *    BadSink : Use data as a cryptographic key
 * Flow Variant: 31 Data flow: make a copy of data within the same method
 *
 * */

using TestCaseSupport;
using System;

using System.Security.Cryptography;
using System.Text;
using System.IO;


namespace testcases.CWE321_Hard_Coded_Cryptographic_Key
{

class CWE321_Hard_Coded_Cryptographic_Key__basic_31 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad()
    {
        string dataCopy;
        {
            string data;
            /* FLAW: Set data to a hardcoded value */
            data = "23 ~j;asn!@#/>as";
            dataCopy = data;
        }
        {
            string data = dataCopy;
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
    public override void Good()
    {
        GoodG2B();
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        string dataCopy;
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
            dataCopy = data;
        }
        {
            string data = dataCopy;
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
#endif //omitgood
}
}
