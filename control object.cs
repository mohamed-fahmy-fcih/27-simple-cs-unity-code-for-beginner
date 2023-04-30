using UnityEngine;
using System.Collections;

public class ActiveObjects : MonoBehaviour
{
    void Update ()
    {
        if(Input.GetKey(KeyCode.L))
        gameObject.SetActive(false);
    }
}