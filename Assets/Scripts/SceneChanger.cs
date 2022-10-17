using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void SwitchScene()
    {
        if (GameManager.Instance.isNameSet)
        {
            SceneManager.LoadScene(1);

        }
        else throw new UnityException("Please set your name.");
    }
}
