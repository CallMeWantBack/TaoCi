using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:ddbbd6ad-c23d-4234-b09a-f67979273309
	public partial class ExperimentalReportPanel
	{
		public const string Name = "ExperimentalReportPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button SureBtn;
		[SerializeField]
		public UnityEngine.UI.Button LittleBtn;
		[SerializeField]
		public UnityEngine.UI.Button BigBtn;
		[SerializeField]
		public UnityEngine.UI.InputField InputField;
		
		private ExperimentalReportPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			SureBtn = null;
			LittleBtn = null;
			BigBtn = null;
			InputField = null;
			
			mData = null;
		}
		
		public ExperimentalReportPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		ExperimentalReportPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new ExperimentalReportPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
