using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public string id;
    public AbstractAction action;
    public ManagerFlickering manager;

    void Start()
    {
        if (manager == null)
            manager = GetComponent<ManagerFlickering>();
    }

    void Update()
    {
        if(!manager.isOver)
            return;

        if (action != null)
            action.Activate();
        if (id != "")
            transform.root.BroadcastMessage(id);
    }
}
