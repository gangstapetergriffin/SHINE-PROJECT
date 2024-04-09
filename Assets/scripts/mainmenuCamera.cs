using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuCamera : MonoBehaviour
{
    private float yes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yes += 1 * Time.deltaTime;
        transform.position = new Vector3(yes,0, -10);
    }
}
