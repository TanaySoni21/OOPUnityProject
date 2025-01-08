using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    GameManager gameManager;

    protected abstract void OnCollect(GameObject player, GameManager manager);

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            OnCollect(other.gameObject, gameManager);
            Destroy(gameObject); 
        }
    }
}
