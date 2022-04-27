using PTA.Repository.Interfaces.Settings;

namespace PTA.Repository.Settings
{
    public class SqlDbSettings : ISqlDbSettings
    {
        public string ConnectionString { get; set; }
    }
}
