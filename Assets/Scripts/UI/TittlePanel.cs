using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace QFramework.Example
{
    public class TittlePanelData : UIPanelData
    {
    }
    public partial class TittlePanel : UIPanel
    {
        public List<GameObject> uielementBtns;
        //屏幕宽高
        int screenWidth = 0;
        int screenHeight = 0;
        //是否全屏状态
        bool isFullScreen = false;

        void Awake()
        {
            //获取屏幕宽高
            screenWidth = Screen.currentResolution.width;
            screenHeight = Screen.currentResolution.height;

            //修改默认程序窗体大小（因为用户调整大小后，Unity会在PlayerPrefs记录下来，下次打开的时候会使用之前记录的数值，这里期望每次打开都是窗口模式固定分辨率）
            Screen.SetResolution(1800, 750, UnityEngine.FullScreenMode.Windowed);
        }
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as TittlePanelData ?? new TittlePanelData();
            HideBtn();
            OnclickEvenet();
            // please add init code here
        }
        private void HideBtn()
        {
            for (int i = 0; i < uielementBtns.Count; i++)
            {
                uielementBtns[i].SetActive(false);

            }

        }
        private void OnclickEvenet()
        {
            Help_Btn.onClick.AddListener(() =>
            {
                //UIKit.OpenPanel<HelpPagePanel>().AsLastSibling();
                UIKit.OpenPanelAsync<HelpPagePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<HelpPagePanel>().AsLastSibling();
                });
               

            });
            ReturnHome_Btn.onClick.AddListener(() =>
            {
                UIKit.HideAllPanel();
                UIKit.ClosePanel<ExpriMainPanel>();
                UIKit.GetPanel<TittlePanel>().transform.GetChild(1).gameObject.SetActive(false);
                UIKit.GetPanel<TittlePanel>().transform.GetChild(0).gameObject.SetActive(true);
                UIKit.GetPanel<TittlePanel>().transform.GetComponent<Image>().color = new Color(247, 247, 247, 255);
                //UIKit.OpenPanel<MainMenuPanel>().AsLastSibling();
                //UIKit.OpenPanel<TittlePanel>();

                UIKit.OpenPanelAsync<MainMenuPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<MainMenuPanel>().AsLastSibling();

                    
                });
                UIKit.OpenPanelAsync<TittlePanel>().ToAction().Start(this);

                for (int i = 0; i < TriggerData.GetInstance().operaNeedClone.Count; i++)
                {
                    Destroy(TriggerData.GetInstance().operaNeedClone[i]);
                } 

            });
            FullScrenn_Btn.onClick.AddListener(() =>
            {
                isFullScreen = true;
                Screen.SetResolution((int)(screenWidth), (int)(screenHeight), UnityEngine.FullScreenMode.FullScreenWindow);
            });
        }
        void Update()
        {
            if (!isFullScreen && Screen.width.Equals(screenWidth))
            {
                //监听如果是非全屏状态，并且Screen.width和屏幕width相等即为点击了最大化按钮，将屏幕改为全屏
                isFullScreen = true;
                Screen.SetResolution((int)(screenWidth), (int)(screenHeight), UnityEngine.FullScreenMode.FullScreenWindow);
            }
            else if (isFullScreen && !Screen.fullScreen)
            {
                //非全屏时isFullScreen设置为false
                isFullScreen = false;
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                if (Screen.fullScreen)
                {
                    //ESC退出全屏
                    Screen.SetResolution(1800, 750, UnityEngine.FullScreenMode.Windowed);
                    Screen.fullScreen = false;  //退出全屏   
                }
            }
        }
        protected override void OnOpen(IUIData uiData = null)
        {
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }

        protected override void OnClose()
        {
        }
    }
}
