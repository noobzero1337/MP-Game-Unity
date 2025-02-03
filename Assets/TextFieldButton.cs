using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TextFieldButton: MonoBehaviour {


    public string theName;
    public GameObject inputField;
    public GameObject textDisplay;



    public void GetInputOnClickHandler()
    {
        Debug.Log("Log input");
    }


}
