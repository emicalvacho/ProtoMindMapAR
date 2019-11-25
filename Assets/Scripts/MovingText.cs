using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    El script hace acciones referidas al Texto.
    Lo va a renombrar y va a permitir moverse 
    junto con el objeto asociado a el
    Este va dentro del Prefab Nodo
*/

public class MovingText : MonoBehaviour
{
    public Text txt; // Se arrastra en el inspector el Text de la UI
    
    /* Apenas inicia el texto este tiene el nombre del Nodo generado */
    void Start() {
        txt.text = this.name;
    }

    /* Permite que encada momento la posicion del texto se modifique de acuerdo
    a la posicion del objeto para que este lo siga */
    void Update () {
            Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
            txt.transform.position = namePose;
    }
}
