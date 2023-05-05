using QFramework;
using QFramework.Example;
using UnityEngine;

public class StartScripts : MonoBehaviour
{

    private void Awake()
    {
        //ResKit.Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        ResKit.InitAsync().ToAction().Start(monoBehaviour: this, onFinish: _ =>
        {
            OpenStartPanel();
        });

        //UIKit.OpenPanel<TittlePanel>();
        //UIKit.OpenPanel<StartTestPanel>();

    }
    private void OpenStartPanel()
    {
        UIKit.OpenPanelAsync<TittlePanel>().ToAction().Start(this);
        UIKit.OpenPanelAsync<StartTestPanel>().ToAction().Start(this);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
