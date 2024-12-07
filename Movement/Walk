using UnityEngine;

public class VRPlayerMovement : MonoBehaviour
{
    public XRNode inputSource = XRNode.LeftHand; // Input source for the left controller
    public float speed = 2.0f;                  // Movement speed
    public Animator animator;                  // Animator component for the walk animation
    public CharacterController characterController; // CharacterController for smooth movement
    public Transform playerBody;               // Reference to the player's body for rotation

    private Vector2 inputAxis;

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axis))
        {
            inputAxis = axis;
        }
        else
        {
            inputAxis = Vector2.zero;
        }

        Vector3 direction = playerBody.forward * inputAxis.y + playerBody.right * inputAxis.x;
        if (direction.magnitude > 0.1f)
        {
            Vector3 move = direction.normalized * speed * Time.deltaTime;
            characterController.Move(move);

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
