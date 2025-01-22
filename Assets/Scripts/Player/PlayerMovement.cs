using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField]
    private float rotateSpeed = 75f;
    [SerializeField]
    private Camera playerCamera;
    private Vector2 rotation;

    [Space(13)] 
    
    [Header("Movement")]
    [SerializeField]
    private float walkSpeed = 5f;
    [SerializeField]
    private float sitDownSpeed = 2f;
    private Vector3 velocity;
    private Vector2 direction;

    [Space(13)]
    [Header("Jump")] 
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float gravity = -9.81f;
    
    [Space(13)]

    [SerializeField] 
    private CharacterController characterController;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        characterController.Move(velocity * Time.deltaTime);
        
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (characterController.isGrounded)
        {
            velocity.y = Input.GetKeyDown(KeyCode.Space) ? jumpForce : -0.1f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        mouseDelta *= rotateSpeed * Time.deltaTime;
        rotation.y += mouseDelta.x;
        rotation.x = Mathf.Clamp(rotation.x - mouseDelta.y, -90, 90);
        playerCamera.transform.localEulerAngles = rotation;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.height = 1f;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            characterController.height = 2f;
        }
    }

    private void FixedUpdate()
    {
        direction *= Input.GetKey(KeyCode.LeftControl) ? sitDownSpeed : walkSpeed;
        Vector3 move = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0) *
                       new Vector3(direction.x, 0, direction.y);
        velocity = new Vector3(move.x, velocity.y, move.z);
    }
}
