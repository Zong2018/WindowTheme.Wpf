using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowThemes.Wpf.Common
{
    /// <summary>
    /// 气泡尖角位置
    /// </summary>
    public enum AnglePositions
    {
        /// <summary>
        /// 尖角位于左侧。
        /// </summary>
        Left,
        /// <summary>
        /// 尖角位于左下角。
        /// </summary>
        BottomLeft,
        /// <summary>
        /// 尖角位于中间的底部。
        /// </summary>
        BottomCenter,
        /// <summary>
        /// 尖角位于右下角。
        /// </summary>
        BottomRight,
        /// <summary>
        /// 尖角位于右下角不靠边。
        /// </summary>
        BottomRightNotEnd,
        /// <summary>
        /// 尖角位于右侧。
        /// </summary>
        Right,
    }

    #region DropDown
    public enum DropDownPlacement
    {
        Bottom,
        RightBottom,
        LeftBottom,
        RightTop
    }
    #endregion
}
