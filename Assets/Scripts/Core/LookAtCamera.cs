using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Mode mode;
    private enum Mode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted,
    }

    new Transform camera;

    void Awake()
    {
        camera = Camera.main.transform;
    }

    private void LateUpdate() 
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(camera);
                break;
            case Mode.LookAtInverted:
                Vector3 dirFromCamera = transform.position - camera.position;
                transform.LookAt(transform.position + dirFromCamera);
                break;
            case Mode.CameraForward:
                transform.forward = camera.forward;
                break;
            case Mode.CameraForwardInverted:
                transform.forward = -camera.forward;
                break;
        }
    }
}
