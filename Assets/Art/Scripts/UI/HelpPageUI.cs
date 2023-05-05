using QFramework;
using QFramework.Example;
using UnityEngine;
using UnityEngine.UI;
public class HelpPageUI : GeneraModleBase
{
    public Button helpBtn;
    private bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        helpBtn = UIKit.GetPanel<TittlePanel>().Help_Btn;
        helpBtn.onClick.AddListener(() =>
        {
            ShowHelpPage();
        });
    }
    private void ShowHelpPage()
    {
        print("-----------------------------------");
        isStart = false;
        SetActive(this, true);
        ShowOrHideUI(this, true);
    }
    private void Update()
    {
        if (GetUIAlpha(this))
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
            {
                if (!isStart)
                {
                    isStart = true;

                    ShowOrHideUI(this, false, 0.3f, delegate (Component component)
                    {
                        SetActive(this, false);
                    });

                }
            }
        }
    }
    // Update is called once per frame

}
