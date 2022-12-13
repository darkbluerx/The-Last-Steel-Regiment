using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    private void Attack(StateController controller)
    {
        RaycastHit2D hit;
        Vector3 position = controller.eyes.position;
        float radius = controller.enemyStats.lookSphereCastRadius;
        Vector3 direction = controller.eyes.right;
        float attackRange = controller.enemyStats.attackRange;

        Debug.DrawRay(position, direction.normalized * attackRange, Color.red);

        hit = Physics2D.Raycast(position, direction, attackRange);
     
        if (Physics2D.CircleCast(position, radius, direction, attackRange) || hit.collider.CompareTag("Player"))
        {
            if (controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate))
            {
                controller.enemyShooting.ShootPlayer(controller.enemyStats.attackForce, controller.enemyStats.attackRate);
            }
            else return;
        }
    }
}
