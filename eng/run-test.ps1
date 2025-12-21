for($count = 0; $count -lt $args.length; $count++) {
    $value = $args[$count]
    if("$value".contains(" ")) {
        $value = "$value".replace("`"", "```"")
        $value = "`"$value`""
    }
    $args[$count] = $value
}

$SCRIPT_PWD = Split-Path $MyInvocation.MyCommand.Path -Parent
$SOLUTION_FILE = Join-Path $SCRIPT_PWD "../TheCleanArch.slnx" | Resolve-Path
$TEST_DIR = Join-Path $SCRIPT_PWD "../test" | Resolve-Path

"Removendo resultados de testes anteriores..." | Write-Output
Get-ChildItem -Directory $TEST_DIR -Name | ForEach-Object {
    $TEST_PROJECT_PATH = Join-Path $TEST_DIR "${_}/TestResults"
    "- ${TEST_PROJECT_PATH}" | Write-Output
    
    if (Test-Path -Path $TEST_PROJECT_PATH) {
        Remove-Item -Path $TEST_PROJECT_PATH -Recurse
    }
}

"EXEC: dotnet test $SOLUTION_FILE..." | Write-Output
iex "& dotnet test  $SOLUTION_FILE $args"
