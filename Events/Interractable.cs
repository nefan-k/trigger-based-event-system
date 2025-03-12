using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{
    [Range(0, 10f)]
    public float radius = 3f;

    public bool persistant;
    public string id;
    public AbstractAction action;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Interracted(GameObject other)
    {
        if (Vector3.Distance(other.transform.position, transform.position) > radius)
            return;

        if (action != null)
            action.Activate();
        if (id != "")
            other.BroadcastMessage(id);

        // No second interraction
        if(!persistant)
            Destroy(this);
    }
}
