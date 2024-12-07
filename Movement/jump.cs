using UnityEngine;

public class VRJumpOnly : MonoBehaviour
{
    public XRNode inputSource = XRNode.RightHand; // Input source for the B button
    public float jumpHeight = 2.0f;              // Jump height
    public float gravity = -9.81f;               // Gravity for the character
    public Animator animator;                    // Animator for the jump animation
    public CharacterController characterController; // CharacterController for movement

    private Vector3 velocity;
    private bool isGrounded;

    void Update()
    {
        // Check if the character is grounded
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Reset vertical velocity when grounded
        }

        // Jump with the B button
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isJumpPressed) && isJumpPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate jump velocity
            animator.SetTrigger("jump"); // Trigger jump animation
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Move character vertically
        characterController.Move(velocity * Time.deltaTime);
    }
}
