using UnityEngine;
using UnityEngine.EventSystems;

public class BodyTransform : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform body;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (body != null)
            body.GetComponent<RotatingBody>().enabled = true;
    }

    public void OnPointerUp(PointerEventData eventData) => body.GetComponent<RotatingBody>().enabled = false;
}
