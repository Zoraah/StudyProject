using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

namespace StudyProject.NetcodeLearning
{
    public class ConnectedPlayerElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textElement = default;
        
        private PlayerData _playerData;

        public void SetPlayerData(PlayerData newPlayerData)
        {
            _playerData = newPlayerData;

            _textElement.text = _playerData.Nickname.ToString();
        }

        public PlayerData GetPlayerData()
        {
            return _playerData;
        }
    }
}