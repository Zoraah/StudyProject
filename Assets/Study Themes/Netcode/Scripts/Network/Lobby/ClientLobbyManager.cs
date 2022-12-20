using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using StudyProject.ProjectExtensions;
using System.Threading;
using TMPro;
using Unity.Netcode.Transports.UTP;
using UnityEngine.UI;

namespace StudyProject.NetcodeLearning
{
    public class ClientLobbyManager : NetworkBehaviour
    {
        [SerializeField] private ServerLobbyManager _serverLobbyManager = default;

        [SerializeField] private TMP_InputField _idInputField = default;

        [SerializeField] private TextMeshProUGUI _connectionStatus = default;

        [SerializeField] private Button _connectButton = default;
        [SerializeField] private Button _disonnectButton = default;

        private const string WRONT_INPUT_VALUE = "Check your input value";
        private const string CONNECTION_SUCCESSFUL = "You successfully connected to lobby. Wait until lobby master start game";
        private const string CONNECTION_FAILED = "Connection failed. Check yor network connection or entered lobby ID";

        private void OnApplicationQuit()
        {
            if (NetworkManager.Singleton != null)
            {
                DisconnectFromLobby();
            }
        }

        [ClientRpc]
        public void StartGameClientRpc()
        {
            SceneManager.LoadScene(ScenesList.GameScene);
        }

        public void ConnectToLobby()
		{
            if (_idInputField.text != string.Empty && TextHaveOnDigits(_idInputField.text))
            {
                _connectButton.interactable = false;
                _idInputField.interactable = true;
                string connectionIpAddress = SetCustomIpAddress(Extensions.GetPartsOfIp(Extensions.GetLocalIPAddress()), _idInputField.text);
                NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetComponent<UnityTransport>().ConnectionData.Address = connectionIpAddress;
                StartCoroutine(TryConnectToServer());
            }
            else
			{
                _connectionStatus.text = WRONT_INPUT_VALUE;
			}
		}

        public void DisconnectFromLobby()
		{
            RemovePlayerFromLobby();
            _connectButton.interactable = true;
            _idInputField.interactable = true;
            _disonnectButton.interactable = false;
		}
        
        private IEnumerator TryConnectToServer()
		{
            NetworkManager.Singleton.StartClient();

            yield return new WaitForSeconds(4f);

            if(NetworkManager.Singleton.IsApproved)
			{
                OnConnectSuccesful();
			}
            else
			{
                OnConnectFailed();
			}
		}

        private void OnConnectSuccesful()
		{
            _connectionStatus.text = CONNECTION_SUCCESSFUL;
            _disonnectButton.interactable = true;
            _idInputField.interactable = false;
            AddPlayerToLobby();
        }

        private void OnConnectFailed()
		{
            _connectButton.interactable = true;
            _idInputField.interactable = true;
            _connectionStatus.text = CONNECTION_FAILED;
		}

        public void RemovePlayerFromLobby()
        {
            _serverLobbyManager.RemovePlayerToLobbyServerRpc(GetSelfPlayerData());
            NetworkManager.Singleton.Shutdown();
        }

        private void AddPlayerToLobby()
        {
            PlayerData playerData = GetSelfPlayerData();

            _serverLobbyManager.AddPlayerToLobbyServerRpc(playerData);
        }

        private PlayerData GetSelfPlayerData()
        {
            return new PlayerData { ID = (int)NetworkManager.Singleton.LocalClientId, Nickname = PlayerPrefs.GetString(PlayerPrefsKeys.NAME_KEY) };
        }

        private string SetCustomIpAddress(string[] ipParts,string lastIpValue)
		{
            return ipParts[0] + '.' + ipParts[1] + '.' + ipParts[2] + '.' + _idInputField.text;
        }

        private bool TextHaveOnDigits(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}