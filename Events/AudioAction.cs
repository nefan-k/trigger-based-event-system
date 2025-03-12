using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAction : AbstractAction
{
    public override void Activate()
    {
        GetComponent<AudioSource>().Play();
        if(chain != null)
            chain.Activate();
    }
}
