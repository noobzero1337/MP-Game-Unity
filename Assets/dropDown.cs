using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class dropDown : MonoBehaviour
{

    public TextMeshProUGUI Text;

    public void HandleInputData(int index)
    {

        switch(index)
        {
            case 0:
                Text.gameObject.SetActive(true);
                break;
            case 1:
                Text.gameObject.SetActive(false);
                break;
        }


    }
}
