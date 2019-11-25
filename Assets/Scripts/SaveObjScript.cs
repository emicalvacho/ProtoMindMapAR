using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/*
    Este Script va dentro de GameObjectManager. El mismo guardará 
    la información de los mensajes hará de intermediario entre 
    los objetos para que se comuniquen entre si. Utilizara el concepto
    de Handlers (ver teoria de C#)
*/

public class SaveObjScript : MonoBehaviour
{
    // Creo los objetos 
    private GameObject objSelect;
    private GameObject objCollider;

    // Armo las propiedades de losobjetos (se puede usar el "foquito" de Visual Studio)
    public GameObject ObjSelect { get => objSelect; set => objSelect = value; }
    public GameObject ObjCollider { get => objCollider; set => objCollider = value; }

    /*
        OnEnable y OnDisable son dos eventos propios de Unity que me indican cuando los
        objetos son Activados y Desactivados.
        En este caso me sirven para consumir (+=) o destruir (-=) delegados
    */
    void OnEnable() {
        SelectScript.OnObject += HandlerOnObject;
        DetectCollisionScript.OnColl += HandlerOnCollider;
    }   

    void OnDisable() {
        SelectScript.OnObject -= HandlerOnObject;
        DetectCollisionScript.OnColl -= HandlerOnCollider;
    }

    // Es el manejador de objetos seleccionados -> guarda el objeto seleccionado 
    void HandlerOnObject(GameObject obj){
        Debug.Log("OBJETO SELECCIONADO: " + obj.name);
        ObjSelect = obj;
    }

    // Es el manejador de objetos colisionados -> guarda el objeto que colisionó
    void HandlerOnCollider(GameObject obj){
        Debug.Log("OBJETO COLISIONADOR: " + obj.name);
        ObjCollider = obj;
    } 
    /* Por el momento, este ultimo no se aplica pero la idea era que los elementos
    no se solaparan y usaran las fisicas de colliders para autosepararse cuando se
    creen */
}
