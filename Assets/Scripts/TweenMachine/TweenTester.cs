using UnityEngine;

public class TweenTester : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public float speed;

    public EaseTypes methodType; // gebruikt de enum list

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            TweenMachine.GetInstance().MoveGameObject(gameObject, targetPosition, speed, methodType);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            TweenMachine.GetInstance().RotateGameObject(gameObject, targetRotation, speed, methodType);
    }
}
