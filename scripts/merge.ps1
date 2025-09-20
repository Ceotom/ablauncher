param (
    [string]$Configuration = ""
)

if ($Configuration -eq "Release") {
    & ilrepack /out:out\ablauncher.exe /verbose ablauncher.exe Newtonsoft.Json.dll
    
    Copy-Item -Force LICENSE out\LICENSE
    Copy-Item -Force ru\ablauncher.resources.dll out\ru\ablauncher.resources.dll
}