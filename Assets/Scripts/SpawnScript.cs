using UnityEngine;
using System.Collections;
 
// Paquete para manejar la camara de Vuforia
using Vuforia;
 
public class SpawnScript : MonoBehaviour {    

    // Para poner en el inspector el GameObject que se quiere instanciar
    public GameObject obj;
     
    // Cantidad de objetos a instanciar
    public int mTotalObjetos = 10;

    // Para tener a los cubos en el escenario
    private GameObject[] mObjs;

    // Contador de objetos
    private int contObj;

    public int ContObj{get;set;}

    // Inicio de la app
    public bool inicio = false;
    public bool posInicial = true;
 
    void Start () {
        // Inicializar el array de objetos con la cantidad maxima pasada
        mObjs = new GameObject[ mTotalObjetos ];
        contObj = 0;
        if(inicio){
            Spawn();
        }
    }
    
    // Spawneo un objeto
    private GameObject SpawnElement() 
    {
        // Spawneo un objeto en una posicion Random
        GameObject objInstanciado = Instantiate(obj) as GameObject;

        // Hacer que el elemento sea hijo de Spawner        
        objInstanciado.transform.SetParent(GameObject.Find("Spawner").transform);

        // Cambio la escala del objeto
        objInstanciado.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // Cambio la posicion del objeto
        objInstanciado.transform.localPosition = new Vector3(Random.Range(-0.24f,0.34f),Random.Range(0.10f,-0.10f),Random.Range(0.15f,-0.15f));

        // Cuento la cantidad de objetos instanciados
        ContObj ++;

        // Le cambio el nombre del objeto para poder identificarlo luego
        objInstanciado.name = "Cube " + ContObj;
        
        return objInstanciado;
    }    

    public void Spawn(){
        if (ContObj == mTotalObjetos){
            Debug.Log("No se puede instanciar mas objetos");
        }
        else{
            SpawnElement();
        }
    }
}