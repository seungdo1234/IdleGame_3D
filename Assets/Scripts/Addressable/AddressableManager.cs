using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets; // using Addressable

public class AddressableManager : MonoBehaviour
{
    // 어드레서블 타입 선언
    [SerializeField] private AssetReferenceGameObject cubeObj;
    [SerializeField] private AssetReferenceGameObject planeObj;
    [SerializeField] private AssetReferenceSprite coinSprite;

    [SerializeField] private Image image;

    // 생성된 오브젝트들을 저장하는 리스트
    private List<GameObject> gameObjs = new List<GameObject>();

 

    public void Button_SpawnObject() // Load
    {
        cubeObj.InstantiateAsync().Completed += (obj) =>
        {
            gameObjs.Add(obj.Result);
        };

        planeObj.InstantiateAsync().Completed += (obj) =>
        {
            gameObjs.Add(obj.Result);
        };

        coinSprite.LoadAssetAsync().Completed += (img) =>
        {
            image.sprite = img.Result;
        };
    }

    public void Button_ReleaseObject() // Release
    {
        if(gameObjs.Count == 0)
        {
            return;
        }

        coinSprite.ReleaseAsset();
        image.sprite = null;
        
        for(int i = gameObjs.Count - 1; i >= 0; i--)
        {
            Addressables.ReleaseInstance(gameObjs[i]);
            gameObjs.RemoveAt(i);
        }
    }
}
