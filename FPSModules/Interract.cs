using UnityEngine;

[ExecuteInEditMode]
public class Interract : MonoBehaviour
{
    private Camera camera;

    void Awake()
    {
        // Get the camera on this gameObject.
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Interractable interractable = hit.collider.GetComponent<Interractable>();
                if (interractable != null)
                {
                    interractable.Interracted(transform.parent.gameObject);
                }
            }
        }
    }
}
