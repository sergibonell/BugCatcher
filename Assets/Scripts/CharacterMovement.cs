using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] CinemachineVirtualCamera playerCamera;

    [SerializeField] float gravity = -9.8f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpPower = 3f;

    Vector3 movementInput;
    Vector2 horizontalVelocity;
    float verticalVelocity;
    Vector3 appliedVelocity;

    Vector2 rotation = Vector2.zero;
    [SerializeField, Range(1, 5)] float horizontalSensitivity = 1;
    [SerializeField, Range(1, 5)] float verticalSensitivity = 1;

    bool jumpQueued = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        VerticalMovement();

        appliedVelocity = new Vector3(horizontalVelocity.x, verticalVelocity, horizontalVelocity.y);
        characterController.Move(appliedVelocity * Time.deltaTime);
    }

    void HorizontalMovement()
    {
        Vector3 relativeDirection = Quaternion.AngleAxis(rotation.x, Vector3.up) * movementInput;
        horizontalVelocity = new Vector2(relativeDirection.x, relativeDirection.z).normalized * moveSpeed;
    }

    void VerticalMovement()
    {
        if (jumpQueued && characterController.isGrounded)
        {
            verticalVelocity = jumpPower;
        }
        else
        {
            jumpQueued = false;
            verticalVelocity = characterController.isGrounded ? -1 : verticalVelocity + gravity * Time.deltaTime;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && characterController.isGrounded)
        {
            jumpQueued = true;
        }    
    }

    public void OnMoveMouse(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();

        rotation.x += input.x * horizontalSensitivity * Time.deltaTime;

        if (rotation.x < -360)
            rotation.x += 360;
        else if (rotation.x > 360)
            rotation.x -= 360;

        rotation.y += input.y * verticalSensitivity * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -80, 80);
        Quaternion xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        Quaternion yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.rotation = xQuat;
        playerCamera.transform.localRotation = yQuat;
    }
}
