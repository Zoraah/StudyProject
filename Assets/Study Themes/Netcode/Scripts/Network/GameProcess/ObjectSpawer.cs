    using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
using Zenject;

namespace StudyProject.NetcodeLearning
{
    public class ObjectSpawer : NetworkBehaviour
    {
        private NetworkVariable<int> _indentifier = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

        [SerializeField] private NetworkPlayersInformationUpdater _networkPlayersInformationUpdater = default;

        [SerializeField] private GameObject _prefabObject = default;

        [SerializeField] private TextMeshProUGUI _textElement = default;        

        private void Start()
        { 
            _networkPlayersInformationUpdater.UpdateAction += ShowValues;
        }

        private void Update()
        {
            UpdateControlling();
        }

        private void UpdateControlling()
        {
            if(IsOwner)
            {
                UpdateSpawnPosition(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                SpawnObject();
            }
            ResetIndentifierValue();
        }

        private void UpdateSpawnPosition(float xValue, float yValue)
        {
            transform.position += new Vector3(xValue, 0f, yValue) * 2 * Time.deltaTime;
        }

        private void SpawnObject()
        {
            if(Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Instantiate(_prefabObject, transform.position, Quaternion.identity);
            }
        }

        private void ShowValues()
        {
            _textElement.text = $"Ind: {_indentifier.Value.ToString()}";
        }

        private void ResetIndentifierValue()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                if(IsOwner)
                {
                    _indentifier.Value = Random.Range(0,50);
                    //ShowPlayerIndifierServerRpc((int)NetworkManager.Singleton.LocalClientId, _indentifier.Value);
                }
            }
        }


        [ServerRpc]
        private void ShowPlayerIndifierServerRpc(int playerID, int indentifier)
        {
            Debug.Log($"Player ID: {playerID}, Indifier: {indentifier}");
        }
    }
}