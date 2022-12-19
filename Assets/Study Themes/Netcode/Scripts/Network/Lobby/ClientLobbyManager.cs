using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

namespace StudyProject.NetcodeLearning
{
    public class ClientLobbyManager : NetworkBehaviour
    {
        [ClientRpc]
        public void ChangeSceneForPlayersClientRpc()
        {
            SceneManager.LoadScene("WaitRoom");
        }
    }
}