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

    [SerializeField] protected int level = 1;
    public int Level
    {
        get { return level; }
        set { level = Mathf.Max(1, value); }
    }

    protected Rigidbody rb;
    GameObject player;
    float yBound = -10.0f;
    GameManager gameManager;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    private void Update()
    {
        if (!gameManager.isGameOver)
        {
            FollowPlayer();
            DestroyOutOfBounds();
        }
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
