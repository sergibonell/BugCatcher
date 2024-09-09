using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] string tagTrigger;
    [SerializeField] GameObject insect;

    public GameObject GetObject()
    {
        return insect;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagTrigger))
        {
            insect = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (insect == other.gameObject)
        {
            insect = null;
        }
    }
}
