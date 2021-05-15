using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MailSender.lib.Service
{
    public static class XMLSerializerPool
    {
        private static readonly ConcurrentDictionary<Type, XmlSerializer> _SerializerPool = new ConcurrentDictionary<Type, XmlSerializer>();

        public static XmlSerializer GetSerializer<T>() => GetSerializer(typeof(T));

        public static XmlSerializer GetSerializer(Type ObjectType) =>
            _SerializerPool.GetOrAdd(ObjectType, type => new XmlSerializer(type));
    }
}
