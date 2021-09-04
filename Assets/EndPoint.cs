using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] Meaassge meaassge;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        meaassge.Open();
    }
}
