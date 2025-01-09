using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    protected GameManager gameManager;

    protected abstract void OnCollect(GameObject player, GameManager manager);

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            OnCollect(other.gameObject, gameManager);
            Destroy(gameObject); 
        }
    }

    public virtual void DeactivateSelf() { }
}
