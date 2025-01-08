using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10.0f;
    GameObject target;
    public void SetTarget(Enemy targetEnemy)
    {
        target = targetEnemy.gameObject;
        Debug.Log(target.name);
    }

    private void Update()
    {
        if (target != null)
        {
            //Vector3 normal = (target.transform.position - transform.position).normalized;
            transform.Translate(Vector3.up * projectileSpeed, Space.Self);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target)
        {
            Destroy(target);
            Destroy(gameObject);
        }
    }
}
