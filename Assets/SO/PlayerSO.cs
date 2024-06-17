using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPlayerSO", menuName = "Character/Player")]
public class PlayerSO : CharacterSO
{
    [field:Header("# Player Data")]
    [field: SerializeField][field:Range(0f, 100f)] public float BaseCriticalPercent { get; private set; } = 10f;
    [field: SerializeField][field:Range(1f, 5f)] public float BaseCriticalDamage { get; private set; } = 1.5f;
    [field: SerializeField][field:Range(0f, 1f)] public float BaseCriticalAttackTransitionTime { get; private set; } = 0.4f;
}