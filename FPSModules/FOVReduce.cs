using UnityEngine;

[ExecuteInEditMode]
public class FOVReduce : MonoBehaviour
{
    Camera camera;
    public float defaultFOV = 60;
    public float maxZoomFOV = 15;

    public float duration = 3f;
    private float _currentTime = 0;


    void Awake()
    {
        // Get the camera on this gameObject and the defaultZoom.
        camera = GetComponent<Camera>();
        if (camera)
        {
            defaultFOV = camera.fieldOfView;
        }
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime > duration)
            camera.fieldOfView = defaultFOV;
    }

    void ReduceFOV()
    {
        _currentTime = 0;
        camera.fieldOfView = maxZoomFOV;
    }
}
