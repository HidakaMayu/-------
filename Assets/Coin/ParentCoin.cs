using UnityEngine;

public class ParentCoin : MonoBehaviour
{
    [SerializeField] GameObject coinRoot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.transform.parent = coinRoot.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.transform.parent = null;
        }
    }

}