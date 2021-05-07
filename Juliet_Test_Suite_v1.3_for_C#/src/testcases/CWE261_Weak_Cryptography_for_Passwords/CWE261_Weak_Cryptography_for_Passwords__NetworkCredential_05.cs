/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE261_Weak_Cryptography_for_Passwords__NetworkCredential_05.cs
Label Definition File: CWE261_Weak_Cryptography_for_Passwords__NetworkCredential.label.xml
Template File: point-flaw-05.tmpl.cs
*/
/*
* @description
* CWE: 261 Weak Cryptography for Passwords
* Sinks:
*    GoodSink:
*    BadSink :
* Flow Variant: 05 Control flow: if(privateTrue) and if(privateFalse)
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Text;
using System.Net;
using System.Security.Cryptography;

namespace testcases.CWE261_Weak_Cryptography_for_Passwords
{
class CWE261_Weak_Cryptography_for_Passwords__NetworkCredential_05 : AbstractTestCase
{
    /* The two variables below are not defined as "readonly", but are never
     * assigned any other value, so a tool should be able to identify that
     * reads of these will always return their initialized values.
     */
    private bool privateTrue = true;
    private bool privateFalse = false;
#if (!OMITBAD)
    public override void Bad()
    {
        if (privateTrue)
        {
            string password = "";
            StreamReader sr;
            /* FLAW: Weak encryption of password and a malicious person may have access to file. */
            sr = new StreamReader("../../../common/weak_password_file.txt");
            password = sr.ReadLine();
            string decPass = Encoding.UTF8.GetString(Convert.FromBase64String(password));
            NetworkCredential netCred = new NetworkCredential("CWE261", decPass, "");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes privateTrue to privateFalse */
    private void Good1()
    {
        if (privateFalse)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            byte[] encryptedPassword;
            /* FIX: String encryption of password (128 bit). */
            encryptedPassword = File.ReadAllBytes("../../../common/strong_password_file.txt");
            string decPass = null;
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("ABCDEFGHABCDEFGH");
                aesAlg.IV = new byte[16];
                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(encryptedPassword))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            decPass = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            NetworkCredential netCred = new NetworkCredential("CWE261", decPass, "");
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (privateTrue)
        {
            byte[] encryptedPassword;
            /* FIX: String encryption of password (128 bit). */
            encryptedPassword = File.ReadAllBytes("../../../common/strong_password_file.txt");
            string decPass = null;
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("ABCDEFGHABCDEFGH");
                aesAlg.IV = new byte[16];
                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(encryptedPassword))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            decPass = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            NetworkCredential netCred = new NetworkCredential("CWE261", decPass, "");
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
