using System.Collections.Generic;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1GP4_m0MzOF8L5t5pZxLChu3V_TFIq1czi1oJQ2X5kpU/edit?usp=sharing")]
public class GameObjectActivator : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // Префаб для создания копий
    [SerializeField] private int numberOfCopies = 5; // Количество копий
    [SerializeField] private float stepDistance = 2.0f; // Шаг (дистанция) между копиями

    [SerializeField] private List<StateContainer> targets;
    [SerializeField] private List<GameObject> spawnedObjects; // Добавлен новый список для хранения созданных копий
    [SerializeField] private bool debug;

    private void Awake()
    {
        InitializeTargets();
    }

    [ContextMenu("Activate Module")]
    public void ActivateModule()
    {
        SetStateForAll();
    }

    [ContextMenu("Return to Default State")]
    public void ReturnToDefaultState()
    {
        InitializeTargets(); // Убеждаемся, что targets инициализирован

        foreach (var item in targets)
        {
            if (item != null && item.targetGO != null)
            {
                item.targetGO.SetActive(item.defaultValue);
                item.targetState = item.defaultValue;
            }
            else
            {
                Debug.LogError("Invalid StateContainer or targetGO reference.");
            }
        }

        // Удаляем все созданные копии из списка spawnedObjects только в режиме воспроизведения (не в режиме редактирования)
        if (Application.isPlaying)
        {
            foreach (var spawnedObject in spawnedObjects)
            {
                Destroy(spawnedObject);
            }
            spawnedObjects.Clear();
        }
    }

    [ContextMenu("Use")]
    public void Use()
    {
        CreateCopies();
    }

    private void CreateCopies()
    {
        if (prefab == null)
        {
            Debug.LogError("Префаб не задан.");
            return;
        }

        // Определение точки старта для создания копий
        Vector3 spawnPosition = transform.position + transform.forward * stepDistance;

        // Создание указанного количества копий
        for (int i = 0; i < numberOfCopies; i++)
        {
            GameObject clone = Instantiate(prefab, spawnPosition, Quaternion.identity);
            spawnedObjects.Add(clone); // Добавляем созданную копию в список
            spawnPosition += transform.forward * stepDistance;
        }
    }

    private void SetStateForAll()
    {
        InitializeTargets(); // Убеждаемся, что targets инициализирован

        if (targets == null)
        {
            Debug.LogWarning("Targets list is not initialized in SetStateForAll.");
            return;
        }

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] != null && targets[i].targetGO != null)
            {
                targets[i].targetGO.SetActive(!targets[i].targetState);
                targets[i].targetState = !targets[i].targetState;
            }
            else
            {
                Debug.LogError("Invalid StateContainer or targetGO reference.");
            }
        }
    }

    #region Gizmos
    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawSphere(transform.position, 0.3f);

            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i] != null && targets[i].targetGO != null)
                {
                    Gizmos.color = targets[i].targetState ? Color.green : Color.red;
                    Gizmos.DrawLine(transform.position, targets[i].targetGO.transform.position);
                }
                else
                {
                    Debug.LogError("Invalid StateContainer or targetGO reference.");
                }
            }
        }
    }
    #endregion

    private void InitializeTargets()
    {
        if (targets == null)
        {
            targets = new List<StateContainer>();
            Debug.LogWarning("Targets list was null and has been initialized.");
        }

        foreach (var item in targets)
        {
            if (item != null && item.targetGO != null)
            {
                item.defaultValue = item.targetGO.activeSelf;
            }
            else
            {
                Debug.LogError("Invalid StateContainer or targetGO reference in Awake.");
            }
        }
    }
}

[System.Serializable]
public class StateContainer
{
    [Tooltip("Объект, которому нужно задать состояние")]
    public GameObject targetGO;

    [Tooltip("Целевое состояние. Если отмечено, объект будет включен")]
    public bool targetState = false;

    [HideInInspector] public bool defaultValue;
}
