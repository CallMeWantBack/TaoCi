using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:7a6e19d9-6e96-4ed8-a44b-ce24c65e4489
	public partial class KnowAssessmentPanel
	{
		public const string Name = "KnowAssessmentPanel";
		
		
		private KnowAssessmentPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public KnowAssessmentPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		KnowAssessmentPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new KnowAssessmentPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
