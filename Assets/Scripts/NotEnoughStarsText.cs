using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughStarsText : MonoBehaviour
{
    // Start is called before the first frame update
    public void Spawn(Vector2 position)
    {
        transform.position = position;
        transform.Translate(100*Vector2.up * Time.deltaTime);
        //transform.position = new Vector2(-5, -5);
    }
}
