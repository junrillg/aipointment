# Convert all text files from CRLF to LF
# This script will convert line endings for all tracked files in the git repository

# Get all tracked files
$files = git ls-files

# Process each file
foreach ($file in $files) {
    # Skip binary files and directories
    if (Test-Path $file -PathType Leaf) {
        # Read the file content
        $content = Get-Content -Path $file -Raw
        
        # Check if content is not null or empty
        if ($content -ne $null) {
            # Replace CRLF with LF
            $newContent = $content -replace "`r`n", "`n"
            
            # Write the file back if changes were made
            if ($newContent -ne $content) {
                [System.IO.File]::WriteAllText($file, $newContent, [System.Text.Encoding]::UTF8)
                Write-Host "Converted line endings for: $file"
            }
        }
    }
}

Write-Host "Line ending conversion complete."