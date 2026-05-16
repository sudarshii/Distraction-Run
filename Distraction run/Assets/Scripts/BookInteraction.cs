using UnityEngine;

public class BookInteraction : MonoBehaviour
{
    public Transform book;
    public GameObject interactText;

    public float interactionDistance = 3f;

    private bool bookUsed = false;

    void Start()
    {
        interactText.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, book.position);

        if (distance <= interactionDistance && !bookUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FocusManager.instance.ChangeFocus(40);

                interactText.SetActive(false);

                bookUsed = true;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}