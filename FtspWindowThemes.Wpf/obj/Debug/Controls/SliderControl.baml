   M S B A M L   `   `   `  ����K  GWindowThemes.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WindowThemes.Wpf.ControlsWindowThemes.Wpf.Controls  5      O,clr-namespace:WindowThemes.Wpf.ControlAssistWindowThemes.Wpf.ControlAssist  5      E'clr-namespace:WindowThemes.Wpf.ControlsWindowThemes.Wpf.Controls  5      -    'WindowThemes.Wpf.Controls.SliderControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:WindowThemes.Wpf.Controls     5      ?assist,clr-namespace:WindowThemes.Wpf.ControlAssist     5      ;control'clr-namespace:WindowThemes.Wpf.Controls     5      -   5          >�Name$  sliderControl��5
   7   .��5      &    WindowThemes.Wpf.Controls.Bubble  -   5          Name$ bubble��5         AnglePosition$ BottomRightNotEnd=�6%   $��0q�6G      BorderCornerRadius$ 4��6S   
�������$	��320��6}   $	��200��6�   ���#DADADA   
CoverBrush
 �����.��5   
   � -   5         �Name$
 grid��5      $	��300��6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6     � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      � -   5        $ numTop��5   #   $��1��6   6#   �� 5      -   5         ��Name$ slider��5      $��1��6%   $��1��62   ���	#FF999999$��0q�6Y      ScaleSliderStyle#��[  6m   $��Center=�5      	 �� TickPlacement$	 BottomRight=�60   
 �� TickFrequency
 5      ��  �� ElementName$ sliderControl�� �� Path$ TickFrequerncy� � LargeChange 5      �� $ sliderControl��$ LargeChange� � SmallChange 5      �� $ sliderControl��$ SmallChange� � Minimum 5      �� $ sliderControl��$ MinNum� � Maximum 5      �� $ sliderControl��$ MaxNum�5       � 5!      -   5        $ 	numBottom��5!   1   $��2��6   $��1��6    $��6,0,6,0q�6D   
�������6U   �� 5"      -   5         ��Name$ btnDown��5"      $��0��6'   $��1��67   $��10��6E   $��10��6P   $��5,0,10,0q�6\   $��Center=�6n   $��Center=�6�     IconButtonStyle#���  6�   
������   PathMin6   0WindowThemes.Wpf.ControlAssist.IconElementAssist   Geometry# �  5#         Height$ 2Q�5$         Width$ 10Q�5%      8   2WindowThemes.Wpf.ControlAssist.BorderElementAssist   CornerRadius$ 0��5&         
IconMargin$ 0,2,0,0q�5'         	FillColor �	#FF999999B   <WindowThemes.Wpf.ControlAssist.BackgroundSwitchElementAssist   MouseHoverBackground
 ����    MouseDownBackground
 ����   GlobalButtonMouseOverColor   MouseHoverForeground# [ 5+        GlobalButtonPressedColor   MouseDownForeground# [ 5,      5/      �� 50      -   5        $ btnUp��50      $��2��6%   $��1��65   $��10��6C   $��10��6N   $��
10,-5,10,0q�6Z   $��Center=�6n   $��Center=�6�   #���  6�   
������   PathAdd# �  51      $ 10Q�52      $ 10Q�53      $ 0��54      $ 0,0,0,0q�55       �	#FF999999
 ���� 
 ���� # [ 59      # [ 5:      5=      �� 5>      $��3��6   $��1��6&   $��20��64   $��20��6?   $��10,0,0,0q�6K   $��Center=�6^   $y�	Collapsed=�6y   5?      5@      5B      