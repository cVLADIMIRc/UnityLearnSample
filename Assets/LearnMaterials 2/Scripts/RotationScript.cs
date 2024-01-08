using UnityEngine;
using System.Collections;


public class RotationScript : SampleScriptBase
{
    public float rotationSpeed = 10f;
    public Vector3 targetRotation = new Vector3(90f, 0f, 0f);

    private Quaternion initialRotation;
    private Quaternion targetQuaternion;
    private bool isRotating = false;
    private float rotationTime = 0f;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetQuaternion = Quaternion.Euler(targetRotation);
    }

    public void Use() // Добавляем ключевое слово override
    {
        if (!isRotating)
        {
            isRotating = true;
            rotationTime = 0f;
            StartCoroutine(RotateObject());
        }
    }

    private IEnumerator RotateObject()
    {
        while (rotationTime < 1f)
        {
            rotationTime += Time.deltaTime / (Mathf.Abs(Quaternion.Dot(transform.rotation, targetQuaternion)) * rotationSpeed);
            transform.rotation = Quaternion.Slerp(initialRotation, targetQuaternion, rotationTime);
            yield return null;
        }
        isRotating = false;
    }
}
