using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform[] targets;
    // VELOCIDADE DO MOVIMENTO
    [SerializeField] private float speed;
    // POSIÇÃO INICIAL DO TOQUE
    [SerializeField] private Vector2 startTouchPosition;
    // POSIÇÃO FINAL DO TOQUE
    [SerializeField] private Vector2 endTouchPosition;
    // DISTÂNCIA MÍNIMA PARA CONSIDERAR UM SWIPE
    [SerializeField] private float swipeThreshold = 50f;
    // VARIÁVEL QUE ARMAZENA A DIREÇÃO (0=CIMA, 1=DIREITA, 2=BAIXO, 3=ESQUERDA)
    public int directionCode = -1;
    

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // VERIFICA SE EXISTE ALGUM TOQUE NA TELA
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // CAPTURA A POSIÇÃO INICIAL DO TOQUE
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            // CAPTURA A POSIÇÃO FINAL E VERIFICA O SWIPE
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                // PROCESSA O SWIPE
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
        // CALCULA A DIFERENÇA ENTRE AS POSIÇÕES FINAL E INICIAL
        float deltaX = endTouchPosition.x - startTouchPosition.x;
        float deltaY = endTouchPosition.y - startTouchPosition.y;
        // IGNORA MOVIMENTOS CURTOS (NÃO CONSIDERA SWIPE)
        if (Mathf.Abs(deltaX) < swipeThreshold && Mathf.Abs(deltaY) <
       swipeThreshold)
        {
            directionCode = -1; // NENHUMA DIREÇÃO DETECTADA
            return;
        }
        // VERIFICA SE O SWIPE É HORIZONTAL OU VERTICAL
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            // MOVIMENTO HORIZONTAL
            if (deltaX > 0)
            {
                directionCode = 0; // DIREITA
            }
            else
            {
                directionCode = 1; // ESQUERDA
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
