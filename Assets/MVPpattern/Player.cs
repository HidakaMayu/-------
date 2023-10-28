using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]PlayerData playerData;
    Shops shops;

    Rigidbody rb;

    [SerializeField] float speed = 20;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("ok");
            playerData.Damage(1);
        }
        else if (collision.gameObject.tag == "Item")
        {
            Debug.Log("ok");
            playerData.ItemCare(2);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("ok");
            playerData.GetCoin(10);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Shop")
        {
            shops.OpenShop();
            Debug.Log("open");
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        
        rb.AddForce(new Vector3 (horizontal, 0, vertical), ForceMode.Impulse);
    }
}
