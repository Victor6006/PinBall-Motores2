using UnityEngine;

public class Flippers : MonoBehaviour
{
    public enum FlipperSide { Left, Right }
    public FlipperSide side;

    public float motorSpeed = 1000f; // Speed at which the flipper moves
    public float motorTorque = 10000f; // Max force applied

    private HingeJoint2D hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        hinge.useMotor = true; // Ensure motor is enabled
    }

    void Update()
    {
        bool isPressed = (side == FlipperSide.Left && Input.GetKey(KeyCode.LeftArrow)) ||
                         (side == FlipperSide.Right && Input.GetKey(KeyCode.RightArrow));

        JointMotor2D motor = hinge.motor;

        if (isPressed)
        {
            motor.motorSpeed = (side == FlipperSide.Left) ? motorSpeed : -motorSpeed;
        }
        else
        {
            motor.motorSpeed = (side == FlipperSide.Left) ? -motorSpeed : motorSpeed;
        }

        motor.maxMotorTorque = motorTorque;
        hinge.motor = motor;
    }
}
