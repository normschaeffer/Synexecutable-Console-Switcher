![](https://github.com/normschaeffer/console-switcher/blob/master/Images/ENKADIA-Synexsis-2x1.png)

## Enkadia Synexecutable Console Switcher
Demonstration of **Enkadia Synexecutables**

*Synexecutables provide a/v control from console or command line applications. Synexecutables can be added to the task scheduler, run in the background or sit on the taskbar.*

### Devices and software used for this project
  * Windows 10 desktop computer
  * Extron 8x8 DXP matrix switcher
  * Netgear 5 port 10/100 switch

### Synexsis NuGet packages used - Available at the NuGet Repository (search for Enkadia)
  * Enkadia.Synexsis.Components.Switchers
  * Enkadia.Synexsis.ComponentFramework
  
### Additional Microsoft NuGet packages used
  * Microsoft.Extensions.DependencyInjection;
  
### Windows Target environments
   * Minimum Windows 10, version 1803
   * Maximum Windows 10, version 1903
   

### Configuring your components
Synexsis builds your components by reading values from an `appsettings.json` file, located at the root of your program's runtime directory.

```text
Place the appsettings.json file in this folder.
(This example file path is for a release version running on Windows desktop)

   console-switcher\bin\Release\netcoreapp3.0\

```

#### Troubleshooting
If the application fails to start, verify the license and appsettings.json files are in the correct folder.


### Creating the appsettings.json file

#### Sample appsettings.json
```json
{
  "Swt": {
    "IPAddress": "192.168.1.50",
    "Username":"admin",
    "Password":"password"
  }
}
```
