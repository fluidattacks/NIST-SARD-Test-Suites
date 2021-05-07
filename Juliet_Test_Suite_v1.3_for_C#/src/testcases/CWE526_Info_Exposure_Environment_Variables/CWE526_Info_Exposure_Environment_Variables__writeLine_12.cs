/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE526_Info_Exposure_Environment_Variables__writeLine_12.cs
Label Definition File: CWE526_Info_Exposure_Environment_Variables.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 526 Information Exposure Through Environment Variables
* Sinks: writeLine
*    GoodSink: no exposing
*    BadSink : expose the path variable to the user
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE526_Info_Exposure_Environment_Variables
{
class CWE526_Info_Exposure_Environment_Variables__writeLine_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FLAW: environment variable information exposed */
            IO.WriteLine("Not in path: " + Environment.GetEnvironmentVariable("PATH"));
        }
        else
        {
            /* FIX: error message is general */
            IO.WriteLine("Not in path");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes the "if" so that both branches use the GoodSink */
    private void Good1()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: error message is general */
            IO.WriteLine("Not in path");
        }
        else
        {
            /* FIX: error message is general */
            IO.WriteLine("Not in path");
        }
    }

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
