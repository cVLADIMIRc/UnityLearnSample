using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[HelpURL("https://docs.google.com/document/d/1Cmm__cbik5J8aHAI6PPaAUmEMF3wAcNo3rpgzsYPzDM/edit?usp=sharing")]
public class TransparentModule : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Скорость изменения прозрачности")]
    [Range(0.1f, 10f)]
    private float changeSpeed = 1.0f;

    private float defaultAlpha;
    private Material mat;
    private bool toDefault;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        defaultAlpha = mat.color.a;
        toDefault = false;
    }

    public void ActivateModule()
    {
        ShrinkBeforeDestroy();

        float target = toDefault ? defaultAlpha : 0;
        StopAllCoroutines();
        StartCoroutine(ChangeTransparencyCoroutine(new Color(mat.color.r, mat.color.g, mat.color.b, target)));
        toDefault = !toDefault;
    }

    private void ShrinkBeforeDestroy()
    {
        foreach (Transform child in transform)
        {
            StartCoroutine(ShrinkChild(child));
        }
    }

    private IEnumerator ShrinkChild(Transform child)
    {
        float elapsedTime = 0f;
        Vector3 initialScale = child.localScale;
        Vector3 targetScale = Vector3.zero;

        while (elapsedTime < 1f)
        {
            child.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime);
            elapsedTime += Time.deltaTime * changeSpeed;
            yield return null;
        }

        child.localScale = targetScale;
        Destroy(child.gameObject);
    }

    private IEnumerator ChangeTransparencyCoroutine(Color target)
    {
        Color start = mat.color;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * changeSpeed;
            mat.color = Color.Lerp(start, target, t);
            yield return null;
        }
        mat.color = target;
    }
}
