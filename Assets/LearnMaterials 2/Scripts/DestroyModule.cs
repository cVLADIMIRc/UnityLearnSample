using System;
using System.Collections;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1RMamVxE-yUpSfsPD_dEa4-Ak1qu6NTo83qY1O4XLxUY/edit?usp=sharing")]
public class DestroyModule : MonoBehaviour
{
    [Header("Модуль")]
    [SerializeField]
    private bool debug;
    [SerializeField]
    private float destroyDelay;
	[SerializeField]
	private int minimalDestroyingObjectsCount;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    [ContextMenu("Начать удаление объектов")]
    public void ActivateModule()
    {
        StartCoroutine(DestroyRandomChildObjectCoroutine());
        if (debug)
        {
            Debug.Log("Все компоненты удалены");
        }
    }

    private IEnumerator DestroyRandomChildObjectCoroutine()
    {
        while (myTransform.childCount > minimalDestroyingObjectsCount)
        {
            int index = UnityEngine.Random.Range(0, myTransform.childCount - 1);
            Destroy(myTransform.GetChild(index).gameObject);
            yield return new WaitForSeconds(destroyDelay);
        }
        Destroy(gameObject, Time.deltaTime);
    }
}
