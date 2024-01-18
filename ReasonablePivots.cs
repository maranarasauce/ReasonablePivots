using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.Toolbars;
using UnityEngine;
using UnityEngine.UIElements;

namespace ReasonablePivots
{
    [EditorToolbarElement(id, typeof(SceneView))]
    public class ReasonablePivotPoint : EditorToolbarToggle
    {
        public const string id = "Maranara/Reasonable Point";

        public ReasonablePivotPoint()
        {
            tooltip = "Toggle Tool Handle Rotation";

            this.RegisterValueChangedCallback(OnValueChanged);

            value = UnityEditor.Tools.pivotMode == PivotMode.Pivot;
            UpdateIcons();
        }

        private void OnValueChanged(ChangeEvent<bool> evt)
        {
            Tools.pivotMode = value ? PivotMode.Pivot : PivotMode.Center;
            UpdateIcons();
        }

        private void UpdateIcons()
        {
            text = Tools.pivotMode.ToString();
            icon = (Texture2D)EditorGUIUtility.IconContent(value ? "d_ToolHandlePivot@2x" : "d_ToolHandleCenter@2x").image;
        }
    }

    [EditorToolbarElement(id, typeof(SceneView))]
    public class ReasonablePivotSpace : EditorToolbarToggle
    {
        public const string id = "Maranara/Reasonable Space";

        public ReasonablePivotSpace()
        {
            tooltip = "Toggle Tool Handle Position";

            this.RegisterValueChangedCallback(OnValueChanged);

            value = UnityEditor.Tools.pivotRotation == PivotRotation.Global;
            UpdateIcons();
        }

        private void OnValueChanged(ChangeEvent<bool> evt)
        {
            Tools.pivotRotation = value ? PivotRotation.Global : PivotRotation.Local;
            UpdateIcons();
        }
        private void UpdateIcons()
        {
            text = Tools.pivotRotation.ToString();
            icon = (Texture2D)EditorGUIUtility.IconContent(value ? "d_ToolHandleGlobal@2x" : "d_ToolHandleLocal@2x").image;
        }
    }

    [Overlay(typeof(SceneView), "Reasonable Pivots")]
    public class ReasonablePivotsToolbar : ToolbarOverlay
    {
        ReasonablePivotsToolbar() : base(
            ReasonablePivotSpace.id,
            ReasonablePivotPoint.id
        )
        { }

    }
}
