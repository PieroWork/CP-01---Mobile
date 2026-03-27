using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float jumpForce;
    [SerializeField] private Transform[] targets;
    
    [SerializeField] private float speed;
    
    [SerializeField] private Vector2 startTouchPosition;
    
    [SerializeField] private Vector2 endTouchPosition;
    
    [SerializeField] private float swipeThreshold = 50f;
    
    public int directionCode = -1;


    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                
                DetectSwipe();
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void DetectSwipe()
    {
        
        float deltaX = endTouchPosition.x - startTouchPosition.x;
        float deltaY = endTouchPosition.y - startTouchPosition.y;
        
        if (Mathf.Abs(deltaX) < swipeThreshold && Mathf.Abs(deltaY) <
       swipeThreshold)
        {
            directionCode = -1; 
            return;
        }
        
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            
            if (deltaX > 0)
            {
                directionCode = 0; 
            }
            else
            {
                directionCode = 1; 
            }
        }


    }
    void Move()
    {
        if (directionCode != -1)
        {
            Vector2 dir = Vector2.zero;

            if (directionCode == 0) dir = Vector2.right;
            if (directionCode == 1) dir = Vector2.left;

            rb.linearVelocity = new Vector2(dir.x * speed, rb.linearVelocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "point")
        {
            points.pontos++;

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }


    }
}