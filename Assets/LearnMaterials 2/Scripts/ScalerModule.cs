using System.Collections;
using UnityEngine;

public class ScalerModule : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetScale = new Vector3(2, 2, 2);

    [SerializeField]
    [Range(0.1f, 10f)]
    [Tooltip("Speed of scale change")]
    private float changeSpeed = 1f;

    private Vector3 defaultScale;
    private Transform myTransform;
    private bool toDefault;

    private void Start()
    {
        myTransform = transform;
        defaultScale = myTransform.localScale;
        toDefault = false;
    }

    public void ActivateModule()
    {
        Vector3 target = toDefault ? defaultScale : targetScale;
        StopAllCoroutines();
        StartCoroutine(ScaleCoroutine(target));
        toDefault = !toDefault;
    }

    public void ReturnToDefaultState()
    {
        toDefault = true;
        ActivateModule();
    }

    private IEnumerator ScaleCoroutine(Vector3 target)
    {
        Vector3 start = myTransform.lossyScale;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * changeSpeed;
            myTransform.localScale = Vector3.Lerp(start, target, t);
            yield return null;
        }
        myTransform.localScale = target;
    }
}
