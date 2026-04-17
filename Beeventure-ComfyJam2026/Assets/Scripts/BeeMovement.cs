using UnityEngine;
using UnityEngine.InputSystem;

public class BeeMovement : MonoBehaviour
{
    [SerializeField] private float moveAcceleration;
    [SerializeField] private float maxSpeed;
    [Range(0f, 1f)]
    [SerializeField] private float slowRate;
    [SerializeField] private float timeAdjustment;

    private InputAction movementInput;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (!rb)
        {
            Debug.LogError("NO RIGIDBODY ON BEE");
        }

        movementInput = InputSystem.actions.FindAction("Move");

        if (ConstantData.hatType == HatType.Speed)
        {
            moveAcceleration *= ConstantData.hatTeir + 1;
            maxSpeed *= ConstantData.hatTeir + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        ClampSpeed();
    }

    private void HandleMovement()
    {
        float moveHorizontal = movementInput.ReadValue<Vector2>().x;
        float moveVertical = movementInput.ReadValue<Vector2>().y;

        Vector2 movement = transform.right * moveHorizontal + transform.up * moveVertical;
        Vector2 targetVelocity = movement.normalized * moveAcceleration;
        rb.AddForce(targetVelocity * Time.deltaTime * timeAdjustment);
    }

    private void ClampSpeed()
    {
        if(rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
        rb.AddForce(rb.linearVelocity * -1 * slowRate * Time.deltaTime * timeAdjustment);
    }
}
