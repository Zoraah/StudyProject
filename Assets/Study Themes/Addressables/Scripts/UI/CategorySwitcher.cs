using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.Addressales.Content
{
    public class CategorySwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject _contentGameObject = default;

        [SerializeField] private ContentCategory[] _contentCategories = default;

        [SerializeField] private int _currentCategory = default;

        [SerializeField] private Material _contentGameObjectMaterial = default;
        [SerializeField] private MeshFilter _contentGameObjectMeshFilter = default;
        [SerializeField] private AudioSource _contentGameObjectAudioSource = default;

        private void Start()
        {
            GetComponents();
            ClearAssets();
            EnableFirstCategory();
        }

        public void EnableNextCategory()
        {
            Debug.Log(_contentCategories.Length);

            if(_currentCategory == _contentCategories.Length - 1)
            {
                SetActiveCategory(0);
            }
            else
            {
                SetActiveCategory(_currentCategory + 1);
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
                SetActiveCategory(_currentCategory - 1);
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

        private void ClearAssets()
		{
            _contentGameObjectMaterial.mainTexture = null;
            _contentGameObjectAudioSource.clip = null;
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _contentGameObjectMeshFilter.mesh = go.GetComponent<MeshFilter>().mesh;
            Destroy(go);
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
            _contentGameObjectMeshFilter = _contentGameObject.GetComponent<MeshFilter>();
        }
    }
}