using WebStoreMVC.Interfaces;

namespace WebStoreMVC.Services
{
    public class SystemDateTime : IDateTime
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
