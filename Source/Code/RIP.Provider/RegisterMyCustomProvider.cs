﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using kCura.IntegrationPoints.SourceProviderInstaller;

namespace RIP.Provider
{
    [kCura.EventHandler.CustomAttributes.Description("My Custom Provider - Installer")]
    [kCura.EventHandler.CustomAttributes.RunOnce(false)]
    [Guid("DF4DBC03-D20F-4CE1-9C26-35B6F0C94AC8")]
    public class RegisterMyCustomProvider : kCura.IntegrationPoints.SourceProviderInstaller.IntegrationPointSourceProviderInstaller
    {
        public RegisterMyCustomProvider()
        {
            RaisePostInstallPreExecuteEvent += PreInstall;
            RaisePostInstallPostExecuteEvent += PostInstall;
        }

        public override IDictionary<Guid, SourceProvider> GetSourceProviders()
        {
            var sourceProviders = new Dictionary<Guid, kCura.IntegrationPoints.SourceProviderInstaller.SourceProvider>();

            // Register the name, custom page location and configuration location of your provider
            var myCustomProvider = new kCura.IntegrationPoints.SourceProviderInstaller.SourceProvider()
            {
                Name = "My Custom Provider",
                Url = $"/%applicationpath%/CustomPages/{Constants.Guids.Application.SMP_RELATIVITY_APPLICATION}/MyCustomProvider/Index/",
                ViewDataUrl = $"/%applicationpath%/CustomPages/{Constants.Guids.Application.SMP_RELATIVITY_APPLICATION}/MyCustomProvider/GetViewFields/"
            };

            sourceProviders.Add(new Guid(Constants.Guids.Provider.MY_CUSTOM_PROVIDER), myCustomProvider);

            return sourceProviders;
        }

        public void PreInstall()
        {
            // Execute a command before your provider is installed
            //this.Helper.GetDBContext(Helper.GetActiveCaseID()).ExecuteNonQuerySQLStatement("CREATE TABLE [EDDSDBO].MyScratchTableForMyCustomProvider ([ID] INT)");
            //this.Helper.GetDBContext(Helper.GetActiveCaseID()).ExecuteNonQuerySQLStatement("CREATE TABLE [EDDSDBO].MyJobTableForMyCustomProvider ([ID] INT)");
        }

        public void PostInstall(Boolean isUninstalled, Exception ex)
        {
            // Execute a command after your provider is installed
            //this.Helper.GetDBContext(Helper.GetActiveCaseID()).ExecuteNonQuerySQLStatement("INSERT INTO [EDDSDBO].MyScratchTableForMyCustomProvider(ID)VALUES(1)");
        }
    }
}
