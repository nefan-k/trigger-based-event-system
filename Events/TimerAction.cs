using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAction : AbstractAction
{
    public float duration = 1f;
    public override void Activate()
    {
        StartCoroutine(Process());
    }

    IEnumerator Process()
    {
        yield return new WaitForSeconds(duration);
        if (chain != null)
            chain.Activate();
    }
}
