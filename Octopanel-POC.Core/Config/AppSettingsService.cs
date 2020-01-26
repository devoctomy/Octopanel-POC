using System;

namespace Octopanel_POC.Core.Config
{
    public class AppSettingsService : IAppSettingsService
    {
        public string ServerType 
        { 
            get
            {
                return GetEnvironmentVariable("OCTOPANEL_SERVERTYPE");
            }
        }

        public string ServerUrl
        {
            get
            {
                return GetEnvironmentVariable("OCTOPANEL_SERVERURL");
            }
        }
        public string ServerApiKey
        {
            get
            {
                return GetEnvironmentVariable("OCTOPANEL_SERVERAPIKEY");
            }
        }

        public string ServerClientCert
        {
            get
            {
                return GetEnvironmentVariable("OCTOPANEL_SERVERCLIENTCERT");
            }
        }

        public string ServerClientCertPassword
        {
            get
            {
                return GetEnvironmentVariable("OCTOPANEL_SERVERCLIENTCERTPASSWORD");
            }
        }

        private string GetEnvironmentVariable(string variable)
        {
            var machineValue = Environment.GetEnvironmentVariable(
                variable,
                EnvironmentVariableTarget.Machine);
            var userValue = Environment.GetEnvironmentVariable(
                variable,
                EnvironmentVariableTarget.User);
            return userValue ?? machineValue;
        }
    }
}
