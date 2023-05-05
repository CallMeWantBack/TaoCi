using QFramework;
using QFramework.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuziScripts : TriggerBase, IController
{
    private OperaModle operaModle;
    private void Awake()
    {
        operaModle = this.GetModel<OperaModle>();
    }
    private void OnDestroy()
    {
        operaModle = null;
    }
    public IArchitecture GetArchitecture()
    {
        return OperaApp.Interface;
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            switch (operaModle.experimentState)
            {

                case OperaModle.ExperimentState.None:
                    break;
                case OperaModle.ExperimentState.Examine:
                    HideModleExper(operaBigUI, operaBigModle);
                    break;
                case OperaModle.ExperimentState.Practise:
                    HideModlePar(infoTuzi[0], operaBigUI, operaBigModle);

                    break;
                default:
                    break;
            }
        });


    }

    // Update is called once per frame
    void Update()
    {

    }
}
