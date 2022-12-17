using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace StudyProject.NetcodeLearning
{
    public class NetworkInitializator : MonoBehaviour
    {
        public void StartClient()
        {
            NetworkManager.Singleton.StartClient();

            if(NetworkManager.Singleton.IsConnectedClient)
            {
                Debug.Log("Connected as client successful");
            }
            else
            {
                Debug.Log("Connected failed");
            }
        }

        public void StartHost()
        {
            NetworkManager.Singleton.OnServerStarted += OnServerStarted;
            NetworkManager.Singleton.StartHost();
        }

        private void OnServerStarted()
        {
            Debug.Log("Server started!");
        }
    }
}