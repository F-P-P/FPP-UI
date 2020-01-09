using UnityEngine;
using System.Collections;

public class vPickupItem : MonoBehaviour
{
  
    public GameObject _particle;    

    void Start()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)            
                r.enabled = false;            


        }
    }
}