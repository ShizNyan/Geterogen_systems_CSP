using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using ClassLibrary1;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel ch = new HttpChannel(5000);
            ChannelServices.RegisterChannel(ch, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ClassLibrary1.Class1),
                "CalculationArFunction.soap",
                WellKnownObjectMode.Singleton);
            Console.WriteLine("MathFunctions service is ready...");
            Console.ReadLine();
        }
    }
}
