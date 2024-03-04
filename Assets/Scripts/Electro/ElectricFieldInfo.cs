using UnityEngine;

public class ElectricFieldInfo : MonoBehaviour
{
    public static GameObject ElectricField;
    [SerializeField] private GameObject _electricField;

    public void Awake() => ElectricField = _electricField;
}
