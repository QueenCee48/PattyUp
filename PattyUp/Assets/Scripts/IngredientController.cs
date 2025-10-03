using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    BurgerController burgerController;    
    GameObject ingredientClone;
    Transform hamburger;
    public GameObject ingredientObject;
    public Vector3 clonePosition;
    public string ingredientName;

    // Start is called before the first frame update
    void Start()
    {
        burgerController = GameObject.Find("BurgerDisplay").GetComponent<BurgerController>();
        hamburger = GameObject.Find("Hamburger").GetComponent<Transform>();
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

            ingredientClone = Instantiate(ingredientObject);
            ingredientClone.transform.SetParent(hamburger, false);
            ingredientClone.transform.localPosition = clonePosition;
            ingredientClone.SetActive(true);

            if (ingredientName == "Top Bun")
            {
                ingredientClone.tag = "TopBunClone";
                ingredientClone.AddComponent<CloneController>();
            }
            else
            {
                ingredientClone.tag = "Clone";
            }
        }
    }
}
