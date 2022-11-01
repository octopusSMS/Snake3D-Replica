using Unity.VisualScripting;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public bool IsHead = false;

    public Transform previouspartposition;

    [Min(0)]
    public float Speed;

    [SerializeField] private LayerMask layerMask;

    public Material[] SnakeMaterial;
    private void UpdateMaterial() //����� ��� ��������� ����� ������ ����
    {
        GetComponent<Renderer>().sharedMaterial = IsHead ? SnakeMaterial[0] : SnakeMaterial[1];
    }

    private void OnValidate() //����� Unity ��� �������� ��������� ����� � ���� ���������, ��� ������� ����
    {
        UpdateMaterial();
    }

    private void Awake()
    {
        UpdateMaterial();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) // ��� ������� ����� ������ ����
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition); //�� ������ �������� ��� 
            if (Physics.Raycast(Ray, out RaycastHit rayCastHit, float.MaxValue, layerMask)) //������������ ����� ����������� ���� � ������� � layer=flore
                transform.position = new Vector3(rayCastHit.point.x, 0.5f, transform.position.z); //������� ���������� �������
            
        }

        previouspartposition = transform;
        transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
                
    }
}
