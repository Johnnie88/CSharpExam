namespace CsharpExam.Api.Model
{
    using CsharpExam.Api.Interfaces;

    public class ConfigurationSettings : IConfigurationSettings
    {
        public Logging Logging { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
    }
}
