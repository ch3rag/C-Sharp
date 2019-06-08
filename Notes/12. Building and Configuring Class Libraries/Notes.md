### Default Namespace of Visual Studio

By default, when you create a new C# project using Visual Studio, the name of your application’s default namespace will be identical to the project name. From this point on, when you insert new code files using the Project ➤ Add New Item menu selection, types will automatically be wrapped within the default namespace. If you want to change the name of the default namespace, simply access the “Default namespace” option using the Application tab of the project’s properties window.

---

### Format of a .NET Assembly
A .NET assembly (*.dll or *.exe) consists of the following elements:
* A Windows file header
* A CLR file header
* CIL code
* Type metadata
* An assembly manifest
* Optional embedded resources

#### The Windows File Header
The Windows file header establishes the fact that the assembly can be loaded and manipulated by the Windows family of operating systems. This header data also identifies the kind of application (consolebased, GUI-based, or *.dll code library) to be hosted by Windows. If you open a .NET assembly using the dumpbin.exe utility (via a Windows command prompt) and specify the /headers flag as so: 
```
dumpbin /headers MyLibrary.dll
```

#### The CLR File Header
The CLR header is a block of data that all .NET assemblies must support (and do support, courtesy of the C# compiler) to be hosted by the CLR. In a nutshell, this header defines numerous flags that enable the runtime to understand the layout of the managed file. For example, flags exist that identify the location of the metadata and resources within the file, the version of the runtime the assembly was built against, the value of the (optional) public key, and so forth. If you supply the /clrheader flag to dumpbin.exe like so:

```
dumpbin /clrheader MyLibrary.dll
```

#### CIL Code
At its core, an assembly contains CIL code, which, as you recall, is a platform- and CPU-agnostic intermediate language. At runtime, the internal CIL is compiled on the fly using a just-in-time (JIT) compiler, according to platform- and CPU-specific instructions.


#### Type Metadata
An assembly also contains metadata that completely describes the format of the contained types, as well as the format of external types referenced by this assembly. The .NET runtime uses this metadata to resolve the location of types (and their members) within the binary, lay out types in memory, and facilitate remote method invocations.

#### Assembly Manifest
An assembly must also contain an associated manifest (also referred to as assembly metadata). The manifest documents each module within the assembly, establishes the version of the assembly, and also documents any external assemblies referenced by the current assembly

---

### Building and Consuming Custom Class Library
To build a code library using Visual Studio, select the Class Library project workspace via the File ➤ New Project menu option

---

#### Modifying Assembly Information
Click the Properties icon within Solution Explorer, you can click the Assembly Information button located on the (automatically selected) Application tab. This will bring up the dialog window.

Additionaly you can edit using **AssemblyInfo.cs** in Properties folder located in Solution Explorer

---

## Private Assemblies
Private assemblies must be located within the same directory as the client application that’s using them (the application directory) or a subdirectory thereof. 

When you add a reference to *.dll while building the applications,
Visual Studio responded by placing a copy of *.dll within the client’s application directory (at least, after the first compilation).

When a client program uses the types defined within this external assembly, the CLR simply loads the local copy of *.dll. Because the .NET runtime does not consult the system registry when searching for referenced assemblies, you can relocate the Application's *.exe and *.dll assemblies to a new location on your machine and run the application (this is often termed **_Xcopy deployment_**).

### Private Assembly Probing
The .NET runtime resolves the location of a private assembly using a technique called **Probing**

A request to load an assembly may be either **implicit** or **explicit**. 
* An implicit load request occurs when the CLR consults the manifest to resolve the location of an assembly defined using the .assembly extern tokens.

```CSharp
// An implicit load request.
.assembly extern MyLibrary
{ ... }
```

* An explicit load request occurs programmatically using the Load() or LoadFrom() method of the System.Reflection.Assembly class type, typically for the purposes of late binding and dynamic invocation of type members.

```CSharp
// An explicit load request based on a friendly name.
Assembly asm = Assembly.Load("MYLibrary");
```

### Configuring Private Assemblies
It is possible to place the libraries in a subdirectory of application directory.
In order to do so we have to inform the CLR to probe into specific directory.
This information is added to *.config file and is place in the same directory where the executable is located. The *.config must have the same name as your application. For example, if your application's name is **MyApp.exe** then configuration file name must be named **MyApp.exe.config**. Probing is configured using _privatePath_ attribute of the _probing_ element.

```xml
<configuration>
    <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
            <probing privatePath="MyLibraries"/>
        </assemblyBinding>
    </runtime>
</configuration>
```

Here is an example that informs the CLR to consult the MyLibraries and MyLibraries\Tests client subdirectories:

```xml
<probing privatePath="MyLibraries;MyLibraries\Tests"/>
```

### App.Config File
By default a new Visual Studio project will contain a configuration file for editing. If you ever need to add one manually, you may do so via the Project ➤ Add New Item menu option.

Each time you compile your project, Visual Studio will automatically copy the data in App.config to a new file in the \bin\Debug directory using the proper naming convention (such as AppName.exe.config). However, this behavior will happen only if your configuration file is indeed named App.config

---
## Shared Assemblies
A shared assembly is a collection of types intended for reuse among projects. The most obvious difference between shared and private assemblies is that a single copy of a shared assembly can be used by several applications on the same machine.

### Global Assembly Cache (GAC)

A shared assembly is not deployed within the same directory as the
application that uses it. Rather, shared assemblies are installed  nto the GAC. However, the exact location of the GAC will depend on which versions of the .NET platform you installed on the target computer. Machines that have not installed .NET 4.0 or higher will find the GAC is located in a subdirectory of your Windows directory named assembly:
```
C:\Windows\assembly
```
 These days, you might consider this the “historical GAC,” as it can only contain .NET libraries compiled on versions 1.0, 2.0, 3.0, or 3.5.

With the release of .NET 4.0, Microsoft decided to isolate .NET 4.0 and higher libraries to a separate location, specifically:
```
C:\Windows\Microsoft.NET\assembly\GAC_MSIL
```

Each the subdirectory is named identically to the friendly name of a particular code library (\System.Windows.Forms, \System.Core).

Beneath a given friendly name folder, you’ll find yet another subdirectory that always takes the following naming convention:

```
v4.0_major.minor.build.revision_publicKeyTokenValue
```
The v4.0 prefix denotes that the library compiled under .NET version 4.0 or higher. That prefix is followed by a single underscore and then the version of the library in question (for example, 1.0.0.0). After a pair of underscores, you’ll see another number termed the public key token value. The public key value is part of the assembly’s **strong name**. Finally, under this folder, you will find a copy of the *.dll in question.

### Strong Names
Before you can deploy an assembly to the GAC, you must assign it a strong name, which is used to uniquely identify the publisher of a given .NET binary. 

A strong name is composed of a set of related data, much of which is specified using the following assembly-level attributes:
* The friendly name of the assembly (the name of the assembly minus the file extension)  
* The version number of the assembly (assigned using the [AssemblyVersion] attribute)
* The public key value (assigned using the [AssemblyKeyFile] attribute)
* An optional culture identity value for localization purposes (assigned using the [AssemblyCulture] attribute)
* An embedded digital signature, created using a hash of the assembly’s contents and the private key value


#### Generating Keys For Strong Names
##### Using sn.exe 
This  utility generates a file (typically ending with the *.snk [Strong Name Key] file extension) that contains data for two distinct but mathematically related keys, **the public key** and the **private key**. 
Once the C# compiler is made aware of the location of your *.snk file, it will record the full public key value in the assembly manifest using the .publickey token at the time of compilation. The C# compiler will also generate a hash code based on the contents of the entire assembly (CIL code,
metadata, and so forth).

