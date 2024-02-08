using UnityEngine;

public class CameraFollower : MonoBehaviour
{ 
    public static CameraFollower Instance; 
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float Z;
    [SerializeField] private float Speed;
    [SerializeField] private bool Resizable = false;
    [SerializeField] private float minOrhtographicDistance = 1f;
    [SerializeField] private float sensetivity = 1f;
    [SerializeField] private float maxOrthographicSize = 10f;

    public Transform TargetTransform
    {
        get
        { return targetTransform; }
        set
        {
            targetTransform = value;
        }
    }

    private new Camera camera;
    private float minOrthographicSize = 3f;
    private void OnEnable()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        camera = gameObject.GetComponent<Camera>();
        minOrthographicSize = camera.orthographicSize;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Z);
        transform.position = Vector3.Lerp(transform.position, targetTransform.position, Speed * Time.deltaTime);
        if(Resizable)
        {
            camera.orthographicSize = minOrthographicSize + Mathf.Clamp((Vector2.Distance(camera.transform.position, targetTransform.position) - minOrhtographicDistance) * sensetivity, 0f, maxOrthographicSize);
        }   
    }
}