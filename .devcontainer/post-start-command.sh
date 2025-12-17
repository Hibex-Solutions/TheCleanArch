# Set workspace as secure directory in Git
git config --global --add safe.directory $(pwd)

# Set automatic CRLF in Git
git config core.autocrlf true

# Update .NET workloads
sudo dotnet workload update ||:

# Restore and install solution .NET Tools
dotnet tool restore ||:
dotnet husky install ||:
dotnet restore ||:
