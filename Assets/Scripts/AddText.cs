using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddText : MonoBehaviour
{
    public Text ftext;
    public InputField inputField;

    public void SetText(){
        ftext.text = inputField.text;
    }
}
