using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BurgerController : MonoBehaviour
{
    OrderController orderController;

    public string[] prepared;
    bool preparing;
    // public int ingCount;

    // Start is called before the first frame update
    void Start()
    {
        orderController = GameObject.Find("Canvas").GetComponent<OrderController>();

        prepared = new string[] { };
        preparing = true;
        // ingCount = 0;
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

        if (tempList.Contains("Top Bun")) // || ingCount >= 9)
        {
            // ingCount = 0;
            return current;
        }

        if (ingredient == "Top Bun") // || ingCount >= 9)
        {
            preparing = false;
            orderController.SetOrderCompleted(true);
            tempList.Insert(0, ingredient);
        }
        else if (tempList.Count < 9)
        {
            tempList.Insert(0, ingredient);
            // ingCount++;
        }

        return tempList.ToArray();
    }

    public string[] GetPrepared()
    {
        return prepared;
    }

    public bool GetPreparing()
    {
        return preparing;
    }

    public void ClearPrepared()
    {
        prepared = new string[] { };
        preparing = true;
    }
}
