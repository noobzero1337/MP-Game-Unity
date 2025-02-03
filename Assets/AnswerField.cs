using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AnswerField : MonoBehaviour
{

    public InputField Answer;
    public Text output;

    public void buttonKlik()
    {

        Answer.gameObject.SetActive(true);
    }

    public void correct()
    {
        gameObject.SetActive(true);
    }

    public void wrong()
    {
        gameObject.SetActive(false);
    }


    public void GetInputOnClickHandler()
    {
        Debug.Log("Log input");
    }
}

