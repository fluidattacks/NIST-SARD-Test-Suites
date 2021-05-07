/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE477_Obsolete_Functions__Socket_TcpListener_10.cs
Label Definition File: CWE477_Obsolete_Functions.label.xml
Template File: point-flaw-10.tmpl.cs
*/
/*
* @description
* CWE: 477 Use of Obsolete Functions
* Sinks: Socket_TcpListener
*    GoodSink: Use of preferred System.Net.Sockets.TcpListener(IPAddress, Int32)
*    BadSink : Use of deprecated System.Net.Sockets.TcpListener(Int32)
* Flow Variant: 10 Control flow: if(IO.staticTrue) and if(IO.staticFalse)
*
* */

using TestCaseSupport;
using System;

using System.Net;
using System.Net.Sockets;

namespace testcases.CWE477_Obsolete_Functions
{
class CWE477_Obsolete_Functions__Socket_TcpListener_10 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.staticTrue)
        {
            /* FLAW: Use of deprecated Sockets.TcpListener(Int32) */
            TcpListener tcpListener = new TcpListener(13);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* good1() changes IO.staticTrue to IO.staticFalse */
    private void Good1()
    {
        if (IO.staticFalse)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Use preferred Sockets.TcpListener(IPAddress, Int32) */
            IPAddress hostIPAddress = IPAddress.Parse("8.8.8.8");
            TcpListener tcpListener = new TcpListener(hostIPAddress, 13);
        }
    }

    /* good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.staticTrue)
        {
            /* FIX: Use preferred Sockets.TcpListener(IPAddress, Int32) */
            IPAddress hostIPAddress = IPAddress.Parse("8.8.8.8");
            TcpListener tcpListener = new TcpListener(hostIPAddress, 13);
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
