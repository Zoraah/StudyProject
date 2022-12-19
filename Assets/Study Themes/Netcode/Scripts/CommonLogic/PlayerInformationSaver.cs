using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace StudyProject.NetcodeLearning
{
    public class PlayerInformationSaver : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _nameInputField = default;

        [SerializeField] private GameObject[] _checkingObjects = default;

        private void Start()
        {
            CheckPlayerName();
        }

        public void SavePlayerName()
        {
            if(_nameInputField.text != string.Empty)
            {
                PlayerPrefs.SetString(PlayerPrefsKeys.NAME_KEY, _nameInputField.text);
            }
        }

        public void CheckObjectsActivityByStringValue(string value)
        {
            if(value == string.Empty)
            {
                SetActiveCheckableObjects(false);
            }
            else
            {
                SetActiveCheckableObjects(true);
            }
        }

        private void SetActiveCheckableObjects(bool isActive)
        {
            foreach (GameObject sceneObject in _checkingObjects)
            {
                sceneObject.SetActive(isActive);
            }
        }

        private void CheckPlayerName()
        {
            if(PlayerPrefs.HasKey(PlayerPrefsKeys.NAME_KEY))
            {
                LoadPlayerName();
            }
        }

        private void LoadPlayerName()
        {
            _nameInputField.text = PlayerPrefs.GetString(PlayerPrefsKeys.NAME_KEY);
        }
    }
}