using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    public int Speed;
    public Camera mainCamera;
    public float rotationSpeed = 10f;
    Rigidbody rb;
    public float force;
    public Vector3 offset;
    public Animator anim;
    public GameObject Gun,ammo,gameovermenu;
    // Update is called once per frame
    private void Start()
    {
        rb= GetComponent<Rigidbody>();
    }
    void Update()
    {
        
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * Speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * Speed * Time.deltaTime); SAÐA SOLA HAREKET HOÞ DURMUYOR AMA ÝSTENÝRSE EKLENÝLÝR
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * Speed * Time.deltaTime);
        //}
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y));
        Vector3 targetDirection = mousePosition - transform.position;
        targetDirection.y = 0f;
        Gun.transform.rotation= Quaternion.LookRotation(targetDirection);
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection/*+offset*/);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.isKinematic = false;
            anim.SetInteger("state", 0);
            rb.velocity = targetDirection.normalized * Speed;
        }
        else
        {
            //gameObject.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            rb.isKinematic = true;
            anim.SetInteger("state", 1);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ammocln = Instantiate(ammo, Gun.transform.position, Quaternion.identity);
            ammocln.transform.GetComponent<Rigidbody>().AddForce(targetDirection * force, ForceMode.Acceleration);
            Destroy(ammocln,2);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy")) { 
            gameovermenu.SetActive(true);
        }
    }
}
