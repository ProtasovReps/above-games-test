using UnityEngine;
using UnityEngine.UI;

namespace LevelPanel
{
    public class TabletLayoutFitter : MonoBehaviour
    {
        private const int TabletDPI = 600;

        [SerializeField] private GridLayoutGroup _group;
        [SerializeField] private Vector2 _tabletCellSize;

        private void Awake()
        {
            float dpi = Screen.dpi;
            float dpShortest = Mathf.Min(Screen.width, Screen.height) / (dpi / 160f);

            if (dpShortest >= TabletDPI)
            {
                _group.cellSize = _tabletCellSize;
            }
        }
    }
}