using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerData : MonoBehaviour
{

    [Header("多模的模型UI")]
    public List<GameObject> operaBigUI;

    [Header("需要触碰的Clone")]
    public List<GameObject> operaNeedClone;

   

    private static TriggerData _instance;
    public static TriggerData GetInstance()
    {
        if (_instance == null)
            _instance = new TriggerData();
        return _instance;
    }

    // Start is called before the first frame update
    void Start()
    {
  
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
   
    }
}
