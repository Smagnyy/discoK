using UnityEngine;
using VContainer;

public class VContUnit : MonoBehaviour
{
    [Inject] MainGC mainGC;
    void Start()
    {
        mainGC.Test();
    }

    public void Test()
    {
        Debug.Log("Проверка синглтона?");
        transform.position = Vector3.back;
    }
}
