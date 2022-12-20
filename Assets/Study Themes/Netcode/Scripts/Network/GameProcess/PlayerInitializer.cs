using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace StudyProject.NetcodeLearning
{
    public class PlayerInitializer : NetworkBehaviour
    {
        [SerializeField] public ObjectSpawer _playerPrefab = default;

        private void Start()
        {
            if (NetworkManager.Singleton.IsServer || NetworkManager.Singleton.IsHost)
            {
                SpawnPlayersObjects();
                BlockNewConnections();
            }
        }

		private void SpawnPlayersObjects()
        {
            foreach (NetworkClient player in NetworkManager.Singleton.ConnectedClientsList)
            {
                ObjectSpawer playerObject = Instantiate(_playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                playerObject.GetComponent<NetworkObject>().SpawnWithOwnership(player.ClientId, true);
            }
        }

        private void BlockNewConnections()
		{
            NetworkManager.Singleton.NetworkConfig.ConnectionApproval = true;
            NetworkManager.Singleton.ConnectionApprovalCallback += BlockPlayer;
		}

        private void BlockPlayer(NetworkManager.ConnectionApprovalRequest connectionApprovalRequest, NetworkManager.ConnectionApprovalResponse connectionApprovalResponse)
		{
            connectionApprovalResponse.Approved = false;
		}
    }
}