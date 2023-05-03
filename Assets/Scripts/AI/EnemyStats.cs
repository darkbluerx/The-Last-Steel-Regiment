using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float moveSpeed = 1f;
    public float lookRange = 10f;
    public float lookSphereCastRadius = 6f;

    public float attackRange = 1f;
    public float attackRate = 1f;
    public float attackForce = 15f;
    public int attackDamage = 50;

    public float searchDuration = 4f;
    public float searchingTurnSpeed = 120f;

    public float nextFireTime = 0.5f;
}
