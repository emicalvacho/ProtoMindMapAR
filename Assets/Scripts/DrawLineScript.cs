using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Este Script va dentro del SpawnerLine. Se va encargar de
    dibujar las lineas cuando un Nodo padre tenga hijos
*/

public class DrawLineScript : MonoBehaviour
{
    /*
        Hacer esto directamente de tipo UpdateLineRenderer
        para no necesitar GetComponent mas adelante, para ello
        desde el inspector solo arrastro LineRenderer para que
        se obtenga el componente de tipo Script
    */
    public UpdateLineScript prefab;

    /*
        Esta funcion dibuja directamente la linea desde el padre hasta el hijo
        como origen y destino. Si el padre es Spawner, es decir que es el 1er
        nodo entonces no dibujo nada. Caso contrario, instancio LineRenderer y lo
        inicializo con sus respectivos parámetros
    */
    public void DrawLine(GameObject parent, GameObject child)
    {
        if(parent.name == "Spawner") return;

        var newLine = Instantiate(prefab, parent.transform);   

        // Here you pass in all required information
        newLine.Initialize(parent.transform, child.transform, "Line " + child.name);
    }
}