/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE319_Cleartext_Tx_Sensitive_Info__listen_tcp_SqlConnection_22a.cs
Label Definition File: CWE319_Cleartext_Tx_Sensitive_Info.label.xml
Template File: sources-sinks-22a.tmpl.cs
*/
/*
 * @description
 * CWE: 319 Cleartext Transmission of Sensitive Information
 * BadSource: listen_tcp Read password using a listening tcp connection
 * GoodSource: Set password to a hardcoded value (one that was not sent over the network)
 * Sinks: SqlConnection
 *    GoodSink: Decrypt the password from the source before using it in database connection
 *    BadSink : Use password directly from source in database connection
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.IO;
using System.Net.Sockets;
using System.Net;

namespace testcases.CWE319_Cleartext_Tx_Sensitive_Info
{
class CWE319_Cleartext_Tx_Sensitive_Info__listen_tcp_SqlConnection_22a : AbstractTestCase
{

    /* The public static variable below is used to drive control flow in the sink function. */
    public static bool badPublicStatic = false;
#if (!OMITBAD)
    public override void Bad()
    {
        string password = null;
        password = ""; /* init password */
        /* Read data using a listening tcp connection */
        {
            TcpListener listener = null;
            try
            {
                /* read input from socket */
                listener = new TcpListener(IPAddress.Parse("10.10.1.10"), 39543);
                listener.Start();
                using (TcpClient tcpConn = listener.AcceptTcpClient())
                {
                    using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
                    {
                        /* POTENTIAL FLAW: Read password using a listening tcp connection */
                        password = sr.ReadLine();
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            finally
            {
                try
                {
                    if (listener != null)
                    {
                        listener.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing TcpListener", exceptIO);
                }
            }
        }
        badPublicStatic = true;
        CWE319_Cleartext_Tx_Sensitive_Info__listen_tcp_SqlConnection_22b.BadSink(password );
    }
#endif //omitbad
    /* The public static variables below are used to drive control flow in the sink functions. */
    public static bool goodB2G1PublicStatic = false;
    public static bool goodB2G2PublicStatic = false;
    public static bool goodG2BPublicStatic = false;
#if (!OMITGOOD)
    public override void Good()
    {
        GoodB2G1();
        GoodB2G2();
        GoodG2B();
    }

    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    private void GoodB2G1()
    {
        string password = null;
        password = ""; /* init password */
        /* Read data using a listening tcp connection */
        {
            TcpListener listener = null;
            try
            {
                /* read input from socket */
                listener = new TcpListener(IPAddress.Parse("10.10.1.10"), 39543);
                listener.Start();
                using (TcpClient tcpConn = listener.AcceptTcpClient())
                {
                    using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
                    {
                        /* POTENTIAL FLAW: Read password using a listening tcp connection */
                        password = sr.ReadLine();
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            finally
            {
                try
                {
                    if (listener != null)
                    {
                        listener.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing TcpListener", exceptIO);
                }
            }
        }
        goodB2G1PublicStatic = false;
        CWE319_Cleartext_Tx_Sensitive_Info__listen_tcp_SqlConnection_22b.GoodB2G1Sink(password );
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    private void GoodB2G2()
    {
        string password = null;
        password = ""; /* init password */
        /* Read data using a listening tcp connection */
        {
            TcpListener listener = null;
            try
            {
                /* read input from socket */
                listener = new TcpListener(IPAddress.Parse("10.10.1.10"), 39543);
                listener.Start();
                using (TcpClient tcpConn = listener.AcceptTcpClient())
                {
                    using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
                    {
                        /* POTENTIAL FLAW: Read password using a listening tcp connection */
                        password = sr.ReadLine();
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            finally
            {
                try
                {
                    if (listener != null)
                    {
                        listener.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing TcpListener", exceptIO);
                }
            }
        }
        goodB2G2PublicStatic = true;
        CWE319_Cleartext_Tx_Sensitive_Info__listen_tcp_SqlConnection_22b.GoodB2G2Sink(password );
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        string password = null;
        /* FIX: Use a hardcoded password as the password (it was not sent over the network) */
        /* INCIDENTAL FLAW: CWE-259 Hard Coded Password */
        password = "Password1234!";
        goodG2BPublicStatic = true;
        CWE319_Cleartext_Tx_Sensitive_Info__listen_tcp_SqlConnection_22b.GoodG2BSink(password );
    }
#endif //omitgood
}
}
