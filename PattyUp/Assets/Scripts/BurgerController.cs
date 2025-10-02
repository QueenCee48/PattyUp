using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BurgerController : MonoBehaviour
{
    public string[] prepared;

    // Start is called before the first frame update
    void Start()
    {
        prepared = new string[] { };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddIngredientByName(string ingredient)
    {
        prepared = AddIngredient(prepared, ingredient);
    }

    string[] AddIngredient(string[] current, string ingredient)
    {
        List<string> tempList = new List<string>(current);
        tempList.Add(ingredient);
        return tempList.ToArray();
    }
    
    public string[] GetPrepared()
    {
        return prepared;
    }
}
