using UnityEngine;
using TMPro;
using System.Collections;

public class CoffeeInteraction : MonoBehaviour
{
    public Transform coffee;
    public GameObject interactText;
    public TMP_Text pointText;

    public float interactionDistance = 3f;
    public int focusPoints = 100;
    public int coffeeBoost = 30;

    private bool coffeeUsed = false;

    void Start()
    {
        interactText.SetActive(false);

        pointText.text = "";
        pointText.gameObject.SetActive(false);
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

                StartCoroutine(ShowPoints());

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

    IEnumerator ShowPoints()
    {
        pointText.gameObject.SetActive(true);

        pointText.text = "+" + coffeeBoost + " Focus";

        yield return new WaitForSeconds(2f);

        pointText.gameObject.SetActive(false);
    }
}