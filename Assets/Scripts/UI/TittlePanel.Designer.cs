using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:08cf9031-a9e6-4929-810c-8ecaa5471847
	public partial class TittlePanel
	{
		public const string Name = "TittlePanel";
		
		[SerializeField]
		public UnityEngine.UI.Button Help_Btn;
		[SerializeField]
		public UnityEngine.UI.Button FullScrenn_Btn;
		[SerializeField]
		public UnityEngine.UI.Button ReturnHome_Btn;
		
		private TittlePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Help_Btn = null;
			FullScrenn_Btn = null;
			ReturnHome_Btn = null;
			
			mData = null;
		}
		
		public TittlePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		TittlePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new TittlePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
