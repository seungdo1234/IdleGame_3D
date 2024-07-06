using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableManager : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject cubeObj;
    [SerializeField] private AssetReferenceGameObject planeObj;


    private List<GameObject> gameObjs = new List<GameObject>();

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
}
