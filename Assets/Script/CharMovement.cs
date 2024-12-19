using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class CharMovement : MonoBehaviour
{
    public float maxLinearVelocity = 5f;
    [SerializeField] private float _turnSpeed = 360f;
    [SerializeField] private float _rotationTolerance = 0.1f; // Tolleranza di rotazione (in gradi)

    private Rigidbody rb;
    private Player _playerStats;
    public Camera _cam;
    private Vector3 _mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _playerStats = GetComponent<Player>();
        maxLinearVelocity = _playerStats.speed;
    }

    void Update()
    {
        maxLinearVelocity = _playerStats.speed;
        Look();  // Rotazione verso il mouse
    }

    private void FixedUpdate()
    {
        Move();  // Movimento del personaggio
    }

    // Calcola il movimento in base all'input da tastiera (W, A, S, D)
    public void Move()
    {

        // Calcola la direzione del mouse rispetto al personaggio
        Vector3 moveDirection = GetMoveDirection();

        // Se c'è input, muovi il personaggio nella direzione desiderata
        if (moveDirection.magnitude > 0.1f)
        {
            Vector3 moveOffset = moveDirection * maxLinearVelocity * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + moveOffset);
        }
    }

    // Calcola la rotazione verso la posizione del mouse
    public void Look()
    {
        // Crea un piano orizzontale a Y=0 per calcolare la posizione del mouse
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float distance))
        {
            _mousePos = ray.GetPoint(distance);
        }

        // Calcola la direzione di rotazione verso il mouse
        Vector3 lookDir = (_mousePos - rb.position).normalized;
        lookDir.y = 0; // Ignora l'asse Y

        if (lookDir.magnitude < 0.01f)
            return; // Esci se la direzione è troppo piccola (evita oscillazioni)

        float angle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

        // **Controllo della tolleranza**
        float angleDifference = Quaternion.Angle(rb.rotation, targetRotation);
        if (angleDifference < _rotationTolerance)
            return; // Se la differenza angolare è troppo piccola, non ruotare

        rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, _turnSpeed * Time.deltaTime));
    }

    // Restituisce la direzione di movimento rispetto al mouse
    private Vector3 GetMoveDirection()
    {
        // Calcola la direzione del mouse rispetto alla posizione del giocatore
        Vector3 directionToMouse = (_mousePos - rb.position).normalized;
        directionToMouse.y = 0;  // Ignora la componente Y

        // Movimenti W, A, S, D rispetto al mouse
        if (Input.GetKey(KeyCode.W))
        {
            return directionToMouse;  // Movimento verso il mouse
        }
        if (Input.GetKey(KeyCode.S))
        {
            return -directionToMouse; // Movimento all'indietro rispetto al mouse
        }
        if (Input.GetKey(KeyCode.A))
        {
            return -Vector3.Cross(Vector3.up, directionToMouse); // Movimento verso sinistra rispetto al mouse
        }
        if (Input.GetKey(KeyCode.D))
        {
            return Vector3.Cross(Vector3.up, directionToMouse); // Movimento verso destra rispetto al mouse
        }

        return Vector3.zero;  // Se nessun tasto è premuto, il personaggio non si muove
    }

}
