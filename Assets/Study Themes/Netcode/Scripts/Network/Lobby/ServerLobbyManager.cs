using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Netcode;
using TMPro;
using StudyProject.ProjectExtensions;
using Unity.Netcode.Transports.UTP;

namespace StudyProject.NetcodeLearning
{
    public class ServerLobbyManager : NetworkBehaviour
    {
        [SerializeField] private ClientLobbyManager _clientLobbyManager = default;

        [SerializeField] private ConnectedPlayersLobby _connectedPlayersLobby = default;

        [SerializeField] private TextMeshProUGUI _lobbyIdTextElement = default;

        private void Start()
        {
            SetupLobbyID();
            AddListeners();
        }

		private void OnDestroy()
		{
            RemoveListeners();
		}

		public void StartHost()
        {
            NetworkManager.Singleton.StartHost();
        }

        public void StartGame()
		{
            _clientLobbyManager.StartGameClientRpc();
		}

        [ServerRpc(RequireOwnership = false, Delivery = RpcDelivery.Reliable)]
        public void AddPlayerToLobbyServerRpc(PlayerData playerData)
        {
            Debug.Log($"Connected: Player ID: {playerData.ID}, Nickname: {playerData.Nickname}");
            _connectedPlayersLobby.AddPlayerToLobby(playerData);
        }

        [ServerRpc(RequireOwnership = false, Delivery = RpcDelivery.Reliable)]
        public void RemovePlayerToLobbyServerRpc(PlayerData playerData)
        {
            Debug.Log($"Disconnected: Player ID: {playerData.ID}, Nickname: {playerData.Nickname}");
            _connectedPlayersLobby.RemovePlayerFromLobby(playerData);
        }

        private void SetupLobbyID()
		{
            string localIp = Extensions.GetLocalIPAddress();
            string[] ipParts = Extensions.GetPartsOfIp(localIp);
            NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetComponent<UnityTransport>().ConnectionData.Address = localIp;
            _lobbyIdTextElement.text = $"Your lobby ID: {ipParts[3]}";
        }

        private void AddListeners()
		{
            NetworkManager.Singleton.OnClientDisconnectCallback += OnPlayerDisconnect;
        }

        private void RemoveListeners()
		{
            NetworkManager.Singleton.OnClientDisconnectCallback -= OnPlayerDisconnect;
        }

        private void OnPlayerDisconnect(ulong playerIndex)
		{
            _connectedPlayersLobby.RemovePlayerFromLobby(new PlayerData { ID = (int)playerIndex, Nickname = "" });
        }
    }

    public struct PlayerData : INetworkSerializable
    {
        public int ID;
        public FixedString128Bytes Nickname;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref ID);
            serializer.SerializeValue(ref Nickname);
        }
    }
}