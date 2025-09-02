using UnityEngine;

public class RotateItem : MonoBehaviour
{
    [SerializeField] private bool floating = true;
    [SerializeField] private float floatAmplitude = 0.25f;
    [SerializeField] private float floatSpeed = 1f;
    
    
    Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Estilo DOOM da camera
        transform.forward = Camera.main.transform.forward;

        if (floating)
        {
            float moveY = Mathf.Sin(Time.deltaTime * floatSpeed) * floatAmplitude;
            transform.position = new Vector3(transform.position.x, moveY, transform.position.z);
        }
    }
}
