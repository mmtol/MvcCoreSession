


using System.Runtime.Serialization.Formatters.Binary;

namespace MvcCoreSession.Helpers
{
    #pragma warning disable SYSLIB0011

    public class HelperBinarySession
    {
        //vamos a crear los metodos de tipo static 
        //porque para convertir no voy a utilizar nada de la clase, solo la funcionalidad

        //convertimos objeto a byte[]
        public static byte[] ObjetcToByte(Object obj)
        {
            BinaryFormatter form = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                form.Serialize(stream, obj);
                return stream.ToArray();
            }
        }

        //convertimos de byte[] a obj
        public static Object ByteToObject(byte[] data)
        {
            BinaryFormatter form = new BinaryFormatter();
            using(MemoryStream stream= new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Seek(0, SeekOrigin.Begin);
                Object obj = (Object)form.Deserialize(stream);
                return obj;
            }
        }
    }
}
