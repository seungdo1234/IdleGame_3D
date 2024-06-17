using System.Collections.Generic;
using UnityEngine;

public enum EPoolObjectType{Default, Enemy, DamageText}

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public EPoolObjectType type; // key 값
        public GameObject prefab; // 실제 생성될 오브젝트
        public int size; // 한번에 몇개를 생성할 것인지
        public Transform parentTransform; // 부모 오브젝트
    }

    [Header("# Pool Info")] 
    [SerializeField] private List<Pool> pools;
    private Dictionary<EPoolObjectType, List<PoolObject>> poolDictionary;
    
    
    private void Awake()
    {
        // 딕셔너리 초기화
        poolDictionary = new Dictionary<EPoolObjectType, List<PoolObject>>();
        
        // pools에 있는 모든 오브젝트를 탐색하고 정해놓은 size만큼 프리팹을 미리 만들어 놓음
        foreach (Pool pool in pools)
        {
            List<PoolObject> list = new List<PoolObject>();
            poolDictionary.Add(pool.type,list);
            AddPoolObject(pool.type);
        }
    }

 
    private void AddPoolObject(EPoolObjectType type) // 프리팹 생성
    {
        Pool pool = pools.Find(obj => type == obj.type);
        
        // pool.size만큼 프리팹을 생성 -> 비활성화 -> 리스트에 넣어줌
        for (int i = 0; i < pool.size; i++)
        {
            PoolObject poolObj = Instantiate(pool.prefab, pool.parentTransform).GetComponent<PoolObject>();
            poolObj.gameObject.SetActive(false);
            poolDictionary[type].Add(poolObj);
        }
    }

    // 이미 생성된 오브젝트 풀에서 프리팹을 가져옴
    public PoolObject SpawnFromPool(EPoolObjectType type)
    {
        if (!poolDictionary.ContainsKey(type))
        {
            return null;
        }

        PoolObject poolObject = null;
        
        for (int i = 0; i < poolDictionary[type].Count; i++)
        {
            if (!poolDictionary[type][i].gameObject.activeSelf) // 비활성화된 오브젝트를 찾았을 때
            {
                poolObject = poolDictionary[type][i];
                break;
            }

            if (i == poolDictionary[type].Count - 1) // 모든 오브젝트가 활성화 됐을 때 
            {
                AddPoolObject(type);
                poolObject = poolDictionary[type][i + 1];
            }
        }
        
        poolObject.gameObject.SetActive(true); // 활성화
        
        return poolObject;
    }
}