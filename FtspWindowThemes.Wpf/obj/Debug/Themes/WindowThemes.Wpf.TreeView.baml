   M S B A M L   `   `   `  ����K  GWindowThemes.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WindowThemes.Wpf.ControlAssistWindowThemes.Wpf.ControlAssist  5      E'clr-namespace:WindowThemes.Wpf.ControlsWindowThemes.Wpf.Controls  5      I)clr-namespace:WindowThemes.Wpf.ConvertersWindowThemes.Wpf.Converters  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0895    /WindowThemes.Wpf.Converters.BrushRoundConverter   BrushRoundConverter7   1WindowThemes.Wpf.Converters.MathMultipleConverter  MathMlpMultipleConverter?   9WindowThemes.Wpf.Converters.NullableToVisibilityConverter ! NullableToVisibilityConverter  MaterialDesignTreeView  �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels ��Name  ScrollViewerStyle8   2WindowThemes.Wpf.ControlAssist.ScrollElementAssist   	ThumbSize   Radius8   2WindowThemes.Wpf.ControlAssist.BorderElementAssist	   CornerRadius
   ThumbForeground   ThumbBackground �� Triggers P� Property P� Value �� 
TargetName �� Triggers ) %MaterialDesignTreeViewItemFocusVisual + 'MaterialDesignExpandCollapseToggleStyle'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   From	   To   GeneratedEasingFunction0  *System.Windows.Media.Animation.QuarticEase7	  1System.Windows.Media.Animation.EasingFunctionBase 	  
EasingMode   
Storyboard �� TargetProperty �� 
TargetName9
  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   GeneratedDuration   States   System.Windows.VisualState   
Storyboard F�Name  J� RenderTransformOrigin! �� Angle" �� CenterX# �� CenterY  MaterialDesignTreeViewItem$ �� RelativeSource% �� AncestorType& � ColumnDefinitions' � RowDefinitions(   Name.  (System.Windows.Media.Animation.CubicEase)   Name	* W� To+ g� Duration, R� KeyTime  System.Windows.Visibility-   Visible. R� Value/   	Collapsed)   #WindowThemes.Wpf.Controls.ScaleHost0  Name1 d�Name2 �� 	ClickMode3 d� 	IsChecked4 J� IsHitTestVisible5 J� Opacity6 �� 	Converter7 �Name8 ��Name9 ��Name: �� Path; ��Name< `� 	Converter= �� ElementName> ��Name? �� Value@ �� BindingA �� 	ConverterB �� Mode�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      7assist,clr-namespace:WindowThemes.Wpf.ControlAssist  5      3control'clr-namespace:WindowThemes.Wpf.Controls  5      8
converters)clr-namespace:WindowThemes.Wpf.Converters  5      %$  &	        &	      &	 &     &	 9     &	 �    &	 R    &	 6    7  7  7   7   7  7  7     5      6%     5      6'     5      6/   �� 5      "  R�6+   .�5   
   ��  � ��
 ���� 6'   �� 5   
    � �� 6(   Z� �� 5   
    � ��$ 0q�6,   �� 5   
    � ��
 �����6'   �� 5   
    � ��$ 1q�6$   �� 5   
    � ��$
 Auto=�6G   �� 5   
    � ��$
 Auto=�6E   �� 5   
    �@��PanningMode$
 Both=�65   �� 5   
    �@��IsFlicksEnabled .  63   �� 5   
    � ��$ Center=�65   �� 5   
    � �� 5      �� 5      " R�6"   .R�5      �� $ Bd��6   #��z��6)   #��z��6U    . ._�5      �� $ _tv_scrollviewer_��6'   #���  6C   $ 15Q�5   '   $ 8Q�5   '   $	 8��5    '   
 �	#88FFFFFF
 ���� #��z��5#   '   ��.  |�.  #��z��6|   #��z��6�   # z 6�   #��z��69  .��5$      �� 5%      5&       5'      P� 5(       � {� .  . �5)      ��  �@J�Opacity$	 .56Q�68   5*      P� 5+       �@%�IsVirtualizing . . �5,      �� $ _tv_scrollviewer_��6A    � �� . 6`   5-      5/      51       52   
   P� 53       �@%�IsVirtualizing . . �54      ��  � �� 55      �� 56      .R�57      $� 58      5:      5;      5=      �� 5?      .�5@   
   ��  � �� 5A      �� 5B      .R�5C      �� 5D      5F      5G      �� 5I      "  d�6<   .�5J   
   ��  � |� .  6&   �� 5K   
    � ��$ 16��6"   �� 5L   
    � ��$ 16��6#   �� 5M   
    � �� 5N      �� 5O      " d�6"   .R�5P      �� 
������ $��16��66   $��16��6B    5Q        5R      CheckStates�� 5S   "     5T   &   $ 	Unchecked��67   $ Checked��6H    5U   *     5V   .   $ EaseOut=�6:   . 5X   *   �� .��5Y   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6L   $ 
ExpandPath��6�   .\�5Z   2   
  $ 0��6G   $ 0Q�6S   
  5[   2   $ 0:0:0.2��6G   $ 45Q�6Y   5\   /   5]   +   5^   '     5_   &   $ 0D�67   $ 	Unchecked��6M   . 5`   *   �� .��5a   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6L   $ 
ExpandPath��6�   .\�5b   2   
  $ 0��6G   $ 45Q�6S   5c   /   5d   +   5e   '     5f   &   $ 0D�67   $ Checked��6M   . 5g   *   �� .��5h   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6L   $ 
ExpandPath��6�   .\�5i   2   
  $ 0��6G   $ 0Q�6S   5j   /   5k   +   5l   '     5m   &   $ Checked��67   $ 0D�6F   $ 	Unchecked��6\    5n   *     5o   .   $ EaseOut=�6:   . 5q   *   �� .��5r   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6L   $ 
ExpandPath��6�   .\�5s   2   
  $ 0��6G   $ 45Q�6S   
  5t   2   $ 0:0:0.2��6G   $ 0Q�6Y   5u   /   5v   +   5w   '   . 5y   "     Checked��. 5z   &   �� .��5{   *   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6H   $ 
ExpandPath��6�   .\�5|   .   
  $ 0:0:0.2��6C   $ 45Q�6U   5}   +   5~   '   5   #     5�   "   	Unchecked��. 5�   &   �� .��5�   *   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6H   $ 
