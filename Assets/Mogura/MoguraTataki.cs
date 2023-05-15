using UnityEngine;


public class MoguraTataki : MonoBehaviour
{
    Vector3 orgPos;
    [SerializeField] float moveDistance;
    [SerializeField] float moveSpeed;
    bool touch = false;
    [SerializeField]
    ScoreScript scoreScript;
        
    private void Awake()
    {
        
        orgPos = this.transform.position;
    }

    private void FixedUpdate()
    {
        this.transform.position = orgPos + new Vector3(0, 0, Mathf.Sin(Time.time * moveSpeed) * moveDistance);
    }
    void OnMouseDown()
    {
        scoreScript.Score++;
        touch = true;
        Debug.Log(1);
    }
    private void Update()
    {
        
        if (this.gameObject.transform.position.z <= 2)
        {
            touch = false;
        }
    }
}
