$pass = Read-Host 'Are you sure? (Y/N)'
if ($pass.CompareTo("Y") -ne 0)
{
    Write-Host "Exiting without switching off the website!"
    Exit
}

Import-Module WebAdministration
Stop-WebSite 'Default'
Start-WebSite 'Offline'

Write-Host "Website has been switched off!"