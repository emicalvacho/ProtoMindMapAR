using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Este script va dentro de cada Spawner y de los botones del
    Canvas, para poder disparar los eventos necesarios y realizar
    las acciones de Agregar, Eliminar y Pintar por el momento
*/

public class EventScript : MonoBehaviour
{
    private GameObject obj; // objeto aux

    // Es el script que me va a permitir actuar sobre los nodos seleccionados
    public SaveObjScript saveObjScript; 
    // Es el script que me va a permitir agregar nodos nuevos
    public SpawnScript spawnScript;

    /* Trae el objeto seleccionado para que sea usado por los otros
    eventos */
    public bool InitObject(){
        if (saveObjScript.ObjSelect==null){
            return false;
        }
        Debug.Log("OBJETO A ACCIONAR ES: " + saveObjScript.ObjSelect.name);
        obj = saveObjScript.ObjSelect;
        return true;
    }
    
    // Cambia el color del objeto seleccionado desde el Boton Add 
    public void ChangeColor(){
        if(InitObject()){
            Renderer rend = obj.GetComponent<Renderer>();
            rend.material.color = Random.ColorHSV();
        }
        else{
            Debug.Log("No se ha seleccionado ningun objeto para pintar.");
        }
    }

    // Elimina el objeto seleccionado desde el Boton Remove
    public void RemoveObj(){
        if(InitObject()){
            InitObject();
            if(obj.name == "Nodo 1"){
                Debug.Log("No se puede eliminar el nodo principal");
            }
            else{
                // Debug.Log("Cantidad de hijos de " + obj.name+": " + obj.transform.childCount);
                if(obj.transform.childCount != 0){
                    Debug.Log("No se puede eliminar este nodo porque tiene hijos");
                }
                else{
                    Destroy(GameObject.Find("Line "+obj.name));
                    Destroy(obj); // Destruye objetos en Unity
                    spawnScript.ContObj --; // Quito en uno la cantidad de objetos instanciados
                }
            }
        }
        else{
            Debug.Log("No se ha seleccionado ningun objeto para eliminar.");
        }
    }
}
