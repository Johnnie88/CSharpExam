namespace CsharpExam.Api.Model
{
    using CsharpExam.Api.Interfaces;

    public class ConfigurationSettings : IConfigurationSettings
    {
        /// <summary>
        /// Gets or sets the default connection.
        /// </summary>
        public string DefaultConnection { get; set; }

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        public string Default { get; set; }

        /// <summary>
        /// Gets or sets the microsoft asp net core.
        /// </summary>
        public string MicrosoftAspNetCore { get; set; }
    }
}
