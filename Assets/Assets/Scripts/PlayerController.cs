using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float verticalInput;
    [SerializeField] protected float speed = 10.0f;
    [SerializeField] float strengthPowerUpforce;

    public bool hasStrengthPowerUp = false;

    public float Speed 
    {
        get { return speed; }
        set { speed = Mathf.Max(10.0f, value); }
    }
    public GameObject indicator;

    GameObject focalPoint;
    Rigidbody rb;

    private void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        rb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        indicator.transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z) ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<Enemy>() && hasStrengthPowerUp)
        {
            Vector3 normal = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
            collision.rigidbody.AddForce(normal * strengthPowerUpforce, ForceMode.Impulse);
        } 
    }
}