![structure of library](https://github.com/iambharatsingh/C-Sharp/blob/master/Notes/12.%20Building%20and%20Configuring%20Class%20Libraries/img/image.PNG?raw=true)


The following command to generate a file named **MyTestKeyPair.snk**:
```bash
sn –k MyTestKeyPair.snk
```

The [AssemblyKeyFile] assembly-level attribute can be added to your AssemblyInfo.cs file to inform the compiler of the location of a valid *.snk file. Simply specify the path as a string parameter.
```CSharp
[assembly: AssemblyKeyFile(@"C:\MyTestKeyPair\MyTestKeyPair.snk")]
```
##### Generating Strong Names Using Visual Studio

To make a new *.snk file for the project, first double-click the Properties icon of the Solution Explorer and select the Signing tab. Next, select the “Sign the assembly” check box, and choose the <New…> option from the drop-down list.

---

#### Installing Strongly Named Assemblies to the GAC


To install a strongly named assembly using gacutil.exe, first open a command prompt and then change to the directory containing *.dll.

Next, install the library using the -i command, like so:
```bash
gacutil -i MyLibrary.dll
```

---
### Configuring Shared Assemblies

You can use application configuration files in conjunction with shared assemblies whenever you want to instruct the CLR to bind to a different version of a specific assembly, effectively bypassing the value recorded in the client’s manifest. 


When you want to tell the CLR to load a version of a shared assembly other than the version listed in the manifest, you can build a *.config file that contains a <dependentAssembly> element. When doing so, you will need to create an <assemblyIdentity> subelement that specifies the friendly name of the assembly listed in the client manifest and an optional culture attribute (which can be assigned an empty string or omitted altogether if you want to use the default culture for the machine). Moreover, the <dependentAssembly> element will define a <bindingRedirect> subelement to define the version currently in the manifest (via the oldVersion attribute) and the version in the GAC to load instead (via the newVersion attribute).
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <!--Runtime binding info -->
    <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
            <dependentAssembly>
                <assemblyIdentity name="MyLibrary" publicKeyToken="64ee9364749d8328"
    culture="neutral"/>
                <bindingRedirect oldVersion= "1.0.0.0" newVersion= "2.0.0.0"/>
            </dependentAssembly>
        </assemblyBinding>
    </runtime>
</configuration>
```
---
### Publisher Policy Assemblies
Publisher policy allows the publisher of a given assembly  to ship a binary version of a *.config file that is installed into the GAC along with the newest version of the associated assembly. The benefit of this approach is that client application directories do not need to contain specific *.config files. Rather, the CLR will read the current manifest and attempt to find the requested version in the GAC. However, if the CLR finds a publisher policy assembly, it will read the embedded XML data and perform the requested redirection at the level of the GAC.

Publisher policy assemblies are created at the command line using a .NET utility named **al.exe** (assembly linker).

Building a publisher policy assembly requires passing in the following input parameters:

* The location of the *.config or *.xml file containing the redirecting instructions
* The name of the resulting publisher policy assembly
* The location of the *.snk file used to sign the publisher policy assembly
* The version numbers to assign the publisher policy assembly being constructed

If you wanted to build a publisher policy assembly that controls MyLibrary.dll, the command set would be as follows:

```bash
al -link:MyLibraryPolicy.xml -out:policy.1.0.MyLibrary.dll -keyf:C:\MyKey\myKey.snk -v:1.0.0.0
```

the XML content is contained within a file named MyLibraryPolicy.xml. The name of the
output file (which must be in the format policy.<major>.<minor>.assemblyToConfigure) is specified using the obvious -out flag. In addition, note that the name of the file containing the public/private key pair will also need to be supplied via the -keyf option. Remember, publisher policy files are shared and, therefore,
must have strong names!

#### Disabling Publisher Policy
It is possible to build a configuration file for a  client that instructs the CLR to ignore the presence of any publisher policy files installed in the GAC.
```xml
<configuration>
    <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
            <publisherPolicy apply="no" />
        </assemblyBinding>
    </runtime>
</configuration>
```

---

### the codeBase Element

Application configuration files can also specify codebases. The <codeBase> element can be used to instruct the CLR to probe for dependent assemblies located at arbitrary locations (such as network endpoints or an arbitrary machine path outside a client’s application directory).

If the value assigned to a <codeBase> element is located on a remote machine, the assembly will be downloaded on demand to a specific directory in the GAC termed the **download cache**.
```xml
<configuration>
     <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
            <dependentAssembly>
                <assemblyIdentity name="CarLibrary" publicKeyToken="33A2BC294331E8B9"
culture="neutral"/>
                <codeBase version="2.0.0.0" href="file:///C:/MyAsms/CarLibrary.dll" />
            </dependentAssembly>
        </assemblyBinding>
     </runtime>
</configuration>
```

#### Versions

A .NET version number is composed of the four parts 
```xml
(<major>.<minor>.<build>.<revision>)
```
While specifying a version number is entirely up to you, you can instruct Visual Studio to automatically increment the build and revision numbers as part of each compilation using the wildcard token, rather than with a specific build and revision value.
```CSharp
// Format: <Major number>.<Minor number>.<Build number>.<Revision number>
// Valid values for each part of the version number are between 0 and 65535.
[assembly: AssemblyVersion("1.0.*")]
```
---

### System.Configuration Namespace

The System.Configuration namespace provides a small set of types you can use to read custom data from a client’s *.config file. These custom settings must be contained within the scope of an <appSettings> element. The <appSettings> element contains any number of <add> elements that define key-value pairs to be obtained programmatically.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7" />
    </startup>
    <!-- Custom App settings -->
    <appSettings>
        <add key="TextColor" value="Green" />
        <add key="RepeatCount" value="8" />
    </appSettings>
</configuration>
```

```Csharp
using System;
using System.Configuration;

namespace Test {
    public class Program {
        public static void Main(string[] args) {
            AppSettingsReader asr = new AppSettingsReader();
            int numOfTimes = (int)asr.GetValue("RepeatCount", typeof(int));
            string textColor = (string)asr.GetValue("TextColor", typeof(string));

            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), textColor);

            for (int i = 0; i < numOfTimes; i++) {
                Console.WriteLine("Hey");
            }
        }
    }
}
```

---









