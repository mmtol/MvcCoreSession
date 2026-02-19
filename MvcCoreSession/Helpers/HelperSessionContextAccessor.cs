using MvcCoreSession.Extensions;
using MvcCoreSession.Models;

namespace MvcCoreSession.Helpers
{
    public class HelperSessionContextAccessor
    {
        private IHttpContextAccessor accessor;

        public HelperSessionContextAccessor(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public List<Mascota> GetMascotasSession()
        {
            List<Mascota> mascotas = accessor.HttpContext.Session.GetObject<List<Mascota>>("MascotasGeneric");
            return mascotas;
        }
    }
}
