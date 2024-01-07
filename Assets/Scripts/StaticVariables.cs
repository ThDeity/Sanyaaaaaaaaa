using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    public static bool IsBodyChosen = false;
    public static ChangeRigidbody ChangeRigidbodyObj;
    public static GameObject ActiveBody;
    public static BodyTransform BodyTransform;

    public void Start()
    {
        ChangeRigidbodyObj = FindObjectOfType<ChangeRigidbody>();
        BodyTransform = FindObjectOfType<BodyTransform>();
    }

    public static void ChooseBody(GameObject body, bool active)
    {
        if (body != null)
        {
            ActiveBody = body;
            BodyTransform.body = body.transform;
            IsBodyChosen = active;
        }

        if (active)
        {
            if (body.TryGetComponent(out Rigidbody rgb))
                ChangeRigidbodyObj.GetRgb(rgb);
            else
                ChangeRigidbodyObj.GetRgb2D(body.GetComponent<Rigidbody2D>());
        }

        ChangeRigidbodyObj.ActivePanel(active);
    }
}
