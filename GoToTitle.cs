using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitle : MonoBehaviour

{
    public void PushThisButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
