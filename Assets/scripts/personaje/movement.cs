using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Vector3 objetivo;
    [SerializeField] private Camera camara;

    public ParticleSystem particlesHealth;
    public ParticleSystem particlesForce;   
    [SerializeField] MovementStats stats;


    private Vector2 inputMovement;
    private Rigidbody2D rb;
    private float angleDegrees;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        particlesForce.Stop();
        particlesHealth.Stop();
    }
    public void UpdateStat(MovementStats newStat)
    {
        stats = newStat;
    }

    void Update()
    {
        
        inputMovement = Vector2.zero;
        if (Input.GetKey(KeyCode.D)) inputMovement += Vector2.right;
        if (Input.GetKey(KeyCode.A)) inputMovement += Vector2.left;
        if (Input.GetKey(KeyCode.S)) inputMovement += Vector2.down;
        if (Input.GetKey(KeyCode.W)) inputMovement += Vector2.up;
        inputMovement = inputMovement.normalized;

        
        objetivo = camara.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - camara.transform.position.z));
        Vector3 direccion = objetivo - transform.position;
        angleDegrees = Vector3.SignedAngle(Vector3.up, direccion, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, angleDegrees);
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        
        Vector2 targetVelocity = inputMovement * stats.maxSpeed;

        
        Vector2 newVelocity = Vector2.MoveTowards(rb.linearVelocity, targetVelocity, stats.acceleration * Time.fixedDeltaTime);

        
        if (inputMovement == Vector2.zero)
        {
            newVelocity = Vector2.MoveTowards(rb.linearVelocity, Vector2.zero, stats.friction * Time.fixedDeltaTime);
        }

        rb.linearVelocity = newVelocity;
    }
}

