# VNC Client Sample

The C# VNC sample uses the [RemoteViewing](https://www.zer7.com/software/remoteviewing) nuget package.  
It is included for demonstration purposes only.  Due to its dependency on WinForms it only works on Windows and does not
support essential Features such as keyboard and mouse. 

## Prerequisites

The sample requires an Azure IoT Hub to be provisioned in your Azure Subscription.  All of them also need access to the ```iothubowner``` policy connection string.
For more information, see

- [Set up IoT Hub](https://github.com/Azure/azure-iot-sdks/blob/master/doc/setup_iothub.md) describes how to configure your Azure IoT Hub service.
- [Manage IoT Hub](https://github.com/Azure/azure-iot-sdks/blob/master/doc/manage_iot_hub.md) describes how to provision devices in your Azure IoT Hub service.

For simplicity, the default Iot Hub provider reads the connection string from the  ```_HUB_CS ``` environment variables when not provided programmatically.  

The sample also requires a Service Bus Hybrid Connection Namespace to be set up, as well as Service Bus ```RootManageSharedAccessKey``` (manage, read, and write claims)
policy connection strings.  The Service Bus Provider plug in reads its connection string from the ```_SB_CS ``` environment variable.  
For more information, see 
- [Set up a Relay](https://docs.microsoft.com/en-us/azure/service-bus-relay/relay-hybrid-connections-dotnet-get-started) describes how to set up a relay listener.

Please note: the Service Bus Hybrid Connection Namespace connection string needs to have the name of the application instance appended
as follows:

```
<sb-root-connection-string>;Entity=<application-instance-name> 
```
The application instance name will be used as the name of the hybrid connection listener. 

If you run any of the .net 4.5 or 4.6 builds of the samples, then the hybrid connection listener is automatically created for you 
with the name <application-instance-name> should it not already exist.  
If you run the dotnet core version of the samples, **and the hybrid connection does not exist**, the sample will fail to work.
In this case, either run a .net 4.5 or .net 4.6 sample first, or manually provision the hybrid connection in the Azure portal.  When
doing so, ensure that "Requires client authentication" is checked, and a "Shared Access Policy" with the name "proxy" and 
"send" and "listen" claims is added.

Also note that if you store the connection string as environment variable for the service bus provider you will only be able to run one 
instance of the sample at a time.  If you want to run several samples simultaneously, you will need to provide each sample instance with its own Service Bus Hybrid 
Connection connection string containing a unique <application-instance-name>.

## Running the sample

To run the sample, start the ```proxyd``` executable and VNC Server (included in ```api/csharp/samples/VNC/Test```
folder, then start ```RemoteViewing.Client``` WinForms App., enter the host name the VNC server runs on, and the password
of the server (e.g. ```test```), and click connect.