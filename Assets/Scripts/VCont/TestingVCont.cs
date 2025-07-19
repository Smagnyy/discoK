using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestingVCont : MonoBehaviour
{
    //[Inject] VContUnit vContUnit;
    [Inject] private IObjectResolver _resolver;
    public VContUnit unitPrefab;
    void Start()
    {
        //VContUnit newUnit = Instantiate(vContUnit);
        //_resolver.InjectGameObject(newUnit.gameObject);
        
        VContUnit newUnit = _resolver.Instantiate(unitPrefab);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
