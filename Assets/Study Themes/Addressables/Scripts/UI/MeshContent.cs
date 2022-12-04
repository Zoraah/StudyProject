using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StudyProject.Addressales.Content
{
    public class MeshContent : ContentCategory
    {
        [SerializeField] private AssetReferenceT<MeshFilter>[] _meshAssetReferences = default;

        protected override void EnableContent(int assetIndex)
        {
            if(assetIndex == _currentCategory)
                return;
            
            if(assetIndex > _meshAssetReferences.Length - 1)
            {
                DoLoadOperation(0);
            }
            else if(assetIndex < 0)
            {
                DoLoadOperation(_meshAssetReferences.Length - 1);
            }
            else
            {
                DoLoadOperation(assetIndex);
            }
        }

        private void DoLoadOperation(int assetIndex)
        {
            Task<MeshFilter> loadMeshTask = LoadAsset(assetIndex);

            if(loadMeshTask.Result != null)
            {
                _categorySwitcher.SetContentGameObjectMesh(loadMeshTask.Result);
                _currentCategory = assetIndex;
            }
        }

        private async Task<MeshFilter> LoadAsset(int assetIndex)
        {
            Task<MeshFilter> loadingTask = _meshAssetReferences[assetIndex].LoadAssetAsync<MeshFilter>().Task;
            await loadingTask;
            if (loadingTask.IsCompletedSuccessfully)
            {
                ReleaseAsset(_currentCategory);
                return loadingTask.Result;
            }
            else
            {
                return null;
            }
        }

        private void ReleaseAsset(int assetIndex)
        {
            _meshAssetReferences[assetIndex].ReleaseAsset();
        }
    }
}