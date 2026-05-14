using UnityEngine;
using TMPro;

public class CoffeeInteraction : MonoBehaviour
{
    public Transform coffee;
    public GameObject interactText;
    public TMP_Text pointText;

    public float interactionDistance = 3f;
    public int focusPoints = 100;
    public int coffeeBoost = 10;

    private bool coffeeUsed = false;

    void Start()
    {
        interactText.SetActive(false);
        pointText.text = "";
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, coffee.position);

        if (distance <= interactionDistance && !coffeeUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                focusPoints += coffeeBoost;

                pointText.text = "+" + coffeeBoost + " Focus";

                interactText.SetActive(false);

                coffeeUsed = true;

                Debug.Log("Coffee Used!");
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}