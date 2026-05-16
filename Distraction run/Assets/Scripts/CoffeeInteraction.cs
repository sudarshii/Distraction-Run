using UnityEngine;

public class CoffeeInteraction : MonoBehaviour
{
    public Transform coffee;
    public GameObject interactText;

    public float interactionDistance = 3f;

    private bool coffeeUsed = false;

    void Start()
    {
        interactText.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, coffee.position);

        if (distance <= interactionDistance && !coffeeUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FocusManager.instance.ChangeFocus(30);

                interactText.SetActive(false);

                coffeeUsed = true;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}