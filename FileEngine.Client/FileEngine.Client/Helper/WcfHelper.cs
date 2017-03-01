using System;
using System.Configuration;
using System.ServiceModel;

namespace FileEngine.Client.Helper
{
    // this class is developed for opening a channel between WCF service and client
    public class WcfHelper<T>
    {
        public static T CreateChannel()
        {
            string serviceBaseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            string address = String.Format(serviceBaseAddress, typeof(T).Name.Substring(1));

            var binding = new BasicHttpBinding();

            var channel = new ChannelFactory<T>(binding, address);

            return channel.CreateChannel();
        }
    }
}
