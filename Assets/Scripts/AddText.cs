using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Este Script se utilizó en un comienzo para modificar 
    el texto desde un input. Funciona, pero hay que integrarlo
    de nuevo a la escena.
    1) Crear en la UI Canvas un objeto UI de tipo Input
    2) Este script agregarlo dentro de Canvas
    3) Arrastrar en el Inspector los objetos Text e InputField
    porque el script lo va a requerir sino saldrá un error de 
    NullException
*/

public class AddText : MonoBehaviour
{
    public Text ftext;
    public InputField inputField;

    public void SetText(){
        ftext.text = inputField.text;
    }
}
