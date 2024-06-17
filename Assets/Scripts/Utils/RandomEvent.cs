using UnityEngine;

public class RandomEvent
{
    public static bool RandomBoolResult(float percent)
    {
        int per = (int)(percent * 10);
        int rand = Random.Range(1, 1001);
        
        return rand < per;
    }
    
}