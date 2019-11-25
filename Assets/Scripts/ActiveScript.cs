using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Este Script lo que hace es basicamente activar o desactivar
    los objetos. Es una cuestión de estética para ocultar el menu en
    este caso y poder visualizarlo cuando se haga click en el objeto
    Este objeto va dentro del GameObject Canvas
*/

public class ActiveScript : MonoBehaviour
{
    /* Este objeto será el CANVAS*/
    public GameObject obj;

    void Start()
    {
        obj.SetActive(false); 
    }
}
