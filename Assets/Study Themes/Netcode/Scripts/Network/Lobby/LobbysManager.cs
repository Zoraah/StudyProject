using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace StudyProject.NetcodeLearning
{
	public class LobbysManager : NetworkBehaviour
	{
		[SerializeField] private ServerLobbyManager _serverLobbyManager = default;
		[SerializeField] private ClientLobbyManager _clientLobbyManager = default;

		public void StartClient()
		{
			NetworkManager.Singleton.StartClient();
		}

		public void StartGameForLobby()
		{
			_clientLobbyManager.StartGameClientRpc();
		}

		private ServerLobbyManager GetServerLobbyManager()
		{
			foreach (var spawnedObject in NetworkManager.Singleton.SpawnManager.SpawnedObjectsList)
			{
				if (spawnedObject.GetComponent<ServerLobbyManager>() != null)
				{
					return spawnedObject.GetComponent<ServerLobbyManager>();
				}
			}

			return null;
		}
	}
}