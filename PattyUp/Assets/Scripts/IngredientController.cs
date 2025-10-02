using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    BurgerController burgerController;
    public GameObject ingredientObject;
    GameObject ingredientClone;
    public Vector3 clonePosition;

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
        if (burgerController != null && Time.timeScale != 0)
        {
            burgerController.AddIngredientByName(ingredientName);
            Debug.Log("Added: " + ingredientName);

            ingredientClone = Instantiate(ingredientObject, ingredientObject.transform.position, ingredientObject.transform.rotation);
            ingredientClone.SetActive(true);
        }
        
    }
}
