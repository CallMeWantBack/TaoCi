using QFramework;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragUI : MonoBehaviour, IPointerDownHandler
{

    //1.Pointerdown里根据是不是第一次决定是否生成物体，要考虑两次同时进入这个方法的情况，里面有异步
    //2.在Update里检测物体是否已经生成，然后“根据当前UI选项决定能否显示”    和拖拽
    //3.Update里如果拖拽正确，则隐藏


    public bool IsRecycled { get; set; }

    public string prefabName;

    //生成的物体
    public GameObject dragObj;
    //是否正在拖动,这个别的地方会修改吗？
    private bool isDrag;

    private bool isTree = false;
    private ResLoader mResloader = ResLoader.Allocate();


    [SerializeField] LayerMask rayMask;
    private void Update()
    {
        //脱离就放在桌子上吗？对

        if (isDrag)
        {
            //print(isDrag);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f, rayMask)&&Input.GetMouseButton(0))
            {
                
                dragObj.transform.position = hit.point;
                // dragObj.SetActive(true);
                print($"OnDrag-Name:{dragObj.name}");
            }
            else
            {
                dragObj.SetActive(false);
                print($"SetFalse-Name:{dragObj.name}");
            }
        }
    }

    int enterCount = 0;
    //鼠标按下生成物体
    public void OnPointerDown(PointerEventData eventData)
    {
        //isDrag = true;
        enterCount++;
        if (enterCount == 1)
        {
            mResloader.Add2Load(prefabName, (succeed, res) =>
            {
                if (succeed)
                {
                    GameObject objClone = res.Asset.As<GameObject>().Instantiate();
                    dragObj = objClone;
                    dragObj.transform.parent = GameObject.Find("ClonePrefab").transform;
                    isDrag = true;
                    print("Gen");
                    // print(isDrag);
                }
                else print("加载失败");
            });
            //这里是异步的，需要等待加载完才能拖拽
            mResloader.LoadAsync();
           
        }
        else if(enterCount>1)
        {
            if (!isDrag) return;
            dragObj.SetActive(true);
        }

        else
        {
            throw new System.Exception("enterCountException");
        }


    }

    private void OnDestroy()
    {
        mResloader.Recycle2Cache();
        mResloader = null;
    }

    public void Recycle2Cache()
    {
        throw new System.NotImplementedException();
    }
}
