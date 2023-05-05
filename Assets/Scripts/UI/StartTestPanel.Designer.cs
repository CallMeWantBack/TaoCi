using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:07da92e3-5cf5-49ec-8288-7f904c5cd010
	public partial class StartTestPanel
	{
		public const string Name = "StartTestPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button StartTest_Btn;
		
		private StartTestPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			StartTest_Btn = null;
			
			mData = null;
		}
		
		public StartTestPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		StartTestPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new StartTestPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
