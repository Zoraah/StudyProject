using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Netcode;

namespace StudyProject.NetcodeLearning
{
    public class ServerLobbyManager : NetworkBehaviour
    {
        [SerializeField] private ConnectedPlayersLobby _connectedPlayersLobby = default;

        [ServerRpc(RequireOwnership = false, Delivery = RpcDelivery.Reliable)]
        public void AddPlayerToLobbyServerRpc(PlayerData playerData)
        {
            Debug.Log($"Player ID: {playerData.ID}, nickname: {playerData.Nickname}");
            _connectedPlayersLobby.AddPlayerToLobby(playerData);
        }

        [ServerRpc(RequireOwnership = false, Delivery = RpcDelivery.Reliable)]
        public void RemovePlayerToLobbyServerRpc(PlayerData playerData)
        {
            Debug.Log($"Player ID: {playerData.ID}, nickname: {playerData.Nickname}");
            _connectedPlayersLobby.RemovePlayerFromLobby(playerData);
        }

        public void SetPlayersLobbyComponent()
		{

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