using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CSharp_Serialize
{
    class Program
    {
        static string _path = @"C:\Users\Yusifiz\Desktop\files";

        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                User user1 = new User
                {
                    Name = "Ibrahim",
                    Surname = "Abbasov",
                    Age = 40
                };
            }
            static void SerializeDat(User user)
            {
                using (FileStream fileStream = new FileStream(_path + "user1.dat", FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, user);
                }
            }

            static User DeserializeDat()
            {
                object data;
                using (FileStream fileStream = new FileStream(_path + "user1.dat", FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    data = binaryFormatter.Deserialize(fileStream);
                }
                return (User)data;
            }

            static void SerializeJson(User user)
            {
                var objectStr = JsonConvert.SerializeObject(user);
                using (FileStream fileStream = new FileStream(_path + "user2.json", FileMode.Create))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.Write(objectStr);
                    }
                }
            }

            static User DeserializeJson()
            {
                string userObjStr;
                using (FileStream fileStream = new FileStream(_path + "user2.json", FileMode.Open))
                {
                    StreamReader streamReader = new StreamReader(fileStream);
                    userObjStr = streamReader.ReadToEnd();
                }

                var user = JsonConvert.DeserializeObject<User>(userObjStr);
                return user;
            }

            static void SerializeXml(User user)
            {
                using (FileStream stream = new FileStream(_path + "user3.xml", FileMode.Create))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                    xmlSerializer.Serialize(stream, user);
                }
            }

            static User DeserializeXml()
            {
                object userObj;
                using (FileStream stream = new FileStream(_path + "user3.xml", FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                    userObj = xmlSerializer.Deserialize(stream);
                }

                return (User)userObj;
            }
        }

    }
}
