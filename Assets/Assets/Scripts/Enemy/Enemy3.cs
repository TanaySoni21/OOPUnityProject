using UnityEngine;

public class Enemy3 : Enemy
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
