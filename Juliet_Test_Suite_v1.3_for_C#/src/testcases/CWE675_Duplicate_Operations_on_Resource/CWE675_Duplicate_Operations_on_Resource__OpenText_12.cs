/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE675_Duplicate_Operations_on_Resource__OpenText_12.cs
Label Definition File: CWE675_Duplicate_Operations_on_Resource.label.xml
Template File: sources-sinks-12.tmpl.cs
*/
/*
* @description
* CWE: 675 Duplicate Operations on Resource
* BadSource: OpenText Open and close a file using OpenText and Close()
* GoodSource: Open a file using OpenText()
* Sinks:
*    GoodSink: Do nothing
*    BadSink : Close the StreamReader
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE675_Duplicate_Operations_on_Resource
{
class CWE675_Duplicate_Operations_on_Resource__OpenText_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        StreamReader data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            data = File.OpenText(@"BadSource_OpenText.txt");
            /* POTENTIAL FLAW: Close the file in the source */
            data.Close();
        }
        else
        {
            /* FIX: Open, but do not close the file in the source */
            data = File.OpenText(@"GoodSource_OpenText.txt");
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* POTENTIAL FLAW: Close the file in the sink (it may have been closed in the Source) */
            data.Close();
        }
        else
        {
            /* Do nothing */
            /* FIX: Don't close the file in the sink */
            ; /* empty statement needed for some flow variants */
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink by changing the first "if" so that
     * both branches use the GoodSource */
    private void GoodG2B()
    {
        StreamReader data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: Open, but do not close the file in the source */
            data = File.OpenText(@"GoodSource_OpenText.txt");
        }
        else
        {
            /* FIX: Open, but do not close the file in the source */
            data = File.OpenText(@"GoodSource_OpenText.txt");
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* POTENTIAL FLAW: Close the file in the sink (it may have been closed in the Source) */
            data.Close();
        }
        else
        {
            /* POTENTIAL FLAW: Close the file in the sink (it may have been closed in the Source) */
            data.Close();
        }
    }

    /* goodB2G() - use badsource and goodsink by changing the second "if" so that
     * both branches use the GoodSink */
    private void GoodB2G()
    {
        StreamReader data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            data = File.OpenText(@"BadSource_OpenText.txt");
            /* POTENTIAL FLAW: Close the file in the source */
            data.Close();
        }
        else
        {
            data = File.OpenText(@"BadSource_OpenText.txt");
            /* POTENTIAL FLAW: Close the file in the source */
            data.Close();
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* Do nothing */
            /* FIX: Don't close the file in the sink */
            ; /* empty statement needed for some flow variants */
        }
        else
        {
            /* Do nothing */
            /* FIX: Don't close the file in the sink */
            ; /* empty statement needed for some flow variants */
        }
    }

    public override void Good()

    {
        GoodG2B();
        GoodB2G();
    }
#endif //omitgood
}
}
