/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE256_Unprotected_Storage_of_Credentials__basic_67a.cs
Label Definition File: CWE256_Unprotected_Storage_of_Credentials__basic.label.xml
Template File: sources-sinks-67a.tmpl.cs
*/
/*
 * @description
 * CWE: 256 Unprotected Storage of Credentials
 * BadSource:  Read password from a .txt file
 * GoodSource: Read password from a .txt file (from the property named password) and then decrypt it
 * Sinks:
 *    GoodSink: Decrypt password and use decrypted password as password to connect to DB
 *    BadSink : Use password as password to connect to DB
 * Flow Variant: 67 Data flow: data passed in a class from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace testcases.CWE256_Unprotected_Storage_of_Credentials
{
class CWE256_Unprotected_Storage_of_Credentials__basic_67a : AbstractTestCase
{

    public class Container
    {
        public string containerOne;
    }
#if (!OMITBAD)
    public override void Bad()
    {
        string password;
        password = ""; /* init password */
        /* retrieve the password */
        try
        {
            password = Encoding.UTF8.GetString(File.ReadAllBytes("../../../common/strong_password_file.txt"));
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with file reading", exceptIO);
        }
        /* POTENTIAL FLAW: The raw password read from the .txt file is passed on (without being decrypted) */
        Container passwordContainer = new Container();
        passwordContainer.containerOne = password;
        CWE256_Unprotected_Storage_of_Credentials__basic_67b.BadSink(passwordContainer  );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        string password;
        password = ""; /* init password */
        /* retrieve the password */
        try
        {
            password = Encoding.UTF8.GetString(File.ReadAllBytes("../../../common/strong_password_file.txt"));
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with file reading", exceptIO);
        }
        /* FIX: password is decrypted before being passed on */
        {
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("ABCDEFGHABCDEFGH");
                aesAlg.IV = new byte[16];
                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(File.ReadAllBytes("../../../common/strong_password_file.txt")))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            password = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        Container passwordContainer = new Container();
        passwordContainer.containerOne = password;
        CWE256_Unprotected_Storage_of_Credentials__basic_67b.GoodG2BSink(passwordContainer  );
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G()
    {
        string password;
        password = ""; /* init password */
        /* retrieve the password */
        try
        {
            password = Encoding.UTF8.GetString(File.ReadAllBytes("../../../common/strong_password_file.txt"));
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with file reading", exceptIO);
        }
        /* POTENTIAL FLAW: The raw password read from the .txt file is passed on (without being decrypted) */
        Container passwordContainer = new Container();
        passwordContainer.containerOne = password;
        CWE256_Unprotected_Storage_of_Credentials__basic_67b.GoodB2GSink(passwordContainer  );
    }
#endif //omitgood
}
}
