using System.ComponentModel;

namespace Anti2536
{
    public class Config
    {
        [Description("Whether to disable/enable SCP-2536")] 
        public bool disableScp2536 { get; set; } = true;
    }
}