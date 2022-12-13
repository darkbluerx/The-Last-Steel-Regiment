using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        RaycastHit2D hit;  
        Vector3 position = controller.eyes.position;
        float radius = controller.enemyStats.lookSphereCastRadius;
        Vector3 direction = controller.eyes.right;
        float lookRange = controller.enemyStats.lookRange;
        
        Debug.DrawRay(position, direction.normalized * lookRange, Color.green);

        //https://www.youtube.com/watch?v=9jsZpmX1tX0

        hit = Physics2D.Raycast(position, direction, lookRange);

        if (Physics2D.CircleCast(position, radius, direction, lookRange) && hit.collider.CompareTag("Player"))
        {
            //EnemyController chaseTarget muuttuja saa viitteen pelaajasta
            controller.chaseTarget = hit.transform;
            Debug.Log("Pelaaja osunut ray-säteesee!");
            return true;
         
        }
        else
        {
            return false;
        }
    }                       
}
