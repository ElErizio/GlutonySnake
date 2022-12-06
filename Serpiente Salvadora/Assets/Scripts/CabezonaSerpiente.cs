using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezonaSerpiente : MonoBehaviour
{
    enum Direction
    {
        up,
        down,
        left,
        right,
    }
    public List<Transform> Tail = new List<Transform>();
    Direction direction;
    [SerializeField] private float _framerate = 0.2f;
    [SerializeField] private float _step = 0.16f;
    [SerializeField] public Vector2 _horizontalRange;
    [SerializeField] public Vector2 _verticalRange;
    [SerializeField] public GameObject _tailPrefab;
    
    void Start()
    {
        InvokeRepeating("Move", _framerate, _framerate);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { 
            direction = Direction.up;
        }        
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        { 
            direction = Direction.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        { 
            direction = Direction.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        { 
            direction = Direction.right;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else if (col.CompareTag("Food"))
        {
            Tail.Add(Instantiate(_tailPrefab, Tail[Tail.Count - 1].position, Quaternion.identity).transform);
            col.transform.position = new Vector2(Random.Range(_horizontalRange.x, _horizontalRange.y), Random.Range(_verticalRange.x, _verticalRange.y));
        }
        // 
        else if (col.CompareTag("LepraFood"))
        {
            GetLepra();
            col.transform.position = new Vector2(Random.Range(_horizontalRange.x, _horizontalRange.y), Random.Range(_verticalRange.x, _verticalRange.y));
        }
    }

    void Move()
    {
        lastPosition = transform.position;
        Vector3 nextPosition = Vector3.zero;
        if (direction == Direction.up)
        {
            nextPosition = Vector3.up;
        }
        else if (direction == Direction.down)
        {
            nextPosition = Vector3.down;
        }
        else if (direction == Direction.left)
        {
            nextPosition = Vector3.left;
        }
        else if (direction == Direction.right)
        {
            nextPosition = Vector3.right;
        }
        nextPosition *= _step;
        transform.position += nextPosition;
        MoveTail();
    }
    Vector3 lastPosition;

    void MoveTail()
    {
        for (int i = 0; i < Tail.Count; i++ )
        {
            Vector3 temp = Tail[i].position;
            Tail[i].position = lastPosition;
            lastPosition = temp;
        }
    }

    public void GetLepra()
    {
        //Destroy(Tail[Tail.Count - 1].gameObject); // Esta linea de codigo si se activa destruye el "Pedazo de cuerpo" de la serpiente
        Tail.RemoveAt(Tail.Count - 1);
    }
}
