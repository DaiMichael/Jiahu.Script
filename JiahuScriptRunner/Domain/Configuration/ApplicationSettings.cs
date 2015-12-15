using System.Configuration;

namespace JiahuScriptRunner.Domain.Configuration
{
    public class ApplicationSettings
    {
        private const string ScriptLocationTag = "script.location";
        private const string ExternalObjectUnderlyingDataLocationTag = "external.object.data.underlying";

        public ApplicationConfiguration Load()
        {
            return new ApplicationConfiguration 
                        { 
                            ScriptLocaction = ConfigurationManager.AppSettings[ScriptLocationTag], 
                            ExternalObjectUnderlyingDataLocation = ConfigurationManager.AppSettings[ExternalObjectUnderlyingDataLocationTag] 
                        };
        }

        public void Save(ApplicationConfiguration applicationConfiguration)
        {
            if (applicationConfiguration.HasChanged)
            {
                ConfigurationManager.AppSettings[ScriptLocationTag] = applicationConfiguration.ScriptLocaction;
                ConfigurationManager.AppSettings[ExternalObjectUnderlyingDataLocationTag] = applicationConfiguration.ExternalObjectUnderlyingDataLocation;
            }
        }
    }
}
