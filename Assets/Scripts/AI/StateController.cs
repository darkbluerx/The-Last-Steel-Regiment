using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof (Rigidbody2D))]
public class StateController : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;

    public SpriteRenderer spriteRenderer;
    public EnemyStats enemyStats;
    public Transform eyes;
    public State currentState;
    public State remainState;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public EnemyShooting enemyShooting;
    public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    bool aiActive; //laitetaan v‰liaikaisesti agentin patrol p‰‰lle

    public Rigidbody2D rb2d;

    private void Awake()
    {
        enemyShooting = GetComponent<EnemyShooting>();
        agent = GetComponent<NavMeshAgent>();
        rb2d = GetComponent<Rigidbody2D>();
        //agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {       
        //asetetaan akentin tranform normaaliin asentoon
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        aiActive = true;
    }

    public void SetupAI (bool aiActivationManager, List<Transform> wayPointsFromManager)
    {
        wayPointList = wayPointsFromManager;
        aiActive = aiActivationManager;

        if (aiActive)
        {
            agent.enabled = true;
        }
        else
        {
            agent.enabled = false;
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState == remainState) return;     
        currentState = nextState;      
        OnExitState();
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return stateTimeElapsed >= duration; //return false if is lower or true if its higher.
    }

    private void Update()
    {      
        if (!aiActive) return;
        currentState.UpdateState(this);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }

    private void FixedUpdate()
    {
        //DrawRay();
    }

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    private void DrawRay()
    {
        Vector3 forward = transform.TransformDirection(Vector3.right) * 15;
        Debug.DrawRay(transform.position, forward, Color.green);

        RaycastHit2D hit;

        if(Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right * 15), playerMask))
        {         
            //LookPlayer();
        }
        else { return; }
    }


    public void LookPlayer() //k‰‰nt‰‰ agentin pelaajaa kohti
    {

        //lis‰‰ ett‰ kun viholli n‰kee pelaajan sitten vasta se k‰‰ntyy pelaajaa kohti
        //k‰yt‰ raycast

        float targetAngle;

       // chaseTarget = GetComponent<Transform>();


        chaseTarget = GameObject.Find("Player").GetComponent<Transform>();

        // Mathf.Atan2 = Tan x/y
        Vector3 targetDirection = chaseTarget.transform.position - transform.position;


        targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        rb2d.MoveRotation(Mathf.LerpAngle(rb2d.rotation, targetAngle, 3 * Time.deltaTime));
    }
}
