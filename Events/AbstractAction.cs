using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAction : MonoBehaviour
{
    public AbstractAction chain;
    public abstract void Activate();
}
