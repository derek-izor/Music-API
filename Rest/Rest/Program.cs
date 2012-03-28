using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Xml;

namespace Rest
{
    class Program
    {
    

        static void Main(string[] args)
        {


            string xmlResult = cDataDig.Get_URI();
            string artistResult = cDataDig.artistGrabber(xmlResult);
            string songResult = cDataDig.songGrabber(xmlResult);
            string SURLResult = cDataDig.SURLGrabber(xmlResult);
            string AURLResult = cDataDig.AURLGrabber(xmlResult);


            Console.WriteLine("Artist Name: " + artistResult);
            Console.WriteLine("Song Name: " + songResult);
            Console.WriteLine("Song Lyrics: " + SURLResult);
            Console.WriteLine("Artist Discography: " + AURLResult);
           

            System.Threading.Thread.Sleep(10000000);
           
        }
    }
}
