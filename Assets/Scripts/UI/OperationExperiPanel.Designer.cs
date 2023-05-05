using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:edae38fa-baba-4325-8629-12254dfe8009
	public partial class OperationExperiPanel
	{
		public const string Name = "OperationExperiPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button Monoblock_moldBtn;
		[SerializeField]
		public UnityEngine.UI.Button Multiblock_moldBtn;
		[SerializeField]
		public TMPro.TextMeshProUGUI ChangeTxt;
		
		private OperationExperiPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Monoblock_moldBtn = null;
			Multiblock_moldBtn = null;
			ChangeTxt = null;
			
			mData = null;
		}
		
		public OperationExperiPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		OperationExperiPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new OperationExperiPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
