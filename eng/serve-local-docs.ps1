$SCRIPT_PWD = Split-Path $MyInvocation.MyCommand.Path -Parent
$DOCFX_PATH = Join-Path $SCRIPT_PWD "../docs/docfx.json" | Resolve-Path
$DOCFX_SITE_PATH = Join-Path $SCRIPT_PWD "../docs/_site" | Resolve-Path
$DOCFX_API_PATH = Join-Path $SCRIPT_PWD "../docs/api" | Resolve-Path

"Removendo arquivos estáticos de documentação anterior..."
Remove-Item -Path $DOCFX_SITE_PATH -Recurse
Remove-Item -Path $DOCFX_API_PATH -Recurse

"EXEC: dotnet docfx $DOCFX_PATH --serve" | Write-Output
dotnet docfx $DOCFX_PATH --serve
