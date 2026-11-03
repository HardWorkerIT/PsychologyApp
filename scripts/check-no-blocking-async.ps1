$ErrorActionPreference = 'Stop'

$repoRoot = Split-Path -Parent $PSScriptRoot
$sourceRoots = @(
    'PsychologyApp.Application',
    'PsychologyApp.Infrastructure',
    'PsychologyApp.Presentation'
)
$blockingPattern = '\.(?:Result\b|Wait\s*\(|GetAwaiter\s*\(\)\s*\.GetResult\s*\()'
$findings = [System.Collections.Generic.List[string]]::new()

foreach ($sourceRoot in $sourceRoots) {
    $absoluteRoot = Join-Path $repoRoot $sourceRoot
    Get-ChildItem -LiteralPath $absoluteRoot -Recurse -Filter '*.cs' -File |
        Where-Object { $_.FullName -notmatch '[\\/](?:bin|obj)[\\/]' } |
        ForEach-Object {
            $relativePath = [System.IO.Path]::GetRelativePath($repoRoot, $_.FullName).Replace('\', '/')
            $lineNumber = 0
            foreach ($line in [System.IO.File]::ReadLines($_.FullName)) {
                $lineNumber++
                if ($line -cnotmatch $blockingPattern) {
                    continue
                }

                # The debug-only watchdog deliberately waits on a background thread while measuring UI-dispatch latency.
                if ($relativePath -eq 'PsychologyApp.Presentation/Shared/Common/Diagnostics/PerfTrace.cs' -and
                    $line.Trim() -eq 'replied.Wait();') {
                    continue
                }

                $findings.Add("${relativePath}:${lineNumber}: $($line.Trim())")
            }
        }
}

if ($findings.Count -gt 0) {
    Write-Error ("Blocking Task.Result/Wait/GetAwaiter calls found in production code:`n" + ($findings -join "`n"))
    exit 1
}

Write-Output 'No blocking Task.Result/Wait/GetAwaiter calls found in production code (debug watchdog exception is allowlisted).'
