/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE256_Unprotected_Storage_of_Credentials__basic_75a.cs
Label Definition File: CWE256_Unprotected_Storage_of_Credentials__basic.label.xml
Template File: sources-sinks-75a.tmpl.cs
*/
/*
 * @description
 * CWE: 256 Unprotected Storage of Credentials
 * BadSource:  Read password from a .txt file
 * GoodSource: Read password from a .txt file (from the property named password) and then decrypt it
 * Sinks:
 *    GoodSink: Decrypt password and use decrypted password as password to connect to DB
 *    BadSink : Use password as password to connect to DB
 * Flow Variant: 75 Data flow: data passed in a serialized object from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace testcases.CWE256_Unprotected_Storage_of_Credentials
{
class CWE256_Unprotected_Storage_of_Credentials__basic_75a : AbstractTestCase
{
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
        /* serialize password to a byte array */
        byte[] passwordSerialized = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, password);
                passwordSerialized = ms.ToArray();
            }
            CWE256_Unprotected_Storage_of_Credentials__basic_75b.BadSink(passwordSerialized  );
        }
        catch (SerializationException exceptSerialize)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Serialization exception in serialization", exceptSerialize);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use GoodSource and BadSink */
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
        /* POTENTIAL FLAW: The raw password read from the .txt file is passed on (without being decrypted) */
        /* serialize password to a byte array */
        byte[] passwordSerialized = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, password);
                passwordSerialized = ms.ToArray();
            }
            CWE256_Unprotected_Storage_of_Credentials__basic_75b.GoodG2BSink(passwordSerialized  );
        }
        catch (SerializationException exceptSerialize)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Serialization exception in serialization", exceptSerialize);
        }
    }

    /* goodB2G() - use BadSource and GoodSink */
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
        /* serialize password to a byte array */
        byte[] passwordSerialized = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, password);
                passwordSerialized = ms.ToArray();
            }
            CWE256_Unprotected_Storage_of_Credentials__basic_75b.GoodB2GSink(passwordSerialized  );
        }
        catch (SerializationException exceptSerialize)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Serialization exception in serialization", exceptSerialize);
        }
    }
#endif //omitgood
}
}
