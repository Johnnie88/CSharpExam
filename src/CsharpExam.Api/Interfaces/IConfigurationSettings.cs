namespace CsharpExam.Api.Interfaces
{
    public interface IConfigurationSettings
    {
        public string DefaultConnection { get; set; }

        public string Default { get; set; }

        public string MicrosoftAspNetCore { get; set; }
    }
}