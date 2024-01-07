using UnityEngine;
using UnityEngine.UI;

public class ChangeRigidbody : MonoBehaviour
{
    private Rigidbody _body;
    private Rigidbody2D _body2D;

    [SerializeField] private InputField _linearDrag, _angularDrag, _gravityScale, _mass, _drag, _friction, _bounciness;
    [SerializeField] private Dropdown _bodyType, _useGravity;
    [SerializeField] private GameObject _panel;

    public void GetRgb2D(Rigidbody2D body2D)
    {
        _body = null;
        _body2D = body2D;

        _mass.text = _body2D.mass.ToString();
        string bodyType = _body2D.bodyType.ToString();
        switch (bodyType)
        {
            case "Kinematic":
                _bodyType.value = 0;
                break;
            case "Static":
                _bodyType.value = 1;
                break;
            case "Dynamic":
                _bodyType.value = 2;
                break;
        }
        _angularDrag.text = _body2D.angularDrag.ToString();
        _gravityScale.text = _body2D.gravityScale.ToString();
        _linearDrag.text = _body2D.drag.ToString();
        _friction.text = _body2D.sharedMaterial.friction.ToString();
        _bounciness.text = _body2D.sharedMaterial.bounciness.ToString();
    }

    public void GetRgb(Rigidbody body)
    {
        _body2D = null;
        _body = body;

        _mass.text = _body.mass.ToString();
        _drag.text = _body.drag.ToString();
        _angularDrag.text = _body.angularDrag.ToString();
        _useGravity.value = _body.useGravity == true ? 0 : 1;
    }

    private void Start() => _panel.SetActive(false);

    public void ActivePanel(bool isPanelActive)
    {
        _panel.SetActive(isPanelActive);
        bool is2D = _body2D != null ? true : false;

        _bodyType.enabled = is2D;
        _useGravity.enabled = is2D;
        _gravityScale.enabled = is2D;
    }

    public void ChangeParametres()
    {
        if (_body != null)
        {
            _body.mass = float.Parse(_mass.text);
            _body.drag = float.Parse(_drag.text);
            _body.angularDrag = float.Parse(_angularDrag.text);
            _body.useGravity = _useGravity.options[GetComponent<Dropdown>().value].text == "Use" ? true : false;

            _body.GetComponent<Body>().isSelected = false;
        }
        else if(_body2D != null)
        {
            _body2D.mass = float.Parse(_mass.text);
            string type = _bodyType.options[_bodyType.GetComponent<Dropdown>().value].text;
            switch (type)
            {
                case "Kinematic":
                    _body2D.bodyType = RigidbodyType2D.Kinematic;
                    break;
                case "Static":
                    _body2D.bodyType = RigidbodyType2D.Static;
                    break;
                case "Dynamic":
                    _body2D.bodyType = RigidbodyType2D.Dynamic;
                    break;
            }
            _body2D.angularDrag = float.Parse(_angularDrag.text);
            _body2D.gravityScale = float.Parse(_gravityScale.text);
            _body2D.drag = float.Parse(_linearDrag.text);
            _body2D.sharedMaterial.friction = float.Parse(_friction.text);
            _body2D.sharedMaterial.bounciness = float.Parse(_bounciness.text);

            _body2D.GetComponent<Body>().isSelected = false;
        }

        _body = null; _body2D = null;
        _panel.SetActive(false);
    }
}
