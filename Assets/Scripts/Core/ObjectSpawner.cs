using Box;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] protected Transform prefab;
    [SerializeField] protected Transform parent;
    [SerializeField] protected Vector3 position;
    [SerializeField] protected Quaternion rotation;

    protected virtual Transform Spawn()
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
