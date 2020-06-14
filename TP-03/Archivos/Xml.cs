using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Método que genera el guardado de un archivo xml
        /// </summary>
        /// <param name="archivo">string con la ruta del archivo a guardar</param>
        /// <param name="datos">T (tipo de dato generico) con la información a guardar</param>
        /// <returns>bool true si el guardado se realizó correctamente, excepcion caso contrario</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Método que realiza la lectura de un archivo xml
        /// </summary>
        /// <param name="archivo">string con la ruta del archivo a leer</param>
        /// <param name="datos">T (tipo de dato generico) con la información a leer</param>
        /// <returns>bool true si la lectura se realizó correctamente, excepcion caso contrario</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos = (T)serializer.Deserialize(reader);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
    }
}
