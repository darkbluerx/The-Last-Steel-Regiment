using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool isOpen = false;

    public void OpenDoor()
    {
        if (!isOpen)
        {
            StartCoroutine(DoorAnimationOpen());
        }
    }

    private IEnumerator DoorAnimationOpen()//ovi avautaan ylös/ y-akselin suuntaan
    {
        isOpen = true;
        float originalYpos = transform.position.y;
       
        while (originalYpos + 3f > transform.position.y)
        {
            Debug.Log("orginalYpos: "+originalYpos);//pysyy samana
            Debug.Log("y: " + transform.position.y); //-pienenee
            transform.Translate(Vector3.up * Time.deltaTime / 2);
            yield return null;
        }
    }

    //toimii, ovi avataan alas/ -y-akselin suuntaan
    //private IEnumerator DoorAnimationOpen()
    //{
    //    isOpen = true;
    //    float originalYpos = transform.position.y;

    //    while (transform.position.y > originalYpos - 2f)
    //    {
    //        Debug.Log("orginalYpos: " + originalYpos);//pysyy samana
    //        Debug.Log("y: " + transform.position.y); //-pienenee
    //        transform.Translate(Vector3.down * Time.deltaTime / 2);
    //        yield return null;
    //    }
    //}


    public void CloseDoor()//ei ole käytössä
    {
        float orginalYpos = transform.position.y;
        if (orginalYpos> transform.position.y)
        {
            transform.Translate(Vector2.up * Time.deltaTime / 2);
        } 
    }
}
