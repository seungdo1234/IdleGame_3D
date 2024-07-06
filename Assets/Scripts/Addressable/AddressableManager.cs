using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableManager : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject cubeObj;
    [SerializeField] private AssetReferenceGameObject planeObj;


    [SerializeField]private List<GameObject> gameObjs = new List<GameObject>();

    void Start()
    {
        StartCoroutine(InitAddressable());
    }

    private IEnumerator InitAddressable()
    {
        var init = Addressables.InitializeAsync();
        yield return init;
    }

    public void Button_SpawnObject()
    {
        cubeObj.InstantiateAsync().Completed += (obj) =>
        {
            gameObjs.Add(obj.Result);
        };

        planeObj.InstantiateAsync().Completed += (obj) =>
        {
            gameObjs.Add(obj.Result);
        };
    }

    public void Button_ReleaseObject()
    {
        if(gameObjs.Count == 0)
        {
            return;
        }

        for(int i = gameObjs.Count - 1; i >= 0; i--)
        {
            Addressables.ReleaseInstance(gameObjs[i]);
            gameObjs.RemoveAt(i);
        }
    }
}
