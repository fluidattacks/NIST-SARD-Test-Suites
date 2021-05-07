/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE563_Assign_to_Variable_Without_Use__unused_init_variable_string_04.cs
Label Definition File: CWE563_Assign_to_Variable_Without_Use__unused_init_variable.label.xml
Template File: source-sinks-04.tmpl.cs
*/
/*
* @description
* CWE: 563 Assignment to Variable without Use
* BadSource:  Initialize data
* Sinks:
*    GoodSink: Use data
*    BadSink : do nothing
* Flow Variant: 04 Control flow: if(PRIVATE_CONST_TRUE) and if(PRIVATE_CONST_FALSE)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE563_Assign_to_Variable_Without_Use
{

class CWE563_Assign_to_Variable_Without_Use__unused_init_variable_string_04 : AbstractTestCase
{
    /* The two variables below are declared "const", so a tool should
     * be able to identify that reads of these will always return their
     * initialized values.
     */
    private const bool PRIVATE_CONST_TRUE = true;
    private const bool PRIVATE_CONST_FALSE = false;
#if (!OMITBAD)
    public override void Bad()
    {
        string data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = "Good";
        if (PRIVATE_CONST_TRUE)
        {
            /* FLAW: Do not use the variable */
            /* do nothing */
            ; /* empty statement needed for some flow variants */
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodB2G1() - use badsource and goodsink by changing PRIVATE_CONST_TRUE to PRIVATE_CONST_FALSE */
    private void GoodB2G1()
    {
        string data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = "Good";
        if (PRIVATE_CONST_FALSE)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Use data */
            IO.WriteLine(data);
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing statements in if  */
    private void GoodB2G2()
    {
        string data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = "Good";
        if (PRIVATE_CONST_TRUE)
        {
            /* FIX: Use data */
            IO.WriteLine(data);
        }
    }

    public override void Good()
    {
        GoodB2G1();
        GoodB2G2();
    }
#endif //omitgood
}
}
