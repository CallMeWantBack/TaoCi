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
        //��Ļ���
        int screenWidth = 0;
        int screenHeight = 0;
        //�Ƿ�ȫ��״̬
        bool isFullScreen = false;

        void Awake()
        {
            //��ȡ��Ļ���
            screenWidth = Screen.currentResolution.width;
            screenHeight = Screen.currentResolution.height;

            //�޸�Ĭ�ϳ������С����Ϊ�û�������С��Unity����PlayerPrefs��¼�������´δ򿪵�ʱ���ʹ��֮ǰ��¼����ֵ����������ÿ�δ򿪶��Ǵ���ģʽ�̶��ֱ��ʣ�
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
                //��������Ƿ�ȫ��״̬������Screen.width����Ļwidth��ȼ�Ϊ�������󻯰�ť������Ļ��Ϊȫ��
                isFullScreen = true;
                Screen.SetResolution((int)(screenWidth), (int)(screenHeight), UnityEngine.FullScreenMode.FullScreenWindow);
            }
            else if (isFullScreen && !Screen.fullScreen)
            {
                //��ȫ��ʱisFullScreen����Ϊfalse
                isFullScreen = false;
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                if (Screen.fullScreen)
                {
                    //ESC�˳�ȫ��
                    Screen.SetResolution(1800, 750, UnityEngine.FullScreenMode.Windowed);
                    Screen.fullScreen = false;  //�˳�ȫ��   
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
