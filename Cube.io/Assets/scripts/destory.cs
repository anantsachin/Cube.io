using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory : MonoBehaviour
{
    public GameObject destroyedVersion;

     void OnCollisionEnter()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);

        Destroy(gameObject);
    }




}
