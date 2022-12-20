using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

namespace StudyProject.NetcodeLearning
{
    public class ConnectedPlayersLobby : NetworkBehaviour
    {
        [SerializeField] private List<ConnectedPlayerElement> _connectedPlayersElementList = new List<ConnectedPlayerElement>();

        [SerializeField] private ConnectedPlayerElement _connectedPlayerElementPrefab = default;
        [SerializeField] private Transform _listObject = default;
        
        public void AddPlayerToLobby(PlayerData playerData)
        {
            ConnectedPlayerElement newPlayerElement = Instantiate(_connectedPlayerElementPrefab, _listObject.transform);
            newPlayerElement.SetPlayerData(playerData);
            _connectedPlayersElementList.Add(newPlayerElement);
        }

        public void RemovePlayerFromLobby(PlayerData playerData)
        {
            for (int i = 0; i < _connectedPlayersElementList.Count; i++)
            {
                if (_connectedPlayersElementList[i].GetPlayerData().ID == playerData.ID)
                {
                    ConnectedPlayerElement playerElement = _connectedPlayersElementList[i];
                    _connectedPlayersElementList.Remove(_connectedPlayersElementList[i]);
                    Destroy(playerElement.gameObject);
                }
            }
        }
    }
}