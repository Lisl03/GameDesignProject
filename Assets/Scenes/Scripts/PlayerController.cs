using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Bewegungsgeschwindigkeit des Spielers
    public float horizontalSpeed = 5f; // Horizontale Geschwindigkeit
    public float verticalSpeed = 5f;   // Vertikale Geschwindigkeit
    public float diagonalSpeedLimiter = 0.707f; // Diagonale Geschwindigkeit (0.707 entspricht 1/√2, um diagonale Bewegungen korrekt zu skalieren)
    public float scaleFactor = 0.1f; // Skalierungsfaktor für die Anpassung der Größe des Spielers
    public float initialScale = 1f; // Anfangsskala des Spielers

    private Animator animator;     // Animator des Spielers
    private Rigidbody2D rb;        // Rigidbody2D des Spielers
    private Vector2 movement;      // Bewegungsrichtung des Spielers
    private float lastYPosition;   // Letzte Y-Position für die Skalierung
    private float speed;           // Geschwindigkeit des Spielers (für Animationen)

    private void Start()
    {
        // Komponenten zuweisen
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Setze die initiale Skalierung des Charakters
        transform.localScale = new Vector3(initialScale, initialScale, 1);
        lastYPosition = transform.position.y;

        // Skalierung sofort beim Start anpassen
        AdjustScale();
    }

    private void Update()
    {
        // Eingaben für die Bewegung (horizontal und vertikal)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Bewegungsrichtung berechnen
        movement = new Vector2(moveX, moveY).normalized;

        // Bewegung anwenden und Geschwindigkeit berechnen
        speed = movement.magnitude * moveSpeed;

        // Spielerbewegung (im Rigidbody2D anwenden)
        MovePlayer();

        // Animation aktualisieren
        AnimatePlayer(moveX, moveY);

        // Skalierung des Spielers basierend auf der Y-Position
        if (Mathf.Abs(lastYPosition - transform.position.y) > 0.01f)
        {
            AdjustScale();
            lastYPosition = transform.position.y;
        }
    }

    private void FixedUpdate()
    {
        // Anwendung der Geschwindigkeit auf das Rigidbody2D
        ApplyMovement();
    }

    private void MovePlayer()
    {
        // Überprüfe, ob der Spieler sich in horizontaler oder vertikaler Richtung bewegt
        if (movement.magnitude > 0)
        {
            rb.linearVelocity = movement * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Keine Bewegung, also setze die Geschwindigkeit auf null
        }
    }

    private void ApplyMovement()
    {
        // Geschwindigkeit auf das Rigidbody anwenden (über FixedUpdate)
        float speedX = movement.x * horizontalSpeed;
        float speedY = movement.y * verticalSpeed;

        if (movement.x != 0 && movement.y != 0)
        {
            // Reduziere Geschwindigkeit bei diagonaler Bewegung (Pythagoras)
            speedX *= diagonalSpeedLimiter;
            speedY *= diagonalSpeedLimiter;
        }

        rb.linearVelocity = new Vector2(speedX, speedY);
    }

    private void AnimatePlayer(float moveX, float moveY)
    {
        // Überprüfen, ob der Spieler sich bewegt
        if (speed > 0)
        {
            animator.SetFloat("Speed", 1f);  // Wenn sich der Spieler bewegt, setze die "Speed"-Variable auf > 0
        }
        else
        {
            animator.SetFloat("Speed", 0f);  // Wenn der Spieler nicht bewegt, setze die "Speed"-Variable auf 0 für Idle
        }

        // Überprüfe die Richtung des Spielers und aktualisiere die Bewegungsrichtung im Animator
        if (moveY > 0)
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 1);
        }
        else if (moveY < 0)
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -1);
        }
        else if (moveX < 0)
        {
            animator.SetFloat("MoveX", -1);
            animator.SetFloat("MoveY", 0);
        }
        else if (moveX > 0)
        {
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 0);
        }
        else
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);  // Idle-Animation, wenn der Spieler keine Eingabe hat
        }
    }

    private void AdjustScale()
    {
        // Skalierung basierend auf der Y-Position anpassen
        float newY = transform.position.y;
        float scale = initialScale - newY * scaleFactor;
        scale = Mathf.Clamp(scale, 0.1f, 2f);  // Setze Grenzen für die Skalierung
        transform.localScale = new Vector3(scale, scale, 1);
    }

    // Kollisionserkennung
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kollision mit: " + collision.gameObject.name);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Diese Methode wird jedes Mal aufgerufen, solange die Kollision andauert
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Diese Methode wird aufgerufen, wenn die Kollision endet
    }
}
