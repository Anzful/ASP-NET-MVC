# Run this script to start both the API and the Web frontend
# Make sure you have the .NET SDK installed

# Kill any existing dotnet processes to release file locks
Write-Host "Stopping any running dotnet processes..." -ForegroundColor Yellow
Stop-Process -Name dotnet -ErrorAction SilentlyContinue
Start-Sleep -Seconds 1

Write-Host "Starting OnlineStore.Api..." -ForegroundColor Cyan
Start-Process dotnet "run --project OnlineStore.Api/OnlineStore.Api.csproj --launch-profile https" -NoNewWindow

Write-Host "Starting OnlineStore.Web..." -ForegroundColor Cyan
Start-Process dotnet "run --project OnlineStore.Web/OnlineStore.Web.csproj --launch-profile https" -NoNewWindow

Write-Host "Both projects should be running soon." -ForegroundColor Green
Write-Host "Web Frontend: https://localhost:7179" -ForegroundColor Yellow
Write-Host "API: https://localhost:7202" -ForegroundColor Yellow
