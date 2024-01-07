using UnityEngine;

public class AddObject : MonoBehaviour
{
    [SerializeField] private GameObject _listOfObjects, _openButton, _obj;

    private void Start() => _listOfObjects.SetActive(false);

    public void CloseAndOpenPanel()
    {
        _listOfObjects.SetActive(!_listOfObjects.activeInHierarchy);
        _openButton.SetActive(!_listOfObjects.activeInHierarchy);
    }

    public void AddObj(GameObject obj)//Only 2D objects!
    {
        CloseAndOpenPanel();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _obj = Instantiate(obj, mousePos, Quaternion.identity);
        _obj.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        _obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
