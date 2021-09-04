using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meaassge : MonoBehaviour
{
    [SerializeField] InputSystem inputSystem;
    public void Open()
    {
        gameObject.SetActive(true);
        inputSystem.Close();
    }
    public void Confirm()
    {
        inputSystem.ReSet();
        gameObject.SetActive(false);
    }
    public void Cancel()
    {
        inputSystem.RecoverControl();
        gameObject.SetActive(false);
    }
}
