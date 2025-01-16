using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KattbollSkott : MonoBehaviour
{
    [SerializeField]
    GameObject Kattboll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) ;
        Instantiate(Kattboll, transform.position + new Vector3(1, 0, 0),Quaternion.identity);
    }
}
