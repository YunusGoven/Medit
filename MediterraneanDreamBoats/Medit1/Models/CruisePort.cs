

namespace Medit1.Models
{
    public class CruisePort
    {
        public int CruiseId { get; set; }
        public Cruise Cruise { get; set; }
        public int PortId { get; set; }
        public Port Port { get; set; }
    }
}
