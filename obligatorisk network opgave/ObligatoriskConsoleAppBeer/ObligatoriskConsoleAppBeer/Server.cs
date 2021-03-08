using Newtonsoft.Json;
using obligatorisk_opgave_beer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ObligatoriskConsoleAppBeer
{
    class Server
    {
        public static void Start()
        {
            TcpListener Beerserver = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 4646;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                Beerserver = new TcpListener(localAddr, port);

                Beerserver.Start();
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");

                    TcpClient client = Beerserver.AcceptTcpClient();
                    Console.WriteLine("Connected!");



                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    Stream ns = client.GetStream();

                    StreamReader sr = new StreamReader(ns);
                    StreamWriter sw = new StreamWriter(ns);
                    sw.AutoFlush = true;

                    string message = sr.ReadLine();
                    

                    Console.WriteLine(value: "Client: " + message);

                    if (message.Equals("Getall"))
                    {
                        sw.WriteLine("Getall");
                        sw.WriteLine(JsonConvert.SerializeObject(Beers).ToString());
                    }
                    else if (message.Equals("Getbyid"))
                    {
                        sw.WriteLine("Getbyid");
                        sw.WriteLine("Write you Prefered ID");
                        String lineid = sr.ReadLine();
                        int number = Int32.Parse(lineid);
                        sw.WriteLine(JsonConvert.SerializeObject(Beers.Find(Beers => Beers.ID==number)));
                    }
                    else if (message.Equals("Save"))
                    {
                        sw.WriteLine("Save");
                        sw.WriteLine("Write a new Beer");

                        string Beer = sr.ReadLine();

                        Beers.Add(JsonConvert.DeserializeObject<Beer>(Beer));
                    }
                    

                    else
                    {
                        sw.WriteLine("Function not recognized");
                    }
                    
                    client.Close();
                    Console.WriteLine("it has stopped");


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private static readonly List<Beer> Beers = new List<Beer>()
            {
            new Beer {ID = 1, Name = "Hallerstern", Price = 200, ABV = 45 },
            new Beer {ID = 2, Name = "Serenity", Price = 400, ABV = 75 },
            new Beer {ID = 3, Name = "Killme", Price = 500, ABV = 90}
            };

        }
    }


