'-------------------------------------------------------------------------------
' This script packs up all files in the given release directory, and moves them
' to a different location, with the version name attached.
'
' Arguments;
' 1. Path to AssemblyInfo.cs (required)
' 2. Build directory (required)
' 3. Root for release directory (required)
' 4. Configuration name (optional)
'
' If the configuration name is present, the script will only execute if it
' is "Release" (so collecting doesn't happen for debug builds).
'
' Example pre-build script (all on one line):
'
'   $(SolutionDir)\buildtools\make-release-dir.vbs
'     $(ProjectDir)\Properties\AssemblyInfo.cs $(TargetDir) $(SolutionDir)\release
'     $(ConfigurationName)
'-------------------------------------------------------------------------------
option explicit

dim fso: set fso = createObject("Scripting.FileSystemObject")

if wscript.arguments.count < 3 then error 1, "Usage: make-release-dir.vbs ASSEMBLYINFO BUILDDIR RELEASEROOT" & vbCrlf & vbCrlf & "See comments inside script for details."

dim infoFile: infoFile = wscript.arguments(0)
dim buildDir: buildDir = wscript.arguments(1)
dim releaseDir: releaseDir = wscript.arguments(2)
dim config: if wscript.arguments.count >= 4 then config = wscript.arguments(3)

if config <> "" and left(lcase(config), 7) <> "release" then wscript.quit 0

dim assemblyInfo: assemblyInfo = fso.OpenTextFile(infoFile).readAll
dim majVersion: majVersion = reFind("AssemblyVersion\(""(\d+\.\d+)\.", assemblyInfo)
dim revision  : revision   = reFind("AssemblyVersion\(""\d+\.\d+\.(\d+)\.", assemblyInfo)
dim build     : build      = reFind("AssemblyVersion\(""\d+\.\d+\.\d+\.(\d+)""\)", assemblyInfo)
dim asmName   : asmName    = reFind("AssemblyTitle\(""([^""]+)""\)", assemblyInfo)

if majVersion = "" then error 3, "Version information not found in " & infoFile
if asmName    = "" then error 4, "Assembly name not found in " & infoFile

dim version: version = majVersion
if revision <> 0 then version = version & "." & revision
if build <> 0 then version = version & "." & build

dim targetDirName: targetDirName = asmName & "-" & version
dim targetDir: targetDir = fso.buildPath(releaseDir, targetDirName)

if right(buildDir, 1) = "/" or right(buildDir, 1) = "\" then buildDir = left(buildDir, len(buildDir) - 1)

fso.copyFolder buildDir, targetDir, true
' And clean a bit, it's a release build after all
fso.deleteFile fso.buildPath(targetDir, "*.pdb"), true

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
