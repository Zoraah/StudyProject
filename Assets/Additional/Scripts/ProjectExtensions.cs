using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace StudyProject.ProjectExtensions
{
    public static class Extensions
    {
        public static void KillCoroutine(this Coroutine coroutine, MonoBehaviour monoBehaviour)
        {
            if(coroutine != null)
            {
                monoBehaviour.StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }


        public static string[] GetPartsOfIp(string ipString)
        {
            string[] ipParts = ipString.Split('.');
            return ipParts;
        }
    }
}