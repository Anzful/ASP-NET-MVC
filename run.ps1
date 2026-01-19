# Run this script to start both the API and the Web frontend
# Make sure you have the .NET SDK installed

# Kill any existing dotnet and compiler processes to release file locks
Write-Host "Stopping any running dotnet processes..." -ForegroundColor Yellow
Stop-Process -Name dotnet -ErrorAction SilentlyContinue
Stop-Process -Name VBCSCompiler -ErrorAction SilentlyContinue
Start-Sleep -Seconds 2

# Force delete the database to ensure new seed data is applied
Write-Host "Resetting database..." -ForegroundColor Yellow
Remove-Item -Path "OnlineStore.Api/OnlineStore.db" -ErrorAction SilentlyContinue
Remove-Item -Path "OnlineStore.Api/OnlineStore.db-shm" -ErrorAction SilentlyContinue
Remove-Item -Path "OnlineStore.Api/OnlineStore.db-wal" -ErrorAction SilentlyContinue

# Build the solution sequentially first to avoid race conditions on the Shared project
Write-Host "Building solution..." -ForegroundColor Cyan
dotnet build --nologo --verbosity quiet

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed. Fix errors and try again." -ForegroundColor Red
    exit
}

Write-Host "Starting OnlineStore.Api..." -ForegroundColor Cyan
Start-Process dotnet "run --project OnlineStore.Api/OnlineStore.Api.csproj --launch-profile https --no-build" -NoNewWindow

Write-Host "Starting OnlineStore.Web..." -ForegroundColor Cyan
Start-Process dotnet "run --project OnlineStore.Web/OnlineStore.Web.csproj --launch-profile https --no-build" -NoNewWindow

Write-Host "Both projects should be running soon." -ForegroundColor Green
Write-Host "Web Frontend: https://localhost:7179" -ForegroundColor Yellow
Write-Host "API: https://localhost:7202" -ForegroundColor Yellow
