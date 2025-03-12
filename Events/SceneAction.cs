using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAction : AbstractAction
{
    public string name;

    public override void Activate()
    {
        if(name == null)
        {
            Debug.LogError("No Scene name set!");
            return;
        }

        SceneManager.LoadScene(name);
    }
}
