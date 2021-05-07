#
# Running this script will update the files in each CWE directory that 
# allow for building that CWE's test cases into a separate .exe file.
#

import sys, os, shutil, glob, time

# add parent directory to search path so we can use py_common
sys.path.append("..")

import py_common
import update_csharp_templates


def copy_templates_and_program_to(directory, is_dir_split):

    # copy Program.cs into this testcase dir
    program_cs = os.path.join(directory, "Program.cs")

    shutil.copy("Program.cs.template", program_cs)

    # copy Main.sln into the this testcase dir
    main_sln = os.path.join(directory, "Main.sln")
    shutil.copy("Main.sln.template", main_sln)

    # create a Properties directory and copy AssemblyInfo.cs into it
    properties_dir = os.path.join(directory, "Properties")
    py_common.create_or_clean_directory(properties_dir)
    assembly_info_cs = os.path.join(properties_dir, "AssemblyInfo.cs")
    shutil.copy("AssemblyInfo.cs.template", assembly_info_cs)

    # copy Main.csproj into the this testcase dir
    main_csproj = os.path.join(directory, "Main.csproj")
    shutil.copy("Main.csproj.template", main_csproj)

    # copy App.config into the this testcase dir
    app_config = os.path.join(directory, "App.config")
    shutil.copy("App.config.template", app_config)
    
    # copy Build.bat into this testcase dir
    build_bat = os.path.join(directory, "Build.bat")
    shutil.copy("Build.bat.template", build_bat)


def help():
    """
    Provide the user with an example if the correct number of parameters are not used
    or if the '-h' argument is used.
    """
    sys.stderr.write('Usage: \n')
    sys.stderr.write('   create_per_cwe_files.py (builds per CWE files for all testcases)\n')
    sys.stderr.write('   create_per_cwe_files.py CWE (builds per CWE files for all testcases)\n')
    sys.stderr.write(
        '   create_per_cwe_files.py CWE(78|15) (builds per CWE files for test cases for CWE 78 and CWE 15)')


if __name__ == "__main__":
    # check if ./testcases directory exists, if not, we are running
    # from wrong working directory
    if not os.path.exists(os.path.join('src', 'testcases')):
        py_common.print_with_timestamp("Wrong working directory; could not find testcases directory")
        exit(1)

    # default value which is used if no arguments are passed on command line
    cwe_regex = "CWE"
    auto_build_sln = False
    OMITBAD = False
    OMITGOOD = False

    if len(sys.argv) > 5:
        help()
        exit()

    if len(sys.argv) == 4:
        if (sys.argv[1] == '-h'):
            help()
            exit()

        cwe_regex = sys.argv[1]

    if len(sys.argv) == 5:
        if (sys.argv[1] == '-h'):
            help()
            exit()

        cwe_regex = sys.argv[1]
        auto_build_sln = True
        if sys.argv[3] == "True":
            OMITBAD = True
        if sys.argv[4] == "True":
            OMITGOOD = True

    # get the CWE directories in testcases folder
    cwe_dirs = py_common.find_directories_in_dir(os.path.join('src', 'testcases'), cwe_regex)

    # only allow directories
    cwe_dirs = filter(lambda x: os.path.isdir(x), cwe_dirs)

    for dir in cwe_dirs:
        if 's01' in os.listdir(dir):
            is_dir_split = True
        else:
            is_dir_split = False

        if is_dir_split:
            # get the list of subdirectories
            cwe_sub_dirs = py_common.find_directories_in_dir(dir, "^s\d.*")

            for sub_dir in cwe_sub_dirs:
                # copy Program.cs into this testcase dir
                copy_templates_and_program_to(sub_dir, is_dir_split)

                # update all the files in this directory
                update_csharp_templates.update_csharp_templates(testcase_location=sub_dir, main_path=sub_dir)

                if auto_build_sln:
                    # build solution
                    oldWD = os.getcwd()
                    os.chdir(sub_dir)
                    if OMITGOOD:
                        py_common.run_commands(["msbuild -p:DefineConstants=OMITGOOD"], True)
                    elif OMITBAD:
                        py_common.run_commands(["msbuild -p:DefineConstants=OMITBAD"], True)
                    else:
                        py_common.run_commands(["msbuild"], True)
                    os.chdir(oldWD)

        else:
            # copy Program.cs into this testcase dir
            copy_templates_and_program_to(dir, is_dir_split)

            # update all the files in this directory
            update_csharp_templates.update_csharp_templates(testcase_location=dir, main_path=dir)

            if auto_build_sln:
                # build solution
                oldWD = os.getcwd()
                os.chdir(dir)
                if OMITGOOD:
                    py_common.run_commands(["msbuild -p:DefineConstants=OMITGOOD"], True)
                elif OMITBAD:
                    py_common.run_commands(["msbuild -p:DefineConstants=OMITBAD"], True)
                else:
                    py_common.run_commands(["msbuild"], True)
                os.chdir(oldWD)