ExpandPath��6�   .\�5�   .   
  $ 0:0:0.2��6C   $ 0Q�6U   5�   +   5�   '   5�   #   5�      ._�5�      (� .��5�      �� $��24��6%   $��24��60   .+�5�   "   F� $ 
ExpandPath��5�   /   P���p�� �G�z�0@�P��  � Ѱ� Pq р�� ��[ � $�  � р�� ��Q�� �G�z�0@	 . #��z��5�   /   #��z��5�   /   $  .5,.5&�6U   z�5�   &   V� 5�   *   .~�5�   .   �� �� 5�   .   �� 5�   .   $! 0Q�6>   $" 4Q�6H   $# 4Q�6T   T� 5�   .   5�   +   5�   #   5�      5�      5�      5�      5�      5�      �� 5�      "  Q�6/   .�5�   
   ��  � ��
 ���� 6'   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � �� 67   �� *HorizontalContentAlignment+$ �� "% ���� 5�   
    � �� 65   �� *VerticalContentAlignment+$ �� "% ���� 5�   
    � ��$ 8q�6$   �� 5�   
    �@�FocusVisualStyle8   6-   �� 5�   
    � �� 6'   �� *
Foreground+$ �� "% R��� 5�   
    � �� 5�      �� 5�      " Q�6"   .R�5�      � & 5�      �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   �� 5�      $��* �6/   ' 5�      �� 5�      $
��Auto �6,   �� 5�      $
��Auto �6,   �� 5�       5�        5�      $( CommonStates��6/    5�   "     5�   &   $ 0:0:0.3D�67   $ Normal��6S    5�   *     5�   .   $ EaseOut=�68   5�   '   . 5�   "     $) Normal��6.     5�   "   $) 	MouseOver��6.   . 5�   &   �� .��5�   *   W� $ MouseOverBorder��6:   $ Opacity�6b   $	* 0.1X�5�   >   $+ 0D�6G   W� 5�   *   $ MouseOverBorder��6:   $ Opacity�6b   $	* 0.1X�5�   >   $+ 0D�6G   5�   '   5�   #     5�   "   $) Disabled��6.   5�        5�      SelectionStates�� 5�   "     5�   &   $ 0:0:0.6D�67   . 5�   "     $) Selected��6.   . 5�   &   �� .��5�   *   W� $ SelectedBorder��6:   $ Opacity�5�   :   $
* 0.18X�5�   :   $+ 0D�6D   5�   '   5�   #     5�   "   $) 
Unselected��6.   5�        5�      ExpansionStates�� 5�   "     5�   &   $ 0D�67   $ Expanded��6M    5�   *     5�   .   $ EaseOut=�68   . 5�   *   �� .��5�   .   T� $ 	ItemsHost��6L   $ 
Visibility�6n   ..�5�   2   i� $, 0��6I   #. Z- 6U   5�   /   W� 5�   .   $ Opacity�6>   $ 	ItemsHost��6b   $* 1X�6�   $+ 0:0:0.3D�6�   W� 5�   .   $ Scale�6>   $ 	ScaleHost��6`   $* 1X�6�   $+ 0:0:0.3D�6�   5�   +   5�   '     5�   &   $ 0D�67   $ 	Collapsed��6M    5�   *     5�   .   $ EaseOut=�68   . 5�   *   �� .��5�   .   T� $ 	ItemsHost��6L   $ 
Visibility�6n   ..�5�   2   i� $, 0:0:0.3��6I   #. Z/ 6[   5�   /   W� 5�   .   $ Opacity�6>   $ 	ItemsHost��6b   $* 0X�6�   $+ 0:0:0.3D�6�   W� 5�   .   $ Scale�6>   $ 	ScaleHost��6`   $* 0X�6�   $+ 0:0:0.3D�6�   5�   +   5�   '   . 5�   "     Expanded��. 5�   &   �� .��5�   *   W� $ Opacity�6:   $ 	ItemsHost��6^   $* 1X�6�   $+ 0D�6�   W� 5�   *   $ Scale�6:   $ 	ScaleHost��6\   $* 1X�6~   $+ 0:0:0.3D�6�   T� 5�   *   $ 	ItemsHost��6H   $ 
Visibility�6j   ..�5�   .   i� $, 0��6E   #. Z- 6Q   5�   +   5�   '   5�   #     5�   "   	Collapsed��. 5�   &   �� .��5�   *   W� $ Opacity�6:   $ 	ItemsHost��6^   $* 0X�6�   $+ 0D�6�   W� 5�   *   $ Scale�6:   $ 	ScaleHost��6\   $* 0X�6~   $+ 0:0:0.3D�6�   T� 5   *   $ 	ItemsHost��6H   $ 
Visibility�6j   ..�5  .   i� $, 0��6E   #. Z/ 6Q   5  +   5  '   5  #   5     .+�5       $0 	ScaleHost��6,   d� 5     $1 Expander��6'   $2 Press=�69   8�� #��z��5
  '   $��8 0 8 0q�5  '   $��Center=�5  '   3 5  K   �� *
