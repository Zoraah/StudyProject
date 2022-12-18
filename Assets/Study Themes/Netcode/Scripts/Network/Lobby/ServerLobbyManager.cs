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

        private List<PlayerData> _connectedPlayers = new List<PlayerData>();

        [ServerRpc]
        public void AddPlayerToLobbyServerRpc(PlayerData playerData)
        {
            _connectedPlayers.Add(playerData);
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