using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:90de33f8-2673-4549-8f4a-4f84040b9d2d
	public partial class KnowledgeLearPanel
	{
		public const string Name = "KnowledgeLearPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button Experiment_purposeBtn;
		[SerializeField]
		public UnityEngine.UI.Button Experiment_principleBtn;
		[SerializeField]
		public UnityEngine.UI.Button Experiment_askBtn;
		[SerializeField]
		public UnityEngine.UI.Button SureBtn;
		
		private KnowledgeLearPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Experiment_purposeBtn = null;
			Experiment_principleBtn = null;
			Experiment_askBtn = null;
			SureBtn = null;
			
			mData = null;
		}
		
		public KnowledgeLearPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		KnowledgeLearPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new KnowledgeLearPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
