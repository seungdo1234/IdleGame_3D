using UnityEngine;

[CreateAssetMenu(fileName = "DefaultEnemySO", menuName = "Character/Enemy")]
public class EnemySO : CharacterSO
{
    [field:Header("# Enemy Data")]
    [field: SerializeField][field:Range(0f, 100f)] public float BaseScanRange { get; private set; } = 10f;
}