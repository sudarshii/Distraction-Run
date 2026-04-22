using UnityEngine;
using System.Collections;

namespace SojaExiles
{
    public class DoorOpenClose : MonoBehaviour
    {
        public Animator openandclose;
        public bool open = false;
        public Transform Player;
        public float distance = 5f;

        void Update()
        {
            if (Player == null) return;

            float dist = Vector3.Distance(Player.position, transform.position);

            if (dist < distance)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!open)
                    {
                        StartCoroutine(opening());
                    }
                    else
                    {
                        StartCoroutine(closing());
                    }
                }
            }
        }

        IEnumerator opening()
        {
            Debug.Log("Opening door");
            openandclose.Play("OpeningStall");
            open = true;
            yield return new WaitForSeconds(0.5f);
        }

        IEnumerator closing()
        {
            Debug.Log("Closing door");
            openandclose.Play("ClosingStall");
            open = false;
            yield return new WaitForSeconds(0.5f);
        }
    }
}