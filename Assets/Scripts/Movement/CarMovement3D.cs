using UnityEngine;

public class CarMovement3D : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 10f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // if you, like me, made your model the wrong way around in your 3D software, set moveSpeed to a negative value
        // in the inspector, then everything will be okay!
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed;
        rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);

        // note that rate of turn is inversely dependant on movement speed
        float turn = turnInput * turnSpeed * Time.fixedDeltaTime * moveInput;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
