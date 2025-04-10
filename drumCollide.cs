using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drumCollide : MonoBehaviour
{

    private void ColorSelf(Color newColor)
    {
        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        for (int childCount = 0; childCount < renderers.Length; childCount++)
        {
            renderers[childCount].material.color = newColor;
        }
    }


    // Called when drum collides with another object.
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected!  " + collision.gameObject.name);
        if (collision.gameObject.name == "drumstick")
        {
            StartCoroutine(PlaySound());
        }
    }

    // Called every frame drum is in contact with another object.
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Still colliding with: " + collision.gameObject.name);
    }

    // Called when drum stops colliding with another object.
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision ended with: " + collision.gameObject.name);
        if (collision.gameObject.name == "drumstick")
        {
            ColorSelf(Color.gray);
        }
    }

    IEnumerator PlaySound()
    {

        ColorSelf(Color.red); //need to replace with midi thing
        yield return new WaitForSeconds(.5f);
        ColorSelf(Color.gray);
        

    }

}
