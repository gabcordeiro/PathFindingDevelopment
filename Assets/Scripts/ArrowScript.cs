using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    Animation shrink;

    private void Start()
    {
        shrink = gameObject.GetComponent<Animation>();
        shrink.Play();
        Destroy(this.gameObject, shrink.clip.length);
    }


}
