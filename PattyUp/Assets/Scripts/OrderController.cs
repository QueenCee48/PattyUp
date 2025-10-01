using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderController : MonoBehaviour
{
    string[] ingredients;
    string[] order;
    bool orderCompleted = false;
    Text orderText;

    // Start is called before the first frame update
    void Start()
    {
        ingredients = new string[] { "Top Bun", "Lettuce", "Tomatoes", "Onions", "Pickles", "Cheese", "Egg", "Bacon", "Patty" };
        order = new string[Random.Range(1, 9) + 2]; // +2 for top bun and patty

        orderText = GameObject.Find("OrderText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        while (!orderCompleted)
        {
            for (int i = 0; i < order.Length; i++)
            {
                if (i == 0)
                {
                    order[i] = ingredients[0]; // Top Bun
                }
                else if (i == order.Length - 1)
                {
                    order[i] = ingredients[8]; // Patty
                    orderCompleted = true;
                }
                else
                {
                    int randIndex = Random.Range(1, ingredients.Length); // Exclude Top Bun
                    order[i] = ingredients[randIndex];
                }

                if (i == order.Length - 1 && order[i] == "Patty")
                {
                    orderText.text += "- " + order[i] + "\n";
                }
                else
                {
                    orderText.text += "- " + order[i] + "\n";
                }
            }
        }
    }

    public string[] GetOrder()
    {
        return order;
    }

    public void setOrderCompleted(bool status)
    {
        orderCompleted = status;
    }
}
