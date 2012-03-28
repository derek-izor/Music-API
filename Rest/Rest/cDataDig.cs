using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Xml;


using MyLIB;

namespace Rest
{
    class cDataDig
    {

        public static string Get_URI()
        {

            MyLIB.Class1.Instructions();
            System.Console.WriteLine(MyLIB.Class1.Instructions());
            Console.ReadLine(); 


            Console.Write("Enter artist name: ");
            string name = (Console.ReadLine());

            Console.Write("Enter song name: ");
            string song = (Console.ReadLine());

            
            string uri2 = "http://api.chartlyrics.com/apiv1.asmx/SearchLyric?artist="+name+"&song="+song+"";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri2);

            HttpWebResponse response = (HttpWebResponse)req.GetResponse(); //This does not exit cleanly if bad request.
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            string responseString = reader.ReadToEnd();

            reader.Close();
            responseStream.Close();
            response.Close();

            return responseString;

        }

        public static String songGrabber(String xmlString)
        {
            string output;

            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                reader.ReadToFollowing("SearchLyricResult");
                reader.ReadToFollowing("Song");

                output = reader.ReadElementString();
            }
            return output;

        }

        public static String artistGrabber(String xmlString)
        {
            string output;

            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                reader.ReadToFollowing("SearchLyricResult");
                reader.ReadToFollowing("Artist");

                output = reader.ReadElementString();
            }
            return output;

        }

        public static String SURLGrabber(String xmlString)
        {
            string output;

            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                reader.ReadToFollowing("SearchLyricResult");
                reader.ReadToFollowing("SongUrl");

                output = reader.ReadElementString();
            }
            return output;

        }

        public static String AURLGrabber(String xmlString)
        {
            string output;

            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                reader.ReadToFollowing("SearchLyricResult");
                reader.ReadToFollowing("ArtistUrl");

                output = reader.ReadElementString();
            }
            return output;

        }



    }
}
