using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D), typeof(NavMeshAgent))]
public class TopDownController : MonoBehaviour
{
    //public int m_PlayerNumber = 1;
    NavMeshAgent playerAgent;

    [SerializeField] Camera mainCamera;
    [SerializeField] Vector3 direction;
 
    [Space]
    [SerializeField] float moveSpeed = 4;
    [SerializeField] float SmoothSpeed = 4;
    [SerializeField] float runningSpeed = 10;
    [SerializeField] float walkingSpeed = 4;
    [Space]

    [SerializeField] float maxStamina = 5;
    [SerializeField] float currentStamina;

    Rigidbody2D rb2d;
    float targetAngle;

    bool canRun = true;

    private void Awake()
    {     
        rb2d = GetComponent<Rigidbody2D>();
        playerAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        moveSpeed = walkingSpeed;
        currentStamina = maxStamina;

        //sets the player's tranform correctly
        playerAgent.updateRotation = false;
        playerAgent.updateUpAxis = false;
    }
  
    void Update()
    {
        DrawRay();
        PlayerInput();
        MouseControls();
    }

    private void DrawRay()
    {
       // Debug.DrawLine(this.transform.position, this.transform.right * 1, Color.red, 1);
        Vector3 forward = transform.TransformDirection(Vector3.right) * 15;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

   private void PlayerInput()
   {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        direction = new Vector2(x, y).normalized;

        if (Input.GetKey(KeyCode.LeftShift) && canRun)
        {
            moveSpeed = runningSpeed;
            currentStamina -= Time.deltaTime * 2;

            if (currentStamina < 0)
            {
                canRun = false;
                currentStamina = 0;
            }
        }
        else
        {
            moveSpeed = walkingSpeed;
            currentStamina += Time.deltaTime;
            if (currentStamina > maxStamina)
            {
                canRun = true;
                currentStamina = maxStamina;
            }
        }
   }

    private void FixedUpdate()
    {
        rb2d.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
        rb2d.MoveRotation(Mathf.LerpAngle(rb2d.rotation, targetAngle, SmoothSpeed * Time.deltaTime));
    }

    private void MouseControls()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mousePosition - transform.position;
        targetAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
    }
}
