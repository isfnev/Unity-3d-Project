# Merge contents of multiple text/code files into one output file
# Usage: .\merge-files.ps1 *.txt
# Or:   .\merge-files.ps1 *.cs

param(
    [string]$pattern = "*.*",       # File pattern (e.g. *.cs, *.txt, *.json)
    [string]$outputFile = "merged_output.txt"
)

# Clear old output if exists
if (Test-Path $outputFile) { Remove-Item $outputFile }

# Loop through matching files
Get-ChildItem -Path . -Filter $pattern | ForEach-Object {
    Add-Content $outputFile "===== START OF FILE: $($_.Name) ====="
    Get-Content $_ | Add-Content $outputFile
    Add-Content $outputFile "`n===== END OF FILE: $($_.Name) =====`n"
}

Write-Output "✅ All files merged into $outputFile"
