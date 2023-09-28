using Core;
using Core.Input;
using UnityEngine;


public class Rotator : MonoBehaviour
{
    [Range(1, 30)]
    [SerializeField] float sensivity = 8f;
    
    float xRotation;
    new Camera camera;

    void Awake()
    {
        camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        Vector2 mouse = sensivity * Time.deltaTime * GameInput.MousePositionDelta;

        xRotation -= mouse.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector2.up * mouse.x);
    }
}
