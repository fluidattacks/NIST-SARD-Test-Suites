/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE319_Cleartext_Tx_Sensitive_Info__NetClient_SqlConnection_06.cs
Label Definition File: CWE319_Cleartext_Tx_Sensitive_Info.label.xml
Template File: sources-sinks-06.tmpl.cs
*/
/*
* @description
* CWE: 319 Cleartext Transmission of Sensitive Information
* BadSource: NetClient Read password from a web server with WebClient
* GoodSource: Set password to a hardcoded value (one that was not sent over the network)
* Sinks: SqlConnection
*    GoodSink: Decrypt the password from the source before using it in database connection
*    BadSink : Use password directly from source in database connection
* Flow Variant: 06 Control flow: if(PRIVATE_CONST_FIVE==5) and if(PRIVATE_CONST_FIVE!=5)
*
* */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;

using System.Net;

namespace testcases.CWE319_Cleartext_Tx_Sensitive_Info
{
class CWE319_Cleartext_Tx_Sensitive_Info__NetClient_SqlConnection_06 : AbstractTestCase
{

    /* The variable below is declared "const", so a tool should be able
     * to identify that reads of this will always give its initialized
     * value. */
    private const int PRIVATE_CONST_FIVE = 5;
#if (!OMITBAD)
    public override void Bad()
    {
        string password;
        if (PRIVATE_CONST_FIVE==5)
        {
            password = ""; /* init password */
            /* read input from WebClient */
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        using (StreamReader sr = new StreamReader(client.OpenRead("http://www.example.org/")))
                        {
                            /* POTENTIAL FLAW: Read password from a web server with WebClient */
                            /* This will be reading the first "line" of the response body,
                             * which could be very long if there are no newlines in the HTML */
                            password = sr.ReadLine();
                        }
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
                }
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure password is inititialized before the Sink to avoid compiler errors */
            password = null;
        }
        if (PRIVATE_CONST_FIVE==5)
        {
            try
            {
                /* POTENTIAL FLAW: use password directly in SqlConnection() */
                using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=CWE256;User ID=" + "sa" + ";Password=" + password))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from test_table", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with database connection", exceptSql);
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing first PRIVATE_CONST_FIVE==5 to PRIVATE_CONST_FIVE!=5 */
    private void GoodG2B1()
    {
        string password;
        if (PRIVATE_CONST_FIVE!=5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure password is inititialized before the Sink to avoid compiler errors */
            password = null;
        }
        else
        {
            /* FIX: Use a hardcoded password as the password (it was not sent over the network) */
            /* INCIDENTAL FLAW: CWE-259 Hard Coded Password */
            password = "Password1234!";
        }
        if (PRIVATE_CONST_FIVE==5)
        {
            try
            {
                /* POTENTIAL FLAW: use password directly in SqlConnection() */
                using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=CWE256;User ID=" + "sa" + ";Password=" + password))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from test_table", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with database connection", exceptSql);
            }
        }
    }

    /* GoodG2B2() - use goodsource and badsink by reversing statements in first if */
    private void GoodG2B2()
    {
        string password;
        if (PRIVATE_CONST_FIVE==5)
        {
            /* FIX: Use a hardcoded password as the password (it was not sent over the network) */
            /* INCIDENTAL FLAW: CWE-259 Hard Coded Password */
            password = "Password1234!";
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure password is inititialized before the Sink to avoid compiler errors */
            password = null;
        }
        if (PRIVATE_CONST_FIVE==5)
        {
            try
            {
                /* POTENTIAL FLAW: use password directly in SqlConnection() */
                using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=CWE256;User ID=" + "sa" + ";Password=" + password))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from test_table", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with database connection", exceptSql);
            }
        }
    }

    /* goodB2G1() - use badsource and goodsink by changing second PRIVATE_CONST_FIVE==5 to PRIVATE_CONST_FIVE!=5 */
    private void GoodB2G1()
    {
        string password;
        if (PRIVATE_CONST_FIVE==5)
        {
            password = ""; /* init password */
            /* read input from WebClient */
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        using (StreamReader sr = new StreamReader(client.OpenRead("http://www.example.org/")))
                        {
                            /* POTENTIAL FLAW: Read password from a web server with WebClient */
                            /* This will be reading the first "line" of the response body,
                             * which could be very long if there are no newlines in the HTML */
                            password = sr.ReadLine();
                        }
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
                }
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure password is inititialized before the Sink to avoid compiler errors */
            password = null;
        }
        if (PRIVATE_CONST_FIVE!=5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            if (password != null)
            {
                /* FIX: Decrypt password before using in getConnection() */
                {
                    using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                    {
                        aesAlg.Padding = PaddingMode.None;
                        aesAlg.Key = Encoding.UTF8.GetBytes("ABCDEFGHABCDEFGH");
                        // Create a decryptor to perform the stream transform.
                        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                        // Create the streams used for decryption.
                        using (MemoryStream msDecrypt = new MemoryStream(Encoding.UTF8.GetBytes(password)))
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
                try
                {
                    /* POTENTIAL FLAW: use password directly in SqlConnection() */
                    using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=CWE256;User ID=" + "sa" + ";Password=" + password))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("select * from test_table", connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error with database connection", exceptSql);
                }
            }
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing statements in second if  */
    private void GoodB2G2()
    {
        string password;
        if (PRIVATE_CONST_FIVE==5)
        {
            password = ""; /* init password */
            /* read input from WebClient */
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        using (StreamReader sr = new StreamReader(client.OpenRead("http://www.example.org/")))
                        {
                            /* POTENTIAL FLAW: Read password from a web server with WebClient */
                            /* This will be reading the first "line" of the response body,
                             * which could be very long if there are no newlines in the HTML */
                            password = sr.ReadLine();
                        }
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
                }
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure password is inititialized before the Sink to avoid compiler errors */
            password = null;
        }
        if (PRIVATE_CONST_FIVE==5)
        {
            if (password != null)
            {
                /* FIX: Decrypt password before using in getConnection() */
                {
                    using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                    {
                        aesAlg.Padding = PaddingMode.None;
                        aesAlg.Key = Encoding.UTF8.GetBytes("ABCDEFGHABCDEFGH");
                        // Create a decryptor to perform the stream transform.
                        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                        // Create the streams used for decryption.
                        using (MemoryStream msDecrypt = new MemoryStream(Encoding.UTF8.GetBytes(password)))
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
                try
                {
                    /* POTENTIAL FLAW: use password directly in SqlConnection() */
                    using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=CWE256;User ID=" + "sa" + ";Password=" + password))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("select * from test_table", connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error with database connection", exceptSql);
                }
            }
        }
    }

    public override void Good()
    {
        GoodG2B1();
        GoodG2B2();
        GoodB2G1();
        GoodB2G2();
    }
#endif //omitgood
}
}
