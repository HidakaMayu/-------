using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeView : MonoBehaviour
{
    [SerializeField] List<GameObject> lifes;
    // Start is called before the first frame update
    
    public void SetLife(int lifeCount)
    {
        for(int i = 0; i< lifes.Count; i++)
        {
            GameObject life = lifes[i];
            life.SetActive(lifeCount > i);
        }
    }
}
