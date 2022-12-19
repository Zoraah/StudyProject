using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace StudyProject.NetcodeLearning
{
	public class LobbysManager : NetworkBehaviour
	{
		[SerializeField] private ServerLobbyManager _serverLobbyManager;
		[SerializeField] private ClientLobbyManager _clientLobbyManager;

		private void Start()
		{
			AddListeners();
		}

		private void OnApplicationQuit()
		{
			DisconnectFromLobby();
		}

		public void StartClient()
		{
			NetworkManager.Singleton.StartClient();
			StartCoroutine(ConnectToLobby());
		}

		public void StartHost()
		{
			NetworkManager.Singleton.StartHost();
		}

		public void StartGameForLobby()
		{
			_clientLobbyManager.ChangeSceneForPlayersClientRpc();
		}

		public void DisconnectFromLobby()
		{
			_serverLobbyManager.RemovePlayerToLobbyServerRpc(new PlayerData { ID = (int)NetworkManager.Singleton.LocalClientId, Nickname = PlayerPrefs.GetString(PlayerPrefsKeys.NAME_KEY) });
			NetworkManager.Singleton.Shutdown();
		}

		private void AddListeners()
		{
			NetworkManager.Singleton.OnServerStarted += OnServerStarted;
		}

		private void OnServerStarted()
		{
			Debug.Log("Server started!");
		}

		private IEnumerator ConnectToLobby()
		{
			yield return new WaitUntil(() => NetworkManager.Singleton.IsConnectedClient);
			AddPlayerToLobby();
		}

		private void AddPlayerToLobby()
		{
			PlayerData playerData = new PlayerData { ID = (int)NetworkManager.Singleton.LocalClientId, Nickname = PlayerPrefs.GetString(PlayerPrefsKeys.NAME_KEY) };

			_serverLobbyManager.AddPlayerToLobbyServerRpc(playerData);
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