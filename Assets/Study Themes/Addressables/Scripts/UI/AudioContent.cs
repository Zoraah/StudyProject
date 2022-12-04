using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StudyProject.Addressales.Content
{
    public class AudioContent : ContentCategory
    {
        [SerializeField] private AssetReferenceT<AudioClip>[] _audioClipAssetReferences = default;

        protected override void EnableContent(int assetIndex)
        {
            if(assetIndex == _currentCategory)
                return;

            if(assetIndex > _audioClipAssetReferences.Length - 1)
            {
                DoLoadOperation(0);
            }
            else if(assetIndex < 0)
            {
                DoLoadOperation(_audioClipAssetReferences.Length - 1);
            }
            else
            {
                DoLoadOperation(assetIndex);
            }
        }

        private void DoLoadOperation(int assetIndex)
        {
            Task<AudioClip> loadMeshTask = LoadAsset(assetIndex);

            if(loadMeshTask.Result != null)
            {
                _categorySwitcher.SetContentGameObjectAudioClip(loadMeshTask.Result);
                _currentCategory = assetIndex;
            }
        }

        private async Task<AudioClip> LoadAsset(int assetIndex)
        {
            Task<AudioClip> loadingTask = _audioClipAssetReferences[assetIndex].LoadAssetAsync<AudioClip>().Task;
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
            _audioClipAssetReferences[assetIndex].ReleaseAsset();
        }
    }
}