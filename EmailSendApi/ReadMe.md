Send Mail Using Email Api
=========================
 
 * **IDE** : Microsoft Visual Studio Professional 2013

 * **Project Type** : Asp .Net Web Application

 * **Description** : This project allows to send emails using listed email api's. In case if one of the email api 
                 is failed to send email then we use another email api to send the email.

 * **Email Api Used** :

   * Sparkpost
   * MailGun
   * NodeMailer

 * **Namespaces Used Within Project** :

   * RestSharp
   * Newtonsoft
   * System.Net.Http

* **Folders Used Within Project** :

   * css : Used for placing style sheet file
   * fonts : Used for placing fonts used within project
   * images : Used for placing images used within project
   * js : Used for placing javscript file  
   * Model : Files related to webservice calls 
   * View : Presentation Files



*  **The manual deployment options and configuration process are described below.**

1. Create a Deployment Folder

   * This option uses the Visual Studio .NET Web Deployment Project add-in to create a separate folder that can be copied to your deployment server.  To use this option, you must download and install the Visual Studio .NET Web Deployment Projects available at:

  [Link] (http://www.microsoft.com/downloads/details.aspx?familyId=0AA30AE8-C73B-4BDD-BB1B-FE697256C459&displaylang=en)

                    In this option, a single pre-compiled DLL is created for your application.  Only the ASPX, ASCX, RESX and DLL files need to be copied to your deployment server.  To make it easy for you, this option creates a separate folder containing all of the relevant files and this folder can be copied in its entirety to the deployment server.

                    Step 1:  Create a deployment project via the Application Deployment Wizard (Deploy, Deployment Wizard…)

                    Step 2:  Copy the deployment folder containing the pre-compiled application to your deployment server.

                    In addition to creating a separate deployment folder, you can also create an MSI installer to run on the deployment system.  While the deployment project can be created without installing Visual Studio .NET 2005 on your system, MSI generation requires Visual Studio .NET on your system.

                    See Deploying Applications with the Deployment Wizard for details.

                    Step 3:  Configure your application to run in your production environment.  See Configuring your application to run on your production machine for details.

2. Compile your application into DLLs

                    Use the aspnet_compiler to compile your .NET Framework 2.0 / 3.0 application into one or more DLLs.  All of the application’s DLLs are placed in the Bin folder of the application.

                    Step 1:  Run the DOS command line prompt.

                    Step 2:  Go to the .NET Framework 2.0 directory, e.g.:

                    cd  C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727

                    Step 3:  Run the following command:

                    aspnet_compiler.exe -p “application directory path”  -v /  “output directory path”

                    Example: aspnet_compiler.exe -p “C:\MyApp1”  -v /  “C:\MyApp1_deploy”

                    Step 4: Copy the output folder containing the pre-compiled application to your deployment server.

                    Step 5:  Configure your application to run in your production environment.  See Configuring your application to run on your production machine for details.

3. XCOPY your application folder to the production server

                    While this is the easiest option among the deployment options, the downside is that all source files must be copied to the deployment server.  This option might be considered during testing.

                    Step 1:  Copy your entire application folder containing the application to the deployment server.  Make sure that the server has .NET Framework 2.0 or later installer.  There is no requirement to create a DLL for the application since .NET Framework 2.0 will compile the application at run-time.  All source files must be copied.

                    Step 2:  Configure your application to run in your production environment.  See Configuring your application to run on your production machine for details.

4. Publish your application using Microsoft Visual Studio .NET

                    (Requires Microsoft Visual Studio .NET).  Use the ‘publish website’ option in Visual Studio .NET to publish your application to a web address or a network drive.  The advantage of this option is that you can publish to a web address that you have permissions to in one quick step.  You need to have Visual Studio .NET installed on your system to use this option.

                    Step 1:  Open the Visual Studio .NET website.

                    Step 2:  Go to the Build menu.

                    Step 3:  Select the Publish Web Site option.

                    Step 4:  Enter the target location which maybe be an FTP address, http address or a folder location.  Click OK to create the deployment project at the target location specified.

                    Step 5:  Configure your application to run in your production environment.  See Configuring your application to run on your production machine for details.

                    Configuring your application to run on your production machine

* **After copying or installing your application on your production machine, you must configure your application to run in your production environment.**

                    Step 1:  Update your application’s database connection strings for your production environment.  See Changing Database Connection Settings for details.

                    Step 2:  (Optional.)  If Iron Speed Designer created stored procedures for your application, install them in your production database.  See LoadStoredProcedures.bat for details.

                    Step 3:  Create a virtual directory for your application on your production machine.  See Creating a Virtual Directory for Your Application for details.

                    Step 4:  Add your deployed application to the registry on your production machine.  See Adding Your Application to the Windows Registry for details.

                    Step 5:  Start the session state service on your production machine.  See Starting Your Session State Service for details.

 *  **Other Usefull Links for Deployment Of Asp .Net Web Application** :
  
  [Link1] (https://msdn.microsoft.com/en-us/library/dd394698%28VS.100%29.aspx)

  [Link2] (https://www.tutorialspoint.com/asp.net/asp.net_deployment.htm)                

