Import-Module WebAdministration
Stop-WebSite 'Offline'
Start-WebSite 'Default'

Write-Host "Website has been switched on!"