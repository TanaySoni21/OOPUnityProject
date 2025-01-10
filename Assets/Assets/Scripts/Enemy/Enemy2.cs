using UnityEngine;

public class Enemy2 : Enemy
{
    [SerializeField] float enemyPushForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Vector3 normal = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
            collision.rigidbody.AddForce(normal * enemyPushForce, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
