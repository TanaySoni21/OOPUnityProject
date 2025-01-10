using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 10.0f;
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = Mathf.Max(0, value);
        }
    }

    protected Rigidbody rb;
    GameObject player;
    float yBound = -10.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        FollowPlayer();
        DestroyOutOfBounds();
    }

    void FollowPlayer()
    {
        Vector3 enemyToPlayerNormal = (player.transform.position - gameObject.transform.position).normalized;
        rb.AddForce(enemyToPlayerNormal * speed);
    }

    void DestroyOutOfBounds()
    {
        if (gameObject.transform.position.y < yBound)
        {
            Destroy(gameObject);
        }
    }
}
