using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
   
    [SerializeField]
    private GameObject _telemetry;
    private Telemetry telemetry;

    // Start is called before the first frame update
    void Start()
    {
        telemetry = _telemetry.GetComponent<Telemetry>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "podium")
        {
            telemetry.is_Colliding = true;
        }

       
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "podium")
        {
            telemetry.is_Colliding = false;
        }
    }

    void OnTriggerStay(Collider other)
    { }

    void OnTriggerExit(Collider other)
    { }
}
