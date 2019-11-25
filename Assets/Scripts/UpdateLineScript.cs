using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Este script va dentro del prefab LineRenderer.
    Me permite actualizar la posicion de la linea
    cada vez que un Nodo se mueve lugar
*/
public class UpdateLineScript : MonoBehaviour
{
    LineRenderer line; // Objeto auxiliar LineRenderer

    private Transform parentTransform; // Posicion aux del padre
    private Transform childTransform; // Posicion aux del hijo

    private Vector3[] positions = new Vector3[2]; // Arreglo de dos posiciones

    /*
        Este inicializador lo que hace es recibir el Transform del padre y del hijo, ademas
        del nombre del objeto LineRenderer instanciado previamente
    */
    public void Initialize (Transform parentTransform, Transform childTransform, string newName)
    {
        name = newName; // Le agrego el nuevo nombre

        if(!line) line = GetComponent<LineRenderer>(); // Si la linea no existe la obtengo desde un componente

        // Inicializo los Transforms del padre y del hijo
        this.parentTransform = parentTransform;
        this.childTransform = childTransform;

        // Configuro la cantidad de puntos de referencia que va a tener el LineRenderer
        line.positionCount = 2;
    }

    /* Update me va actualizar por frame la posicion del LineRenderer segun la ubicación
    del padre y del hijo configurando el destino y el fin */
    private void Update()
    {
        // Controlo si existe los Transforms del padre y del hijo
        if(parentTransform != null && childTransform != null){
            positions[0] = parentTransform.position;
            positions[1] = childTransform.position; 
            line.SetPositions(positions); // Seteo las posiciones de destino y fin directamente con el arreglo
        }
    }
}
