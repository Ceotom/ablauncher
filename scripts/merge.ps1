param (
    [string]$Configuration = ""
)

if ($Configuration -eq "Release") {
    & ilrepack /out:out\ablauncher.exe /verbose ablauncher.exe Newtonsoft.Json.dll ru\ablauncher.resources.dll
    
    Copy-Item -Force LICENSE out\LICENSE
}