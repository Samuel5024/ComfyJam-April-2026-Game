using UnityEngine;
using UnityEngine.InputSystem;

public class BeeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

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
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float moveHorizontal = movementInput.ReadValue<Vector2>().x;
        float moveVertical = movementInput.ReadValue<Vector2>().y;

        Vector2 movement = transform.right * moveHorizontal + transform.up * moveVertical;
        Vector2 targetVelocity = movement.normalized * moveSpeed;
        rb.linearVelocity = targetVelocity;
    }
}
