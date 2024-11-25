using UnityEngine;

public class SliderJointController : MonoBehaviour
{
    
    public float speedForward = 10f;  // Скорость вперед
    public float speedBackward = -10f; // Скорость назад

    private SliderJoint2D sliderJoint;
    private JointMotor2D motor;

    void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();

        // Инициализация мотора
        motor = sliderJoint.motor;
        motor.motorSpeed = speedForward; // Начальное движение вперед
        sliderJoint.motor = motor;
    }

    void Update()
    {
        // Текущее смещение
        float currentTranslation = sliderJoint.jointTranslation;

        // Состояние лимита джойнта
        JointLimitState2D limitState = sliderJoint.limitState;

        // Проверка на достижение верхнего лимита
        if (limitState == JointLimitState2D.UpperLimit)
        {
            motor.motorSpeed = speedBackward; // Меняем направление на обратное
            sliderJoint.motor = motor;
        }
        // Проверка на достижение нижнего лимита
        else if (limitState == JointLimitState2D.LowerLimit)
        {
            motor.motorSpeed = speedForward; // Меняем направление на вперед
            sliderJoint.motor = motor;
        }
    }
}
