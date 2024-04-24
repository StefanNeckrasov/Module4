using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVL_Changer : MonoBehaviour
{
    public int LvLToLoaded;

    public void Click()
    {
        SceneManager.LoadScene(LvLToLoaded);
    }
}
