using MvcCoreSession.Helpers;

namespace MvcCoreSession.Extensions
{
    public static class SessionExtension
    {
        //metodo para recuperar cualuier obj de session
        public static T GetObject<T>(this ISession session, string key)
        {
            //ahora mismo ya tenemos dentro de la variable session el objeto HttpContextSession
            //debemos recuperar el obj json de session
            string json = session.GetString(key);
            //en session si algo no existe, siempre devuelve null
            if (json == null)
            {
                return default(T);
            }
            else
            {
                //recuperamos el obj y lo convertimos con nuestro helper
                T data = HelperJsonSession.DeserializeObject<T>(json);
                return data;
            }
        }

        public static void SetObject(this ISession session, string key, object value)
        {
            string data = HelperJsonSession.SerializarObject(value);
            session.SetString(key, data);
        }
    }
}
