using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:17afcda2-02f8-4c70-910d-e269e8f05f0b
	public partial class ExpriMainPanel
	{
		public const string Name = "ExpriMainPanel";
		
		[SerializeField]
		public StepContent StepContent;
		[SerializeField]
		public PromptCollectionPanel PromptCollectionPanel;
		[SerializeField]
		public RemindImage RemindImage;
		[SerializeField]
		public ToolContent ToolContent;
		
		private ExpriMainPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			StepContent = null;
			PromptCollectionPanel = null;
			RemindImage = null;
			ToolContent = null;
			
			mData = null;
		}
		
		public ExpriMainPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		ExpriMainPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new ExpriMainPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
