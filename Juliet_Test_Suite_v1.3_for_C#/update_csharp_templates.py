#
# Running this script will update files that are used when all of the test
# cases are compiled into a single .exe file.
#

import sys,os,re, hashlib
import xml.etree.ElementTree as ET

# add parent directory to search path so we can use py_common
sys.path.append("..")

import py_common

def build_guid(input):
    hash_val_in_hex = hashlib.sha256(bytearray(input, 'utf-8')).hexdigest().upper()

    guid = "{" \
        + hash_val_in_hex[0:8] \
        + "-" + hash_val_in_hex[8:12] \
        + "-" + hash_val_in_hex[12:16] \
        + "-" + hash_val_in_hex[16:20] \
        + "-" + hash_val_in_hex[20:32] \
        + "}"
        
    return guid

def build_list_of_csharp_testcase_files(directory):
    """
    Build a list of Csharp files in the directory.
    """
    files_to_check = []
    for root, dirs, files in os.walk(directory):
        for name in files:
            result = re.search(py_common.get_primary_testcase_filename_regex(), name, re.IGNORECASE)

            if result != None:
                files_to_check.append(os.path.realpath(os.path.join(root,name)))

        # don't enumerate files in .svn dirs
        if '.svn' in dirs: 
            dirs.remove('.svn')

        # don't enumerate files in support directories
        if 'testcasesupport' in dirs:
            dirs.remove('testcasesupport')

    return files_to_check

def update_file(file_path, file, tag_start, tag_end, lines):
    """
    Get the contents of the file based on tags and update the file.
    """
    full_file_path = os.path.join(file_path, file)
    file_contents = py_common.open_file_and_get_contents(full_file_path)

    # get contents from start of file up to tag, get contents from end tag
    # to EOF
    up_to_tag_start = file_contents.split(tag_start)[0]
    tag_end_to_eof = file_contents.split(tag_end)[1]

    auto_gen_content = "\n".join(lines)

    # re-build the file with the modified content between the tags
    modified_file_contents = up_to_tag_start + \
            tag_start + "\n" + \
            auto_gen_content + "\n" + \
            "\t\t\t" + tag_end + \
            tag_end_to_eof

    # write out the new file
    outfile = os.path.join(file_path, file)
    py_common.write_file(outfile, modified_file_contents)

def update_namespace_name(file, namespace):
    """
    Update the namespace name for the file.
    """
    contents = py_common.open_file_and_get_contents(file)
    contents = contents.replace("$TestCaseNamespace$",namespace)
    py_common.write_file(file, contents)
    

def update_Program(file_path, non_servlet_testcase_lines, namespace):
    """
    Program.cs has 9 separate locations where we need to replace text
    """
    # tags for Main.java that indicate where to replace text
    program_dot_cs = "Program.cs";
    auto_gen_tag_start = "/* BEGIN-AUTOGENERATED-CSHARP-TESTS-X */"
    auto_gen_tag_end = "/* END-AUTOGENERATED-CSHARP-TESTS-X */"
    for i in range(1,10):
    
        # replace the X in the tags with the current number
        current_auto_gen_tag_start = auto_gen_tag_start.replace("X", str(i))
        current_auto_gen_tag_end = auto_gen_tag_end.replace("X", str(i))
    
        # filter non_servlet_testcase_lines to just ones for CWE1, CWE2, etc
        test = re.compile("CWE"+str(i))
        
        current_testcase_lines = [f for f in non_servlet_testcase_lines if test.search(f)] 
        
        # call update-file
        update_file(file_path, program_dot_cs, current_auto_gen_tag_start, current_auto_gen_tag_end, current_testcase_lines)
        
    # replace namespace name with the correct namespace
    update_namespace_name(os.path.join(file_path, program_dot_cs), namespace)
    
def update_and_rename_Main_sln(file_path, cwe_name, csproj_guid, testcasesupport_csproj_guid):
    is_split = False
    if os.path.basename(file_path).startswith('s'):
        is_split = True
        
    cwe = cwe_name
    if is_split:
        cwe += "_" + os.path.basename(file_path)
        
    src_file = os.path.join(file_path, "Main.sln")    
    dest_file = os.path.join(file_path, cwe + ".sln")
    
    # If the solution file already exists, delete it first or the rename function won't work on Windows
    if os.path.isfile(dest_file):
        os.remove(dest_file)
    
    os.rename(src_file, dest_file)
    
    contents = py_common.open_file_and_get_contents(dest_file)
    contents = contents.replace("$CWE$", cwe)
    
    # generate fake project GUID
    cwe_project_guid = build_guid(cwe + ".sln")
    
    contents = contents.replace("$CWE_PROJECT_GUID$", cwe_project_guid)
    contents = contents.replace("$CWE_CSPROJ_GUID$", csproj_guid)
    contents = contents.replace("$TCS_CSPROJ_GUID$", testcasesupport_csproj_guid)
    
    if is_split:
        contents = contents.replace("$SPLIT_DIR$", '..\\')
    else:
        contents = contents.replace("$SPLIT_DIR$", '')
        
    py_common.write_file(dest_file, contents)
    
