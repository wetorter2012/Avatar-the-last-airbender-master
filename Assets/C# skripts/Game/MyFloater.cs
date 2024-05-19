using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFloater : MonoBehaviour
{
    [SerializeField] float floatUpSpeedLimit = 1.5f;
    [SerializeField] float floatUpSpeed = 1f;

    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 4)
        {
            float difference = (other.transform.position.y - transform.position.y) * floatUpSpeed;

            _rb.AddForce(new Vector3(0f, Mathf.Clamp((Mathf.Abs(Physics.gravity.y) * difference), 0, Mathf.Abs(Physics.gravity.y) * floatUpSpeedLimit), 0f), ForceMode.Acceleration);

            _rb.drag = 1.3f;
            _rb.angularDrag = 1f;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            _rb.drag = 0f;
            _rb.angularDrag = 0f;
        }
    }
}
