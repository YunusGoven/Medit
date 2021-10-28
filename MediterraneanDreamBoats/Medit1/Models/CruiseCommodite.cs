
namespace Medit1.Models
{
    public class CruiseCommodite
    {
        public int CruiseId { get; set; }
        public Cruise Cruise { get; set; }
        public int CommoditeId { get; set; }
        public Commodite Commodite { get; set; }
    }
}
