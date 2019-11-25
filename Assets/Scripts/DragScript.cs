using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Este Script va dentro del Prefab Nodo.
    Lo que va a hacer este script es permitir
    al usuario mover los nodos y que estos cambien
    su posicion en tiempo real
*/

public class DragScript : MonoBehaviour
{
    private Vector3 mOffset; // Aux para indicar cuánto se movio el objeto
    private float mZCoord; // Aux para indicar las coordenadas del objeto en Z
    
    public GameObject nodo; // Es el prefab Nodo que se pasa desde el inspector

    /* Este es un evento propio de Unity que me permite detectar cuando el usuario
    mueve un objeto con el Mouse */
    void OnMouseDown()
    {
        // Busco la posicion de la coordenada z segun la camara 
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Calculo la distancia entre la posicion actual y cuanto se movio el mouse con el objeto
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    // Obtengo el mundo de puntos obtenidos con el movimiento del mouse 
    private Vector3 GetMouseAsWorldPoint()
    {
        // Coordenadas en pixeles del mouse en (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // Coordenada en z del GameObject en la pantalla
        mousePoint.z = mZCoord;

        // Convertir lo anterior en un mundo de puntos
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    // Evento propio de Unity que me permite cambiar la posicion del los objetos segun el Offset
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    } 
}