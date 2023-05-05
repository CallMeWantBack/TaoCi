/****************************************************************************
 * 2023.4 ADMIN-20230222X
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public partial class ButtonGroup
	{
		[SerializeField] public UnityEngine.UI.Button Help_Btn;
		[SerializeField] public UnityEngine.UI.Button FullScrenn_Btn;
		[SerializeField] public UnityEngine.UI.Button ReturnHome_Btn;

		public void Clear()
		{
			Help_Btn = null;
			FullScrenn_Btn = null;
			ReturnHome_Btn = null;
		}

		public override string ComponentName
		{
			get { return "ButtonGroup";}
		}
	}
}
