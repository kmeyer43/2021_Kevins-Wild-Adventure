using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMenuMusic : MonoBehaviour
{
     void Awake()
    {
        GameObject A = GameObject.FindGameObjectWithTag("music");
        Destroy(A);
    }
}
