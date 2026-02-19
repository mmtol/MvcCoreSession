using Newtonsoft.Json;

namespace MvcCoreSession.Helpers
{
    public class HelperJsonSession
    {
        //vamos a almacenar datos ne session mediante el metodo GetString(), SetString()
        public static string SerializarObject<T>(T data)
        {
            //convertimos el obj a string mediante newton
            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        //recibimos un string y devolver cualquier obj
        public static T DeserializeObject<T>(string data)
        {
            //mediante newton deserializamos el obj
            T objeto = JsonConvert.DeserializeObject<T>(data);
            return objeto;
        }
    }
}
