using UnityEngine;

public class PhoneInteraction : MonoBehaviour
{
    public Transform phone;
    public GameObject interactText;

    public float interactionDistance = 3f;

    private bool phoneUsed = false;

    void Start()
    {
        interactText.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, phone.position);

        if (distance <= interactionDistance && !phoneUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FocusManager.instance.ChangeFocus(-40);

                interactText.SetActive(false);

                phoneUsed = true;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}