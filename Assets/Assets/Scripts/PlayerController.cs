using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float verticalInput;
    [SerializeField] float speed = 10.0f;

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
    }
}
