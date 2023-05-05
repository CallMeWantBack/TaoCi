/****************************************************************************
 * 2023.4 ADMIN-20230222X
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public partial class PromptCollectionPanel
	{
		[SerializeField] public UnityEngine.UI.Image View_001;
		[SerializeField] public TMPro.TMP_InputField InputFieldOne;
		[SerializeField] public TMPro.TMP_InputField InputFieldTwo;
		[SerializeField] public UnityEngine.UI.Button SureButton_P;
		[SerializeField] public TMPro.TextMeshProUGUI Text_Prochange;
		[SerializeField] public UnityEngine.UI.Image View_002;
		[SerializeField] public TMPro.TextMeshProUGUI Learing;
		[SerializeField] public UnityEngine.UI.Image ImageSlider_P;
		[SerializeField] public TMPro.TextMeshProUGUI TextChange_PI;
		[SerializeField] public TMPro.TextMeshProUGUI TextChange_PO;
		[SerializeField] public UnityEngine.UI.Image View_003;
		[SerializeField] public UnityEngine.UI.Button SurBtn_PT;
		[SerializeField] public TMPro.TextMeshProUGUI TextChangeT;
		[SerializeField] public UnityEngine.UI.Button Btn_TimeT;
		[SerializeField] public UnityEngine.UI.Button Btn_TimeO;
		[SerializeField] public UnityEngine.UI.Button Btn_TimeN;
		[SerializeField] public UnityEngine.UI.Image View_004;
		[SerializeField] public TMPro.TextMeshProUGUI TextChang_Eexit;
		[SerializeField] public UnityEngine.UI.Button SurBtn_ExIt;
		[SerializeField] public TMPro.TextMeshProUGUI TextChangeT_exit;

		public void Clear()
		{
			View_001 = null;
			InputFieldOne = null;
			InputFieldTwo = null;
			SureButton_P = null;
			Text_Prochange = null;
			View_002 = null;
			Learing = null;
			ImageSlider_P = null;
			TextChange_PI = null;
			TextChange_PO = null;
			View_003 = null;
			SurBtn_PT = null;
			TextChangeT = null;
			Btn_TimeT = null;
			Btn_TimeO = null;
			Btn_TimeN = null;
			View_004 = null;
			TextChang_Eexit = null;
			SurBtn_ExIt = null;
			TextChangeT_exit = null;
		}

		public override string ComponentName
		{
			get { return "PromptCollectionPanel";}
		}
	}
}
