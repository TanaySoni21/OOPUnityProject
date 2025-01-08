using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float horizontalInput;
    [SerializeField] float rotateSpeed = 60.0f;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, horizontalInput * rotateSpeed * Time.deltaTime);
    }
}
