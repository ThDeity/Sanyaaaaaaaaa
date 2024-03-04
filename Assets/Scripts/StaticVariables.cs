using UnityEngine;
using UnityEngine.UI;

public class StaticVariables : MonoBehaviour
{
    public static bool IsBodyChosen = false, IsEConst = false;
    public static ChangeRigidbody ChangeRigidbodyObj;
    public static GameObject ActiveBody;
    public static BodyTransform BodyTransform;
    [SerializeField] private bool _isKinematic;
    static bool isKinematic;
    public static float EValue;

    public void Start()
    {
        isKinematic = _isKinematic;

        if (_isKinematic)
            ChangeRigidbodyObj = FindObjectOfType<ChangeRigidbody>();

        BodyTransform = FindObjectOfType<BodyTransform>();
    }

    public void ChangeE(Dropdown dropdown)
    {
        IsEConst = dropdown.value == 0 ? false : true;
        if (IsEConst)
        {
            ElectricFieldInfo.ElectricField.gameObject.SetActive(false);
            InputField input = FindObjectOfType(typeof(InputField)) as InputField;
            EValue = int.Parse(input.text.ToString());
        }
        else
            ElectricFieldInfo.ElectricField.gameObject.SetActive(true);
    }

    public static void ChooseBody(GameObject body, bool active)
    {
        if (body != null)
        {
            ActiveBody = body;
            BodyTransform.body = body.transform;
            IsBodyChosen = active;
        }

        if (active && isKinematic)
        {
            if (body.TryGetComponent(out Rigidbody rgb))
                ChangeRigidbodyObj.GetRgb(rgb);
            else
                ChangeRigidbodyObj.GetRgb2D(body.GetComponent<Rigidbody2D>());
        }


        if (isKinematic)
            ChangeRigidbodyObj.ActivePanel(active);
    }
}
