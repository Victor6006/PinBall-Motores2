using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public Transform launchPoint;
    public float maxForce = 800f; 
    public float chargeSpeed = 400f; 
    private float currentForce = 0f;
    private bool charging = false;

    void Update()
    {
    
        if (Input.GetKey(KeyCode.DownArrow))
        {
            charging = true;
            currentForce += chargeSpeed * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, 0, maxForce);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && charging)
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
            // Aplica força para cima (você pode mudar a direção)
            Vector2 launchDirection = Vector2.up;
            ballRigidbody.AddForce(launchDirection * currentForce);
        }
    }
}
