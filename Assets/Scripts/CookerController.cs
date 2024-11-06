using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CookerController : MonoBehaviour
{
    public float speed = 3f;

    private Vector2 targetPosition; 
    private bool isMoving = false; 
    private bool canMove = false; 
    private Rigidbody2D rb; 
    [SerializeField] private Animator animator; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            MoveToTarget();
        }
    }

    void Update()
    {
        if (canMove && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = mousePosition; 
            isMoving = true;

            animator.SetBool("isWalking", true); 
        }
    }

    void OnMouseDown()
    {
        if (!canMove)
        {
            canMove = true;
        }
    }

    void MoveToTarget()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime));

        if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
        {
            isMoving = false;
            animator.SetBool("isWalking", false); 
        }
    }

   void OnCollisionEnter2D(Collision2D collision)
{
    if (isMoving)
    {
        Vector2 collisionPoint = collision.contacts[0].point;

        if (collision.gameObject.layer == LayerMask.NameToLayer("FoodTool"))
        {
            if (collisionPoint.x > transform.position.x)
            {
                animator.SetTrigger("HandMakeLeft");
            }
            else if (collisionPoint.x < transform.position.x)
            {
                animator.SetTrigger("HandMake");
            }

            isMoving = false; 
            animator.SetBool("isWalking", false); 
        }
    }
}
}
