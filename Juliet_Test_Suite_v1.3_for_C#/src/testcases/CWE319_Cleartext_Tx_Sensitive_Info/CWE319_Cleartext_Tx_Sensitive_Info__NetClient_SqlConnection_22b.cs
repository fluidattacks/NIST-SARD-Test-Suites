/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE319_Cleartext_Tx_Sensitive_Info__NetClient_SqlConnection_22b.cs
Label Definition File: CWE319_Cleartext_Tx_Sensitive_Info.label.xml
Template File: sources-sinks-22b.tmpl.cs
*/
/*
 * @description
 * CWE: 319 Cleartext Transmission of Sensitive Information
 * BadSource: NetClient Read password from a web server with WebClient
 * GoodSource: Set password to a hardcoded value (one that was not sent over the network)
 * Sinks: SqlConnection
 *    GoodSink: Decrypt the password from the source before using it in database connection
 *    BadSink : Use password directly from source in database connection
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace testcases.CWE319_Cleartext_Tx_Sensitive_Info
{
class CWE319_Cleartext_Tx_Sensitive_Info__NetClient_SqlConnection_22b
{
#if (!OMITBAD)
    public static void BadSink(string password )
    {
        if (CWE319_Cleartext_Tx_Sensitive_Info__NetClient_SqlConnection_22a.badPublicStatic)
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
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure password is inititialized before the Sink to avoid compiler errors */
            password = null;
        }
    }
#endif

#if (!OMITGOOD)
    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    public static void GoodB2G1Sink(string password )
    {
        if (CWE319_Cleartext_Tx_Sensitive_Info__NetClient_SqlConnection_22a.goodB2G1PublicStatic)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure password is inititialized before the Sink to avoid compiler errors */
            password = null;
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

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    public static void GoodB2G2Sink(string password )
    {
        if (CWE319_Cleartext_Tx_Sensitive_Info__NetClient_SqlConnection_22a.goodB2G2PublicStatic)
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
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure password is inititialized before the Sink to avoid compiler errors */
            password = null;
        }
    }

    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string password )
    {
        if (CWE319_Cleartext_Tx_Sensitive_Info__NetClient_SqlConnection_22a.goodG2BPublicStatic)
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
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure password is inititialized before the Sink to avoid compiler errors */
            password = null;
        }
    }
#endif
}
}
