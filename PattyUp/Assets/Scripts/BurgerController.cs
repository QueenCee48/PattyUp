using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerController : MonoBehaviour
{
    string[] prepared;

    // Start is called before the first frame update
    void Start()
    {
        prepared = new string[] { };
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public string[] GetPrepared()
    {
        return prepared;
    }
}
