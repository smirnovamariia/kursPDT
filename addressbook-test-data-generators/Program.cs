using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using addressbook_web_tests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            string dataType = args[3];


                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }

                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(20))
                    {
                        Address = TestBase.GenerateRandomString(20),
                        Mobile = TestBase.GenerateRandomString(5), 
                        Email = TestBase.GenerateRandomString(10)
                    });
                }
     
            if (format == "excel" && dataType == "group")
            {
                writeGroupsToExcelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv" && dataType == "group") 
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml" && dataType == "group")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "xml" && dataType == "contact")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json" && dataType == "group")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else if (format == "json" && dataType == "contact")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format or dataType: \n format=" + format + ", dataType=" + dataType);
                }

                writer.Close();
            }
           
        }

        private static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        private static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
           
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer )
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
