# Set workspace as secure directory in Git
git config --global --add safe.directory $(pwd)

# Set automatic CRLF in Git
git config core.autocrlf true

# Restore .NET Tools
dotnet tool restore

# Install Git Hooks Husky
dotnet husky install

# Restore .NET Dependencies
dotnet restore ||: