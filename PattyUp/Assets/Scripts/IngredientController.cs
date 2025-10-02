using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    BurgerController burgerController;
    public string ingredientName;

    // Start is called before the first frame update
    void Start()
    {
        burgerController = GameObject.Find("BurgerDisplay").GetComponent<BurgerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnMouseDown()
    {
        if (burgerController != null)
        {
            burgerController.AddIngredient(burgerController.prepared, gameObject.tag);
            Debug.Log("Added: " + gameObject.tag);
        }
    }
}