IsExpanded+$ �� *TemplatedParent+5  '   �� 5     $ MouseOverBorder��6!   $��1��5  !   $��2��61   4 .  $5 0Q�5  !   ��5  !   �� *
Foreground+86  �� 5     $ SelectedBorder��6!   $��1��5  !   $��2��61   4 .  $5 0Q�5  !   ��5  !   �� *
Foreground+86  � 5     $7 ContentGrid��6C   $��1��6   $��2��6/   #��z��6X   .+�5     �� $8 PART_Header��6/   $��Header��6D   5     �� 5     $9 AdditionalContentControl��5   )   $��1��5  )   $��1��66   $��2��6F   #��z��5!  )   $y�	Collapsed=�5$  )   ��5"  )   �� $ �� *Self+$0: *(assist:TreeViewAssist.AdditionalTemplate)���5#  )   �� $ �� *Self+$8: 2(assist:TreeViewAssist.AdditionalTemplateSelector)�5%     �� 5'     $; 
ItemsPanel��5(  %   $��1��5'  %   $��2��65   $��	-16 0 0 0q�5)  %   $��2��5*  %   ��5+     `� 5,  "   8<  .1�5-  &   �� $= 	ItemsHost��6.   $: ActualHeight�6F   �� 5.  &   $= 	ScaleHost��6.   $: Scale�6F   5/  #   .+�51     �� $> 	ItemsHost��6-   $	��Top=�52  -   $5 0Q�53  -   $y�	Collapsed=�54  -   55     56      57     �� 58     $? Visible��59  &   @ 58  &   �� $ �� *Self+$0: *(assist:TreeViewAssist.AdditionalTemplate)�8A  $B OneWay=�.a�5:     �� $ AdditionalContentControl��6%    � y�$ Visible=�6a   5;     �� 5<     $? Visible��5=  &   @ 5<  &   �� $ �� *Self+$8: 2(assist:TreeViewAssist.AdditionalTemplateSelector)�8A  $B OneWay=�.a�5>     �� $ AdditionalContentControl��6%    � y�$ Visible=�6a   5?     P� 5@      �@��HasItems .  . �5A     �� $ Expander��6;    � y�$ Hidden=�6Q   5B     P� 5C      � {� .  . �5D     ��  �@J�Opacity$	 .56Q�68   5E     5G     5I      5J  
   P� 5K      �@%�IsVirtualizing . . �5L     ��  � �� 5M     �� 5N     .R�5O     $� 5P     5R     5S     5U     5W     