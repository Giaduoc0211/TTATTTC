using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trump : MonoBehaviour
{
        
    [SerializeField] private FixedJoystick _joystick;
    private Animation anim;
    private Rigidbody _rigidbody;
    [SerializeField]
    private GameObject _telemetry;
    private Telemetry telemetry;
    [SerializeField]
    private AudioSource audio;
    public float jumpForce = 10;
    public float zoomSpeed = 1.5f;
    public float minScale = 0.5f;
    public float maxScale = 2.0f;
    private Vector3 originalScale;
    public void Jump()
    {
        _rigidbody.mass = 0.3f;
        _rigidbody.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        _rigidbody.useGravity = true;   
    }

    public void ZoomIn()
    {
        Vector3 newScale = transform.localScale * zoomSpeed;
        newScale = Vector3.Max(newScale, originalScale * minScale);
        newScale = Vector3.Min(newScale, originalScale * maxScale);
        transform.localScale = newScale;
    }

    public void ZoomOut()
    {
        Vector3 newScale = transform.localScale / zoomSpeed;
        newScale = Vector3.Max(newScale, originalScale * minScale);
        newScale = Vector3.Min(newScale, originalScale * maxScale);
        transform.localScale = newScale;
    }

    void Start()
    {
        
        telemetry = _telemetry.GetComponent<Telemetry>();
        _rigidbody = GetComponent<Rigidbody>();
        anim= GetComponent<Animation>();
        originalScale = transform.localScale;
    }
      
    void Update()
    {
       
        float x = _joystick.Horizontal;
        float y = _joystick.Vertical;
        Vector3 movement = new Vector3(x, 0, y);
        _rigidbody.velocity = movement * 2f;
        if (x != 0 && y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
            if (telemetry.is_Colliding)
            {
                audio.Play();
            }
            else
            {
                audio.Stop();
            }
            
        }
        if(x!=0 || y!=0)
        {
            anim.Play("walk");
        }
        else
        {
            anim.Play("idle");
        }
    }
   
}