using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace StudyProject.NetcodeLearning
{
    public class NetworkInitializator : MonoBehaviour
    {
        private void Start()
        {
            AddListeners();
        }

        public void StartClient()
        {
            NetworkManager.Singleton.StartClient();
        }

        public void StartHost()
        {
            NetworkManager.Singleton.StartHost();
        }

        private void AddListeners()
        {
            NetworkManager.Singleton.OnServerStarted += OnServerStarted;
        }

        private void OnServerStarted()
        {
            Debug.Log("Server started!");
        }
    }
}