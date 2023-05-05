using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QFramework.Example
{
    public class ExperimentalReportPanelData : UIPanelData
    {
    }
    public partial class ExperimentalReportPanel : UIPanel
    {
        [Header("成绩")]
        public List<TMP_Text> tMP_TextsGradest ;
        [Header("开始时间")]
        public List<TMP_Text> tMP_TextsEnd;
        [Header("结束时间")]
        public List<TMP_Text> MP_TextsStart;


        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as ExperimentalReportPanelData ?? new ExperimentalReportPanelData();

            Information();
            // please add init code here
        }


        private void Information()
        {
            //for (int i = 0; i < TriggerOther.GetInstance().StartTimes.Count; i++)
            //{
            //    for (int y = 0; y < tMP_TextsEnd.Count; y++)
            //    {
            //        tMP_TextsEnd[y].text = TriggerOther.GetInstance().StartTimes[i];
            //    }
            //}
            //for (int i = 0; i < TriggerOther.GetInstance().EndTimes.Count; i++)
            //{
            //    for (int y = 0; y < MP_TextsStart.Count; y++)
            //    {
            //        MP_TextsStart[y].text = TriggerOther.GetInstance().EndTimes[i];
            //    }
            //}
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
