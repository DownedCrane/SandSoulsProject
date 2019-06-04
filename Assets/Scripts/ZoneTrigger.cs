using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    // Объект для активации

    [Header("Таг игрока, обычно Player")]
    public string tag;

    [Header("Если отмечено, то активируем объект")]
    public bool state;

    [Header("Объект для активации (со скриптами)")]
    public GameObject myObject;
    // Start is called before the first frame update


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            myObject.gameObject.SetActive(state);
            
        }


    }
}
