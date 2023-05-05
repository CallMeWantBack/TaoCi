/****************************************************************************
 * 2023.4 ADMIN-20230222X
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public partial class ToolContent
	{
		[SerializeField] public RectTransform ContentlLittle;
		[SerializeField] public RectTransform ContentlBig;

		public void Clear()
		{
			ContentlLittle = null;
			ContentlBig = null;
		}

		public override string ComponentName
		{
			get { return "ToolContent";}
		}
	}
}
