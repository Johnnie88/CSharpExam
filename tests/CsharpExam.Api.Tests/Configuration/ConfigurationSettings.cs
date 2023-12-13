namespace CsharpExam.Api.UnitTests.Configuration
{
    using CsharpExam.Api.Interfaces;

    public class ConfigurationSettings
    {
        private IConfigurationSettings _configurationSettings;

        public ConfigurationSettings(IConfigurationSettings configurationSettings) => _configurationSettings = configurationSettings;

        /// <summary>
        /// Sets the configuration settings.
        /// </summary>
        /// <param name="configurationSettings"></param>
        public void SetConfigurationSettings(IConfigurationSettings configurationSettings)
        {
            _configurationSettings = configurationSettings;
        }

        /// <summary>
        /// Gets the configuration settings.
        /// </summary>
        /// <returns></returns>
        public IConfigurationSettings GetConfigurationSettings()
        {
            return _configurationSettings;
        }
    }
}
