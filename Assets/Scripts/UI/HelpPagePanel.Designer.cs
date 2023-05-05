using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:8f437c6c-52a1-4ccc-81a2-c67a76c39459
	public partial class HelpPagePanel
	{
		public const string Name = "HelpPagePanel";
		
		
		private HelpPagePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public HelpPagePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		HelpPagePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new HelpPagePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
