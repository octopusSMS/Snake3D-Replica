using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public bool IsHead = false;

    public GameObject previouspart;

    [Min(0)]
    public float Speed;

    [SerializeField] private LayerMask layerMask;

    public Material[] SnakeMaterial;

    [HideInInspector]
    public Vector3 _previousposition;
    public GameControllerScript Game;
    

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
        if (IsHead)
            this.name = "Snake Head";
        else
            this.name = "Snake Body";
    }

    private void Update()
    {
        _previousposition = transform.position; //��������� ���������

        if (IsHead)
        {
            if (Input.GetMouseButton(0)) // ��� ������� ����� ������ ����
            {
                Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition); //�� ������ �������� ��� 
                if (Physics.Raycast(Ray, out RaycastHit rayCastHit, float.MaxValue, layerMask)) //������������ ����� ����������� ���� � ������� � layer=flore
                    transform.position = new Vector3(rayCastHit.point.x, 0.5f, transform.position.z); //������� ���������� �������
            }
            transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
        }
        else
        {
            Vector3 delta = transform.position - previouspart.GetComponent<SnakeScript>()._previousposition;
            transform.position -= delta * Speed * 4 * Time.deltaTime;
        }
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Speed = 0;

    }
}
