'-------------------------------------------------------------------------------
' This script takes a template AssemblyInfo file, and a file with a major/minor
' version and a subversion revision number in it, and combines them to form a 
' full version number in the config file.
'
' Arguments;
' 1. Template AssemblyInfo.cs (required)
' 2. Source file with version information (required)
' 3. Output file (optional)
'
' If this script is run with wscript, a third argument is necessary to specify
' the output file. If run with cscript, the third argument is optional, if not
' specified the result is displayed on stdout.
'
'
' Example pre-build script (all on one line):
'
'   $(SolutionDir)\buildtools\assembly-version-from-svn.vbs
'     $(ProjectDir)\Properties\AssemblyInfo.cs.dist $(ProjectDir)\Program.cs
'     $(ProjectDir)\Properties\AssemblyInfo.cs
'-------------------------------------------------------------------------------
option explicit

dim fso: set fso = createObject("Scripting.FileSystemObject")

if wscript.arguments.count < 2 then error 1, "Usage: assembly-version-from-svn.vbs TEMPLATE MAINFILE [OUTFILE]" & vbCrlf & vbCrlf & "See comments inside script for details."

dim templateFile: templateFile = wscript.arguments(0)
dim versioningFile: versioningFile = wscript.arguments(1)

dim template: template = fso.openTextFile(templateFile).readAll
dim versioning: versioning = fso.openTextFile(versioningFile).readAll

dim majorVersion: majorVersion = reFind("version\s*=\s*""([0-9.]+)""", versioning)
if majorVersion = "" then error 3, "No 'version = ""xx.yy""' declaration found in " & versioningFile
dim revision: revision = reFind("\$\s*revision:\s*([0-9]+)\s*\$", versioning)
if revision = "" then error 4, "No Subversion '$revision: xx$' keyword found in " & versioningFile

dim fullVersion: fullVersion = majorVersion & "." & revision

template = reSub("AssemblyVersion\(""\d+\.\d+\.\d+\.\d+""\)",     "AssemblyVersion(""" + fullVersion + ".0"")", template)
template = reSub("AssemblyFileVersion\(""\d+\.\d+\.\d+\.\d+""\)", "AssemblyFileVersion(""" + fullVersion + ".0"")", template)

dim outFile
if wscript.arguments.count >= 3 then
    set outFile = fso.CreateTextFile(wscript.arguments(2))
else
    if right(lcase(wscript.fullName), 11) = "wscript.exe" then error 2, "When run with WScript, an outfile argument is required!"
    set outFile = wscript.stdOut
end if

outFile.write template 

'-------------------------------------------------------------------------------
' ROUTINES
'-------------------------------------------------------------------------------
sub error(exitCode, message)
    if right(lcase(wscript.fullName), 11) = "wscript.exe" then
        ' wscript
        msgBox message, vbCritical, "Error"
    else
        ' cscript
        wscript.stdErr.writeLine message
    end if
    
    wscript.quit exitCode
end sub

function reFind(pattern, subject)
    dim re: set re = new regexp
    re.pattern    = pattern
    re.ignoreCase = true
    re.global     = false

    dim matches: set matches = re.execute(subject)
    if matches.count = 0 then 
        reFind = ""
    else
        reFind = matches(0).subMatches(0)
    end if
end function

function reSub(pattern, replacement, subject)
    dim re: set re = new regexp
    re.pattern    = pattern
    re.ignoreCase = true
    re.global     = false

    reSub = re.replace(subject, replacement)
end function
