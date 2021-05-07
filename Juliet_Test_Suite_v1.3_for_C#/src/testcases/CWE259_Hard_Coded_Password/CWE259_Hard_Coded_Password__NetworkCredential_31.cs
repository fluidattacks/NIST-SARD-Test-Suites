/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE259_Hard_Coded_Password__NetworkCredential_31.cs
Label Definition File: CWE259_Hard_Coded_Password.label.xml
Template File: sources-sink-31.tmpl.cs
*/
/*
 * @description
 * CWE: 259 Hard Coded Password
 * BadSource: hardcodedPassword Set data to a hardcoded string
 * GoodSource: Read data from the console using readLine()
 * Sinks: NetworkCredential
 *    BadSink : data used as password in NetworkCredential()
 * Flow Variant: 31 Data flow: make a copy of data within the same method
 *
 * */

using TestCaseSupport;
using System;

using System.Net;

using System.IO;

namespace testcases.CWE259_Hard_Coded_Password
{

class CWE259_Hard_Coded_Password__NetworkCredential_31 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad()
    {
        string dataCopy;
        {
            string data;
            /* FLAW: Set data to a hardcoded string */
            data = "7e5tc4s3";
            dataCopy = data;
        }
        {
            string data = dataCopy;
            if (data != null)
            {
                /* POTENTIAL FLAW: data used as password in NetworkCredential() */
                NetworkCredential credentials = new NetworkCredential("user", data, "domain");
                IO.WriteLine(credentials.ToString());
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
            data = ""; /* init data */
            /* FIX: Read data from the console using ReadLine() */
            try
            {
                /* POTENTIAL FLAW: Read data from the console using ReadLine */
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
                /* POTENTIAL FLAW: data used as password in NetworkCredential() */
                NetworkCredential credentials = new NetworkCredential("user", data, "domain");
                IO.WriteLine(credentials.ToString());
            }
        }
    }
#endif //omitgood
}
}
