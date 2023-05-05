using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:dd3f46a3-54cc-4bda-8c50-68eca9891b93
	public partial class BgPanel
	{
		public const string Name = "BgPanel";
		
		
		private BgPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public BgPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		BgPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new BgPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
