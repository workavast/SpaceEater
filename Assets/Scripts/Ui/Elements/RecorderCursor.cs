using UnityEngine;

namespace SourceCode.Ui.Elements
{
    public class RecorderCursor : MonoBehaviour
    {
        void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}
