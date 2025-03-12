using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public bool persistant;
    public string id;
    public Color GizmosColor = 
		new Color(0.5f, 0.5f, 0.5f, 0.2f);
	public AbstractAction action;

	void OnDrawGizmos()
	{
	    Gizmos.color = GizmosColor;
	    Gizmos.DrawCube(transform.position, transform.localScale);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player")
			return;

		if (action != null)
			action.Activate();
		if(id != "")
			other.BroadcastMessage(id);

        // No second trigger
        if (!persistant)
            Destroy(this);
    }
}