def update_AssemblyInfo_cs(file_path, cwe_name, csproj_guid):
    is_split = False
    if os.path.basename(file_path).startswith('s'):
        is_split = True
        
    cwe = cwe_name
    if is_split:
        cwe += "_" + os.path.basename(file_path)
        
    assemblyinfo_dot_cs = os.path.join(file_path, "Properties", "AssemblyInfo.cs");
    
    contents = py_common.open_file_and_get_contents(assemblyinfo_dot_cs)
    
    contents = contents.replace("$CWE$", cwe)
    
    # Have to remove the leading { and trailing }
    contents = contents.replace("$CWE_CSPROJ_GUID$", csproj_guid.lower()[1:-1])
    
    py_common.write_file(assemblyinfo_dot_cs, contents)
    
def update_and_rename_Main_csproj(file_path, cwe_name, csproj_guid, testcasesupport_csproj_guid):
    is_split = False
    if os.path.basename(file_path).startswith('s'):
        is_split = True
        
    cwe = cwe_name
    if is_split:
        cwe += "_" + os.path.basename(file_path)
    
    src_file = os.path.join(file_path, "Main.csproj")
    dest_file = os.path.join(file_path, cwe + ".csproj")
    
    # If the project file already exists, delete it first or the rename function won't work on Windows
    if os.path.isfile(dest_file):
        os.remove(dest_file)
    
    os.rename(src_file, dest_file)
    
    contents = py_common.open_file_and_get_contents(dest_file)
    contents = contents.replace("$CWE$", cwe)
    contents = contents.replace("$CWE_ROOT$", cwe_name)
    contents = contents.replace("$CWE_CSPROJ_GUID$", csproj_guid)
    contents = contents.replace("$TCS_CSPROJ_GUID$", testcasesupport_csproj_guid)
    
    test_case_files = py_common.find_files_in_dir(file_path, "^CWE.*\.cs$")
    items = ""
    for test_case_file in test_case_files:
        # This check is necessary due to CWE468 as this CWE contains 2 identical .cs files,
        # however they are in different directories, so we need to ensure they both get added
        # correctly by adding the path to the 2nd .cs file (HelperClass)
        test_case_file_dir = os.path.basename(os.path.dirname(test_case_file))
        if test_case_file_dir.lower().startswith('cwe') or re.match('s\d\d', test_case_file_dir, re.IGNORECASE):
            items += '    <Compile Include="' + os.path.basename(test_case_file) + '" />\n'
        else:
            items += '    <Compile Include="' + os.path.join(test_case_file_dir, os.path.basename(test_case_file)) + '" />\n'
    
    contents = contents.replace("$FILE_NAMES$", items)
    
    if os.path.basename(file_path).startswith('s'):
        contents = contents.replace("$SPLIT_DIR$", '..\\')
    else:
        contents = contents.replace("$SPLIT_DIR$", '')

    py_common.write_file(dest_file, contents)
        
def update_csharp_templates(testcase_location=".", main_path="src\\testcasesupport\\"):    
    """
    Update Program.cs
    """
    # get list of testcase files
    testcase_files = build_list_of_csharp_testcase_files(testcase_location)
    
    # Get the TestCaseSupport.csproj GUID
    testcasesupport_csproj = "src\\TestCaseSupport\\TestCaseSupport\\TestCaseSupport.csproj"
    tree = ET.parse(testcasesupport_csproj)
    root = tree.getroot()
    ns = {'pg':'http://schemas.microsoft.com/developer/msbuild/2003'}
    property_groups = root.findall('pg:PropertyGroup', ns)
    tcs_project_guid = property_groups[0].find('pg:ProjectGuid', ns)

    if (len(testcase_files) > 0):
        # build up the class instantiation lines
        testcase_lines = []
        namespace = ""
        for fullfilepath in testcase_files:

            filename = os.path.basename(fullfilepath)

            # figure out the namespace based on the file path
            tc_index = fullfilepath.index(os.path.join("src", "testcases"))
            f_index = fullfilepath.index(filename)
            namespace = "testcases" + fullfilepath[tc_index + len(os.path.join("src", "testcases")):f_index].replace("\\", ".")
            
            # remove .cs from the end of the filename to get the classname
            classname = filename[:-3]

            if "Web" not in classname:
                line = "\t\t\t(new " + classname + \
                        "()).RunTest(\"" + classname + "\");"
                testcase_lines.append(line)
        
        # Remove the trailing '.' from the namespace
        namespace = namespace[:-1]
        
        # Check if this is a split directory and remove the 's##' if so
        r1 = re.compile('\.s\d\d$')
        if r1.search(namespace):
            namespace = namespace[:-4]
        
        # update Program_cs
        update_Program(main_path, testcase_lines, namespace)
        
        cwe_and_name = os.path.basename(os.path.dirname(testcase_files[0]))
        if cwe_and_name.startswith('s'):
            cwe_and_name = os.path.basename(os.path.dirname(os.path.dirname(testcase_files[0])))
        csproj_guid = build_guid(main_path + ".csproj")
        
        # update the VS Solution template and rename it to the CWE name
        update_and_rename_Main_sln(main_path, cwe_and_name, csproj_guid, tcs_project_guid.text)
        
        # update the VS CS Project template and rename it to the CWE name
        update_and_rename_Main_csproj(main_path, cwe_and_name, csproj_guid, tcs_project_guid.text)
        
        # Update the AssemblyInfo.cs template
        update_AssemblyInfo_cs(main_path, cwe_and_name, csproj_guid)
    else:
        py_common.print_with_timestamp("[INFO] Skipping directory: " + testcase_location)

