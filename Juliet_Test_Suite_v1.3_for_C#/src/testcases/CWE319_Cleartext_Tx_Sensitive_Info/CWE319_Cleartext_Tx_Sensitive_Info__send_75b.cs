/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE319_Cleartext_Tx_Sensitive_Info__send_75b.cs
Label Definition File: CWE319_Cleartext_Tx_Sensitive_Info__send.label.xml
Template File: sources-sinks-75b.tmpl.cs
*/
/*
 * @description
 * CWE: 319 Cleartext Transmission of Sensitive Information
 * BadSource:  Establish data as a password
 * GoodSource: Use a regular string (non-sensitive string)
 * Sinks:
 *    GoodSink: encrypted_channel
 *    BadSink : unencrypted_channel
 * Flow Variant: 75 Data flow: data passed in a serialized object from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using System.Net.Sockets;
using System.Net.Security;
using System.Text;

namespace testcases.CWE319_Cleartext_Tx_Sensitive_Info
{
class CWE319_Cleartext_Tx_Sensitive_Info__send_75b
{
#if (!OMITBAD)
    public static void BadSink(byte[] dataSerialized )
    {
        try
        {
            string data;
            var binForm = new BinaryFormatter();
            using (var memStream = new MemoryStream())
            {
                memStream.Write(dataSerialized, 0, dataSerialized.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                data = (string)binForm.Deserialize(memStream);
            }
            try
            {
                using (TcpClient tcpClient = new TcpClient("remote_host", 1337))
                {
                    using (StreamWriter writer = new StreamWriter(tcpClient.GetStream()))
                    {
                        /* POTENTIAL FLAW: sending data over an unencrypted (non-SSL) channel */
                        writer.WriteLine(data);
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to the TcpClient", exceptIO);
            }
        }
        catch (SerializationException exceptSerialize)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "SerializationException in deserialization", exceptSerialize);
        }
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use GoodSource and BadSink */
    public static void GoodG2BSink(byte[] dataSerialized )
    {
        try
        {
            string data;
            var binForm = new BinaryFormatter();
            using (var memStream = new MemoryStream())
            {
                memStream.Write(dataSerialized, 0, dataSerialized.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                data = (string)binForm.Deserialize(memStream);
            }
            try
            {
                using (TcpClient tcpClient = new TcpClient("remote_host", 1337))
                {
                    using (StreamWriter writer = new StreamWriter(tcpClient.GetStream()))
                    {
                        /* POTENTIAL FLAW: sending data over an unencrypted (non-SSL) channel */
                        writer.WriteLine(data);
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to the TcpClient", exceptIO);
            }
        }
        catch (SerializationException exceptSerialize)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "SerializationException in deserialization", exceptSerialize);
        }
    }

    /* goodB2G() - use BadSource and GoodSink */
    public static void GoodB2GSink(byte[] dataSerialized )
    {
        try
        {
            string data;
            var binForm = new BinaryFormatter();
            using (var memStream = new MemoryStream())
            {
                memStream.Write(dataSerialized, 0, dataSerialized.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                data = (string)binForm.Deserialize(memStream);
            }
            try
            {
                using (TcpClient client = new TcpClient("remote_host", 1337))
                {
                    using (SslStream sslStream = new SslStream(client.GetStream()))
                    {
                        /* FIX: sending data over an SSL encrypted channel */
                        sslStream.Write(Encoding.UTF8.GetBytes(data));
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to the TcpClient", exceptIO);
            }
        }
        catch (SerializationException exceptSerialize)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "SerializationException in deserialization", exceptSerialize);
        }
    }
#endif
}
}
