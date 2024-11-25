using UnityEngine;

public class SliderJointController : MonoBehaviour
{
    
    public float speedForward = 10f;  // �������� ������
    public float speedBackward = -10f; // �������� �����

    private SliderJoint2D sliderJoint;
    private JointMotor2D motor;

    void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();

        // ������������� ������
        motor = sliderJoint.motor;
        motor.motorSpeed = speedForward; // ��������� �������� ������
        sliderJoint.motor = motor;
    }

    void Update()
    {
        // ������� ��������
        float currentTranslation = sliderJoint.jointTranslation;

        // ��������� ������ �������
        JointLimitState2D limitState = sliderJoint.limitState;

        // �������� �� ���������� �������� ������
        if (limitState == JointLimitState2D.UpperLimit)
        {
            motor.motorSpeed = speedBackward; // ������ ����������� �� ��������
            sliderJoint.motor = motor;
        }
        // �������� �� ���������� ������� ������
        else if (limitState == JointLimitState2D.LowerLimit)
        {
            motor.motorSpeed = speedForward; // ������ ����������� �� ������
            sliderJoint.motor = motor;
        }
    }
}
