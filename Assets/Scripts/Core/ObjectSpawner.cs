using Box;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] Transform prefab;
    [SerializeField] Transform parent;
    [SerializeField] Vector3 position;
    [SerializeField] Quaternion rotation;

    protected Transform Spawn()
    {
        Transform instance;
        if (parent is null)
        {
            instance = Instantiate(prefab, position, rotation);
        }
        else
        {
            instance = Instantiate(prefab, parent);
            instance.localPosition = position;
            instance.localRotation = rotation;
        }
        return instance;
    }

    protected void SetParentScale(Transform instance)
    {
        instance.localScale = instance.GetComponentInParent<Transform>().lossyScale;
    }
}
