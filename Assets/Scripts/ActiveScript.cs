using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScript : MonoBehaviour
{
    public GameObject obj;

    void Start()
    {
        obj.SetActive(false);
    }
}
