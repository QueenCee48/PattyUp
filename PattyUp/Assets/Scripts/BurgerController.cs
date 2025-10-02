using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BurgerController : MonoBehaviour
{
    Transform topBun;
    Transform patty;
    Transform lettuce;
    Transform tomatoes;
    Transform onions;
    Transform pickles;
    Transform cheese;
    Transform egg;
    Transform bacon;

    public string[] prepared;

    // Start is called before the first frame update
    void Start()
    {
        topBun = GameObject.FindGameObjectWithTag("TopBun").GetComponent<Transform>();
        patty = GameObject.FindGameObjectWithTag("Patty").GetComponent<Transform>();
        lettuce = GameObject.FindGameObjectWithTag("Lettuce").GetComponent<Transform>();
        tomatoes = GameObject.FindGameObjectWithTag("Tomatoes").GetComponent<Transform>();
        onions = GameObject.FindGameObjectWithTag("Onions").GetComponent<Transform>();
        pickles = GameObject.FindGameObjectWithTag("Pickles").GetComponent<Transform>();
        cheese = GameObject.FindGameObjectWithTag("Cheese").GetComponent<Transform>();
        egg = GameObject.FindGameObjectWithTag("Egg").GetComponent<Transform>();
        bacon = GameObject.FindGameObjectWithTag("Bacon").GetComponent<Transform>();

        prepared = new string[] { };
    }

    // Update is called once per frame
    void Update()
    {
        // clickPosition = Input.GetButtonDown("Fire1").position;

        // if (clickPosition == topBun.position)
        // {
        //     prepared = AddIngredient(prepared, "Top Bun");
        // }
        // else if (Input.GetButtonDown("Patty"))
        // {
        //     prepared = AddIngredient(prepared, "Patty");
        // }
        // else if (Input.GetButtonDown("Lettuce"))
        // {
        //     prepared = AddIngredient(prepared, "Lettuce");
        // }
        // else if (Input.GetButtonDown("Tomatoes"))
        // {
        //     prepared = AddIngredient(prepared, "Tomatoes");
        // }
        // else if (Input.GetButtonDown("Onions"))
        // {
        //     prepared = AddIngredient(prepared, "Onions");
        // }
        // else if (Input.GetButtonDown("Pickles"))
        // {
        //     prepared = AddIngredient(prepared, "Pickles");
        // }
        // else if (Input.GetButtonDown("Cheese"))
        // {
        //     prepared = AddIngredient(prepared, "Cheese");
        // }
        // else if (Input.GetButtonDown("Egg"))
        // {
        //     prepared = AddIngredient(prepared, "Egg");
        // }
        // else if (Input.GetButtonDown("Bacon"))
        // {
        //     prepared = AddIngredient(prepared, "Bacon");
        // }
    }

    void OnMouseDown()
    {
        
    }

    public string[] AddIngredient(string[] current, string ingredient)
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
