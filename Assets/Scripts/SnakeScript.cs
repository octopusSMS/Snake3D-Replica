using Unity.VisualScripting;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public bool IsHead = false;

    public GameObject previouspart;

    [Min(0)]
    public float Speed;

    [SerializeField] private LayerMask layerMask;

    public Material[] SnakeMaterial;

    public Vector3 _previousposition;
    private void UpdateMaterial() //метод для изменения цвета частей змеи
    {
        GetComponent<Renderer>().sharedMaterial = IsHead ? SnakeMaterial[0] : SnakeMaterial[1];
    }

    private void OnValidate() //метод Unity для внесения изменений прямо в окне редактора, без запуска игры
    {
        UpdateMaterial();
    }

    private void Awake()
    {
        UpdateMaterial();
    }

    private void Update()
    {
        _previousposition = transform.position; //сохраняем положение


        if (Input.GetMouseButton(0)&& IsHead) // при нажатии левой кнопки мыши
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition); //из камеры вылетает луч 
            if (Physics.Raycast(Ray, out RaycastHit rayCastHit, float.MaxValue, layerMask)) //определяется точка пересечения луча и объекта с layer=flore
                transform.position = new Vector3(rayCastHit.point.x, 0.5f, transform.position.z); //позиция передается объекту
            
        }

        if (IsHead)
            transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
        else
        {
            Vector3 delta = transform.position - previouspart.GetComponent<SnakeScript>()._previousposition; 
            transform.position -= delta*Speed*2*Time.deltaTime;
        }
        
                
    }
}
