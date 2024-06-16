using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                // 해당 컴포넌트를 가지고 있는 게임 오브젝트를 찾아서 반환한다.
                instance = (T)FindAnyObjectByType(typeof(T));

                if (instance == null) // 인스턴스를 찾지 못한 경우
                {
                    // 새로운 게임 오브젝트를 생성하여 해당 컴포넌트를 추가한다.
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                    // 생성된 게임 오브젝트에서 해당 컴포넌트를 instance에 저장한다.
                    instance = obj.GetComponent<T>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if(transform.parent != null && transform.root != null) // 해당 오브젝트가 자식 오브젝트라면
        {
            DontDestroyOnLoad(this.transform.root.gameObject); // 부모 오브젝트를 DontDestroyOnLoad 처리
        }
        else
        {
            DontDestroyOnLoad(this.gameObject); // 해당 오브젝트가 최 상위 오브젝트라면 자신을 DontDestroyOnLoad 처리
        }
    }
}