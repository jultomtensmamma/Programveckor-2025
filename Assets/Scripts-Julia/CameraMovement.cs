using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
   
{
    [SerializeField]
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Player.transform.position + new Vector3(0, 0, -10);
        transform.position = targetPosition;
    }
}
