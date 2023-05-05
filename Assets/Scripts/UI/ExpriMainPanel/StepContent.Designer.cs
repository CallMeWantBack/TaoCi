/****************************************************************************
 * 2023.4 ADMIN-20230222X
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public partial class StepContent
	{
		[SerializeField] public UnityEngine.UI.ScrollRect ScrollView;
		[SerializeField] public RectTransform Content_D;
		[SerializeField] public RectTransform Content_Y;
		[SerializeField] public UnityEngine.UI.Image MaskImage;
		[SerializeField] public UnityEngine.UI.Button StepBtn;
		[SerializeField] public UnityEngine.UI.Button StepBtnOpen;

		public void Clear()
		{
			ScrollView = null;
			Content_D = null;
			Content_Y = null;
			MaskImage = null;
			StepBtn = null;
			StepBtnOpen = null;
		}

		public override string ComponentName
		{
			get { return "StepContent";}
		}
	}
}
