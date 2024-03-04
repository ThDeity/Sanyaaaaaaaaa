using UnityEngine;

public class ChargedBody : MonoBehaviour
{
    public float Charge, k, massa;
    [SerializeField] private float _forwardForce, _eForce;
    private Rigidbody2D _rg2D;
    private Transform _electricField;

    private void Start()
    {
        _rg2D = GetComponent<Rigidbody2D>();
        _electricField = ElectricFieldInfo.ElectricField.transform;
    }

    private void FixedUpdate()
    {
        _rg2D.AddForce(transform.right * _forwardForce, ForceMode2D.Force);

        if (StaticVariables.IsEConst)
        {
            _eForce = StaticVariables.EValue * Charge / massa;
            _rg2D.AddForce(_electricField.up * _eForce * Time.deltaTime * Time.deltaTime, ForceMode2D.Force);
        }
        else
        {
            float r = Vector2.Distance(transform.position, _electricField.position);
            _eForce = Charge / r * k;
            _rg2D.AddForce(_electricField.up * _eForce, ForceMode2D.Force);
        }
    }
}
