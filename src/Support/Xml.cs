using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace DesktopManager
{
    public static class XmlProfile
    {
        public static void Save(StreamWriter writer, Profile profile)
        {
            var xmlSerializer = new XmlSerializer(typeof(Profile));
            xmlSerializer.Serialize(writer, profile);      
        }

        public static Profile Read(StreamReader reader)
        {
            var xmlSerializer = new XmlSerializer(typeof(Profile));
            return (Profile)xmlSerializer.Deserialize(reader);
        }
    }

    public static class XmlUserSettings
    {
        public static void Save(StreamWriter writer, UserSettings settings)
        {
            var xmlSerializer = new XmlSerializer(typeof(UserSettings));
            xmlSerializer.Serialize(writer, settings);
        }

        public static UserSettings Read(StreamReader reader)
        {
            var xmlSerializer = new XmlSerializer(typeof(UserSettings));
            return (UserSettings)xmlSerializer.Deserialize(reader);
        }
    }
}
