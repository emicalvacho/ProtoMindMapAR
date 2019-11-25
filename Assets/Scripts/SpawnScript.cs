using UnityEngine;
using System.Collections;

/*
    Este quizas sea uno de los Scripts mas importates.
    La idea del mismo es generar nodos en posiciones aletorias.
    Este va dentro del GameObject Spawner
*/

public class SpawnScript : MonoBehaviour
{
    public GameObject obj; // En el inspector es el prefab "Nodo" (https://www.youtube.com/watch?v=vzjWzUENGzQ)
    public int mTotalObjetos = 10; /* Se limitó la cantidad de objetos para probar esta funcionalidad, puede jugar 
                                   con el número desde el Inspector de Unity puesto a que es un atributo público */
    private GameObject[] mObjs; // Arreglo de objetos generados

    private int contObj; // Un simple contador de objetos para controlar la cantidad generada
    public bool inicio = false; // Esta variable me indica si es el inicio de la aplicación o no
    public bool posInicial = true; // Esta variable me indica que si es el primer nodo (para ubicarlo al medio)

    /* Unity puede hacer una comunicación entre objetos con Eventos y Delegados (como en C#) y/o también con Scripts, 
    donde basicamente se usa un Script embebido en un GameObject o Prefab para eviar o recibir mensajes entre objetos */

    public SaveObjScript saveObj; // En el inspector va el script de GameObjectManager
    public DrawLineScript drawLine; // En el inspector va el script de SpawnerLine

    /* Esto en C# se lo conoce como PROPIEDAD, es una forma sencilla de hacer un GET y/o SET para
    un determinado atributo en una clase o script (https://www.youtube.com/watch?v=UEaByFLcb_o) */
    public int ContObj { get => contObj; set => contObj = value; }

    /* Esta funcion solo se ejeccuta una vez cuando comienza la aplicación. No es un contructor 
    pero se suele utilizar para asignar valores iniciales o instanciar objetos o atributos. */
    void Start()
    {
        mObjs = new GameObject[mTotalObjetos]; // Instancio el array
        ContObj = 0;
        if (inicio)
        { // Si inicio es True entonces comienzo a Spwanear (generar)
            Spawn();
        }
    }

    /* Genera un elemento */
    private GameObject SpawnElement()
    {
        // Si es el inicio entonces el Padre es Spawner
        if (inicio)
        {
            inicio = false;
            return confObj();
        }
        else
        {
            // Si se selecciono un elemento entonces genero su hijo
            if (saveObj.ObjSelect)
            {
                float posX = Random.Range(-2.4f, 3.4f);
                float posZ = Random.Range(1.5f, -1.5f);
                return confObj(saveObj.ObjSelect.name, posX, posZ);
            }
            else
            {
                Debug.Log("No se ha seleccionado ningun objeto");
                return null;
            }
        }
    }

    /* 
        Configuro el elemento generado 
        Parametros: 
            - nameParent: por defecto es el Spawner, pero sino se le pasa como padre el objeto seleccionado
            - posX: por defecto es 0, pero sino se le pasa un posicion aleatoria
            - posY: por defecto es 0, pero sino se le pasa un posicion aleatoria
    */
    public GameObject confObj(string nameParent = "Spawner", float posX = 0, float posZ = 0)
    {
        /* Si voy a crear un nuevo objeto debo instanciarlo pasandole como argumento el 
        tipo de GameObject que se va a instanciar, en este caso Nodo (que es un Prefab) 
        https://docs.unity3d.com/ScriptReference/Object.Instantiate.html */
        GameObject objInstanciado = Instantiate(obj, new Vector3(0, 9, 0), Quaternion.identity) as GameObject;

        /* Hay varias formas de Setear el padre de un objeto pero este caso lo que se hizo fue
        buscarlo por el nombre y usar SetParent() para configurarlo */
        objInstanciado.transform.SetParent(GameObject.Find(nameParent).transform);

        if (nameParent == "Spawner") // Si es Spwaner el padre entonces centro el Nodo al medio
        { 
            objInstanciado.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            /* Scale, Position, Rotation son atributos del componente Transform por lo cual si Setea el padre 
            y no uso Local, el nuevo objeto a instanciar aparece o muy lejos o muy chico o grande porque toma 
            otras posiciones y escalas. Para evitar esto se utiliza localScale, localPosition y localRotation
            https://docs.unity3d.com/ScriptReference/Transform-localScale.html */
            objInstanciado.transform.localScale = new Vector3(1, 1, 1);
            objInstanciado.transform.localPosition = new Vector3(posX, 0.09f, posZ);
            objInstanciado.transform.localRotation = Quaternion.identity;
        }

        ContObj++; // Incremento el contador
        objInstanciado.name = "Nodo " + ContObj; // Le asigno el nombre al objeto

        // Ahora dibujo una linea en el objeto pero si es el primero entonces no la dibujo
        if (objInstanciado.name == "nodo 1")
        {
            Debug.Log("El primer nodo no tiene padre");
        }
        else
        {
            // Dibujo la linea pasandole como parametro el objeto padre y el instanciado (hijo)
            drawLine.DrawLine(objInstanciado.transform.parent.gameObject, objInstanciado);
            Debug.Log("Objeto instanciado tiene padre? " + objInstanciado.transform.parent.gameObject.name);
        }

        return objInstanciado; // Devuelvo el objeto configurado
    }

    // Spawn genera un elemento y si la cantidad se sobrepasa se manda un mensaje
    public void Spawn()
    {
        if (ContObj == mTotalObjetos)
        {
            Debug.Log("No se puede instanciar mas objetos");
        }
        else
        {
            SpawnElement();
        }
    }
}