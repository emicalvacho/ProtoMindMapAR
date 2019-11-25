using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
    Este script lo que hace es detectar cual es el objeto (nodo)
    que se ha seleccionado. Este script es componente del prefab
    Nodo
*/

public class SelectScript : MonoBehaviour
{
    public GameObject nodo; // En el inspector es el Nodo
    private GameObject findObj; // Auxiliar para encontrar un obj

    /* Eventos y delegados son conceptos de C# lo que hacen es 
    mandar mensajes entre objetos cuando se dispara el objeto. 
    Si hay un delegado y un evento creado en una clase es la misma
    que disparará el evento cuando ocurra la acción. El objeto que 
    consuma el mensaje tendrá que recibir el mismo con una función
    de la misma forma que indica el delegado */
    public delegate void _OnObject(GameObject obj);
    public static event _OnObject OnObject;

    // Esta bandera es para habilitar o no el menu
    private bool band = false;

    /* Esto es un evento propio de Unity que me permite determinar
    cuando un objeto hace click en un objeto, apartir de ello se
    realiza una acción */
    public void OnMouseDown()
    {
        findObj = FindInactiveObject("Canvas");
        if (findObj != null)
        {
            // Si no esta activado lo activa caso contrario lo desactiva 
            if (band)
            {
                findObj.SetActive(true);
                band = false;
            }
            else
            {
                findObj.SetActive(false);
                band = true;
            }
        }
        // Se dispara el evento y se pasa como mensaje el objeto nodo 
        if (OnObject != null)
            OnObject(nodo);
    }

    /* Es una funcion auxiliar que si se hace un script aparte
    es posible utilizarla de forma genérica, por el momento solo
    sirve para buscar un GameObject de con el nombre que se le pase
    por parametros */
    private GameObject FindInactiveObject(string findObj)
    {
        /* Busca objetos del tipo especificado pero la ventaja de de esta
        busqueda es que permite encontrar objetos desactivados algo que un
        simple Find() de GameObject no realiza */
        GameObject[] objs = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject o in objs)
        {
            if (o.name == findObj)
            {
                return o;
            }
        }
        Debug.Log("EL OBJECTO A BUSCAR NO EXISTE");
        return null;
    }
}
