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
        if (Input.GetMouseButton(0)) // при нажатии левой кнопки мыши
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition); //из камеры вылетает луч 
            if (Physics.Raycast(Ray, out RaycastHit rayCastHit, float.MaxValue, layerMask)) //определяется точка пересечения луча и объекта с layer=flore
                transform.position = new Vector3(rayCastHit.point.x, 0.5f, transform.position.z); //позиция передается объекту
            
        }

        previouspartposition = transform;
        transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
                
    }
}
