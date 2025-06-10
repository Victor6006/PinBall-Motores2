using UnityEngine;
using UnityEngine.InputSystem; // Novo input system

public class BallLauncher : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public float maxForce = 800f;
    public float chargeSpeed = 400f;
    private float currentForce = 0f;
    private bool charging = false;

    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.downArrowKey.isPressed)
        {
            charging = true;
            currentForce += chargeSpeed * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, 0, maxForce);
        }

        if (keyboard.downArrowKey.wasReleasedThisFrame && charging)
        {
            LaunchBall();
            currentForce = 0f;
            charging = false;
        }
    }

    void LaunchBall()
    {
        if (ballRigidbody != null)
        {
            Vector2 launchDirection = Vector2.up;
            ballRigidbody.AddForce(launchDirection * currentForce);
        }
    }
}
