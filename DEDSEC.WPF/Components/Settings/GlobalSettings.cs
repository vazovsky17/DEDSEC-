using DEDSEC.Domain.Models;
using System.IO;
using System.Xml.Serialization;

namespace DEDSEC.WPF.Components.Settings
{
    public class GlobalSettings
    {
        public Account Account { get; set; }
        public void Save(string filename)
        {
            using(StreamWriter sw = new StreamWriter(filename))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(GlobalSettings));
                xmls.Serialize(sw, this);
            }
        }

        public GlobalSettings Read(string filename)
        {
            using(StreamReader sr = new StreamReader(filename))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(GlobalSettings));
                return xmls.Deserialize(sr) as GlobalSettings;
            }
        }
    }
}
