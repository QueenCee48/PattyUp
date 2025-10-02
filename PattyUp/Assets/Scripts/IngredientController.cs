using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    BurgerController burgerController;
    // OrderController orderController;
    public string ingredientName;
    // public int ingredientCount;
    // string[] order;

    // Start is called before the first frame update
    void Start()
    {
        burgerController = GameObject.Find("BurgerDisplay").GetComponent<BurgerController>();
        // orderController = GameObject.Find("Canvas").GetComponent<OrderController>();

        // order = orderController.GetOrder();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (burgerController != null && Time.timeScale != 0) // && ingredientCount < 10)
        {
            burgerController.AddIngredientByName(ingredientName);
            // ingredientCount++;
            Debug.Log("Added: " + ingredientName);
        }
        // else if (burgerController != null && Time.timeScale != 0 && ingredientCount == 10)
        // {
        //     if (ingredientName == "Top Bun")
        //     {
        //         burgerController.AddIngredientByName(ingredientName);
        //         ingredientCount = 0;
        //         Debug.Log("Added: " + ingredientName);
        //     }
        // }
    }
}
