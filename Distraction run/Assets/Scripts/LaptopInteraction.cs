using UnityEngine;

public class LaptopInteraction : MonoBehaviour
{
    public Transform laptop;
    public GameObject interactText;

    public float interactionDistance = 3f;

    private bool laptopUsed = false;

    void Start()
    {
        interactText.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, laptop.position);

        if (distance <= interactionDistance && !laptopUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FocusManager.instance.ChangeFocus(30);

                interactText.SetActive(false);

                laptopUsed = true;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}