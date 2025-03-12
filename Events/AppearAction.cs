using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearAction : AbstractAction
{
    public bool isDisappearing;

    private void Awake()
    {
        gameObject.SetActive(isDisappearing);
    }

    public override void Activate()
    {
        gameObject.SetActive(!isDisappearing);
        if (chain != null)
            chain.Activate();
    }
}
