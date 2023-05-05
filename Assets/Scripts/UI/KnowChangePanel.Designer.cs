using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:d01a87f6-3403-46d2-8e46-a952346d0e51
	public partial class KnowChangePanel
	{
		public const string Name = "KnowChangePanel";
		
		[SerializeField]
		public TMPro.TextMeshProUGUI Learing;
		[SerializeField]
		public TMPro.TextMeshProUGUI Experim;
		[SerializeField]
		public TMPro.TextMeshProUGUI Experiment_ask;
		[SerializeField]
		public UnityEngine.UI.Button SureBtn;
		
		private KnowChangePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Learing = null;
			Experim = null;
			Experiment_ask = null;
			SureBtn = null;
			
			mData = null;
		}
		
		public KnowChangePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		KnowChangePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new KnowChangePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
