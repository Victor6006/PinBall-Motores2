using UnityEngine;
using UnityEngine.InputSystem; // Importante!

public class Flippers : MonoBehaviour
{
    public enum FlipperSide { Left, Right }
    public FlipperSide side;

    public float motorSpeed = 1000f;
    public float motorTorque = 10000f;

    private HingeJoint2D hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        hinge.useMotor = true;
    }

    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard == null) return; // Segurança para evitar erros em plataformas sem teclado

        bool isPressed = (side == FlipperSide.Left && keyboard.rightArrowKey.isPressed) ||
                         (side == FlipperSide.Right && keyboard.leftArrowKey.isPressed);

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
