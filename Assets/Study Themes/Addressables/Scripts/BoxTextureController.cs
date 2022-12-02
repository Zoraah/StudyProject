using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BoxTextureController : MonoBehaviour
{
    [SerializeField] private Material _cubeMaterial;

    public TexturesList TextureList;
    
    private void OnEnable()
    {
        ReleaseAssets();
    }

    private void OnDestroy()
    {
        ReleaseAssets();
    }

    public void SetMaterial(int index)
    {
        ReleaseAssets();
        LoadAsset(index);
    }

    public void ReleaseAssets()
    {
        Debug.Log($"Persistent data path: {Application.persistentDataPath }");

        _cubeMaterial.mainTexture = null;

        foreach (var asset in TextureList.Textures)
        {
            if(asset.Asset != null)
            {
                asset.ReleaseAsset();
            }
        }

        AsyncOperation clearOperation = Resources.UnloadUnusedAssets();
        new WaitUntil(() => clearOperation.isDone);
    }

    private async void LoadAsset(int index)
    {
        if(TextureList.Textures[index].Asset == null)
        {
            //AsyncOperationHandle loadOperation = TextureList.Textures[index].LoadAssetAsync<Texture>();
            //AssetBundle assetBundle = TextureList.Textures[index];
            Task<Texture> loadTask = TextureList.Textures[index].LoadAssetAsync<Texture>().Task;
            await loadTask;
            _cubeMaterial.mainTexture = loadTask.Result;
        }
    }
}