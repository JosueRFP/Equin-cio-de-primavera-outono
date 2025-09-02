using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public UnityEvent OnZoom;



    private void Awake()
    {
        instance = this;
    }


}
