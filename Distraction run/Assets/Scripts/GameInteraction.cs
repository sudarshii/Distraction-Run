using UnityEngine;

public class GameInteraction : MonoBehaviour
{
    public Transform gameObjectItem;
    public GameObject interactText;

    public float interactionDistance = 3f;

    bool used = false;

    void Start()
    {
        interactText.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, gameObjectItem.position);

        if (distance <= interactionDistance && !used)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FocusManager.instance.ChangeFocus(-30);

                used = true;

                interactText.SetActive(false);
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}