using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.Addressales.Content
{
    public class CategorySwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject _contentGameObject = default;

        [SerializeField] private ContentCategory[] _contentCategories = default;

        private int _currentCategory = default;

        private Material _contentGameObjectMaterial = default;
        private MeshFilter _contentGameObjectMeshFilter = default;
        private AudioSource _contentGameObjectAudioSource = default;

        private void Start()
        {
            GetComponents();
            EnableFirstCategory();
        }

        public void EnableNextCategory()
        {
            if(_currentCategory == _contentCategories.Length - 1)
            {
                SetActiveCategory(0);
            }
            else
            {
                SetActiveCategory(_currentCategory++);
            }
        }

        public void EnablePreviousCategory()
        {
            if(_currentCategory == 0)
            {
                SetActiveCategory(_contentCategories.Length -1);
            }
            else
            {
                SetActiveCategory(_currentCategory--);
            }
        }

        public void SetContentGameObjectTexture(Texture texture)
        {
            _contentGameObjectMaterial.mainTexture = texture;
        }

        public void SetContentGameObjectMesh(MeshFilter meshFilter)
        {
            _contentGameObjectMeshFilter.mesh = meshFilter.mesh;
        }

        public void SetContentGameObjectAudioClip(AudioClip audioClip)
        {
            _contentGameObjectAudioSource.clip = audioClip;
            _contentGameObjectAudioSource.Play();
        }

        private void EnableFirstCategory()
        {
            _currentCategory = 0;
            _contentCategories[_currentCategory].SetActiveCategory(true);
        }

        private void SetActiveCategory(int nextCategory)
        {
            _contentCategories[_currentCategory].SetActiveCategory(false);
            _contentCategories[nextCategory].SetActiveCategory(true);
            _currentCategory = nextCategory;
        }

        private void GetComponents()
        {
            _contentGameObjectMaterial = _contentGameObject.GetComponent<Material>();
            _contentGameObjectMeshFilter = _contentGameObject.GetComponent<MeshFilter>();
            _contentGameObjectAudioSource = _contentGameObject.GetComponent<AudioSource>();
        }
    }
}