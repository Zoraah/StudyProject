using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StudyProject.Addressales.Content
{
    public class TextureContent : ContentCategory
    {
        [SerializeField] private AssetReferenceTexture[] _textureAssetReferences = default;

        protected override void EnableContent(int assetIndex)
        {
            if(assetIndex == _currentCategory)
                return;
            
            if(assetIndex > _textureAssetReferences.Length - 1)
            {
                DoLoadOperation(0);
            }
            else if(assetIndex < 0)
            {
                DoLoadOperation(_textureAssetReferences.Length - 1);
            }
            else
            {
                DoLoadOperation(assetIndex);
            }
        }

        private async void DoLoadOperation(int assetIndex)
        {
            Texture texture = await LoadAsset(assetIndex);

            if(texture != null)
            {
                _categorySwitcher.SetContentGameObjectTexture(texture);
                _currentCategory = assetIndex;
            }
        }

        private async Task<Texture> LoadAsset(int assetIndex)
        {
            Task<Texture> loadingTask = _textureAssetReferences[assetIndex].LoadAssetAsync<Texture>().Task;
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
            if (_textureAssetReferences[assetIndex].Asset != null)
            {
                _textureAssetReferences[assetIndex].ReleaseAsset();
            }
        }
    }
}