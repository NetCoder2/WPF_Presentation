   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:UI.Panels	UI.Panels  5      ? ;Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null) clr-namespace:Core;assembly=CoreCore 5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   ButtonsViewBoxMargin%   Core.BooleanVisibilityConverter  booleanVisibilityConverter �� 
TargetType  StartupWindow �� Property �� Value �� 
TargetType �� Padding �� FallbackValue ��Name  BackgroundLightBrush	 �� CornerRadius
 J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity J� OpacityMask !� Visual �� ElementName � RowDefinitions K� ZIndex � ColumnDefinitions   
BlurRadius   	Direction  ShadowColor   Color �� Orientation  WordBlueBrush �� TextAlignment  WordBrownBrush  WindowControlButton  WindowCloseButton 	 ForegroundDarkBrush J� Opacity �� 	Converter 
 MainWindowBrush �� EndPoint � MappingMode �� 
StartPoint � Color � Offset  PanelWindow    UI.Panels.WindowTitlePanel J� RenderTransformOrigin  � DataContext! �� ScaleX" �� ScaleY�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      "panelsclr-namespace:UI.Panels  5      )core clr-namespace:Core;assembly=Core  5        5      �� 5   
   $ Colors.xaml?�6   �� 5   
   $ Buttons.xaml?�6   %�  &	        &	      &	 -     7  7  7  7  7   7 	 7  7 
 7  7  &	 �    7 	 7  u�5	      13q�61      5      6&   �� 5      " �6   .�5   
   ��  � �� 5      �� 5      " �6"   .R�5      ��  6   �� *OuterMarginSizeThickness+$ 10��._�5      � .+�5      �� $ 	Container��6%   8��  	 5   )   �� *WindowCornerRadius+$ 10���� 5      	 6%   �� *WindowCornerRadius+$ 10����5    %   �� *ForegroundLightBrush+$ White��
 5!   "     5"   &   $ 0Q�67   $	 0.2Q�6G   5$      � 5'       5)   "   !� 5*   &    62   �� $ 	Container�� 5-   "   �� 50   &   ��64   �� *TitleHeightGridLength+$ 42���� 53   &   $��* �64   �� 56   &   ��64   �� *BottomHeightGridLength+$ 42��.+�5<   "   � $��0��6'   $ 1��67    5?   &   �� 5A   *   $
��Auto �6;   �� 5C   *   $��* �6;   �� 5E   *   $
��Auto �6;   .+�5I   &   �� $��0��6-   $��3��6>   $��1q�5J   -   
�������	 5L   -   �� *WindowCornerRadius+
 5M   *     5N   .   $ 5Q�5O   1   $	 -90Q�5P   1   $ 5Q�5Q   1   8  5R   1   5T   '   (� 5X   &   $��0��6.   $��3��6>   $��5q�6R   .��5Y   *   �� $ Vertical=�65   .+�5Z   .   �� $��Test project��68   $��20(�5[   8   $
��Bold"�5\   8   $��Times New Roman)�5]   8   8�� $ Center=�5^   d   5_   /   �� 5a   .   $��WPF presentation��68   $��Times New Roman)�5b   8   8�� $ Center=�5c   e   5d   +   5e   '   (� 5h   &   $��2��6.   8�� .��5j   *   �� $ 
Horizontal=�66   .+�5l   .   �� $��0,0,2,0q�66   #���  5m   1   ��5n   1   �� *MinimizeCommand+.��5o   2   �� $��10q�68   $5��//UI;component/Images/Buttons/CollapseWindow.png��6D   5p   3   5q   /   �� 5u   .   $��0,0,2,0q�66   #���  5v   1   ��5w   1   �� *MaximizeCommand+.��5x   2   �� $��10q�68   ��5y   9   �� *MaximizeButtonIcon+$2 ,/UI;component/Images/Buttons/RestoreDown.png��5{   3   5|   /   �� 5   .   #���  5�   1   ��5�   1   �� *CloseCommand+.��5�   2   �� $��10q�68   $,��&/UI;component/Images/Buttons/Close.png��6D   5�   3   5�   /   5�   +   5�   '   5�   #   � 5�   "   $��1��6'   .+�5�   &   �� $ DummyOverlay��5�   M   8�� $	 0.4Q�6-   $ 10��6;   y�5�   -   �� *
Deactivate+8  5�   '   � 5�   &    5�   *   �� 5�   .   $
��Auto �6<   �� 5�   .   $��* �6<   �� 5�   .   $
��Auto �6<   .+�5�   *   �� $��1��61   8��  6>   �� *InnerContentPadding+._�5�   .   �� #��z��6?   5�   +   5�   '   5�   #   � 5�   "   $��2��6'   $��0��64   $ 1��5�   '    5�   &   �� 5�   *   $
��Auto �6;   �� 5�   *   $��* �6;   �� 5�   *   $
��Auto �6;   .+�5�   &   �� $��0��6-   $��3��6>   $��1q�5�   -   
�������	 5�   -   �� *WindowCornerRadius+
 5�   *     5�   .   $ 5Q�5�   1   $ 90Q�5�   1   $ 5Q�5�   1   8  5�   1   5�   '   �� 5�   &   $
��Left=�62   $��Center=�6M   $��4��6h   $ 
Horizontal=�5�   .   .+�5�   *   �� $��Times New Roman)�64   $��WPF Presenatation��5�   4   $��20(�5�   8   $
��Bold"�5�   8   8��	 $ Center=�5�   9   $��0,0,30,0q�5�   9   �� 5�   *   $��1��65   $��0,0,30,0q�6?   y�6Q   �� *AdditionLabelVisible+��5�   .   �� 5�   2   $ 0.5,1&�6F   $ RelativeToBoundingBox=�6W   $ 0.5,0&�6{   .��5�   6   � $ White��6C   $ 1Q�6Q   � 5�   6   $ White��6C   � 5�   6   $ 	#FFB6B6B6��6C   $	 0.5Q�6U   5�   3   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      �� 5�      " �6   .�5�   
   ��  �@�WindowStyle$
 None=�6(   �� 5�   
    �@�AllowsTransparency . 6/   �� 5�   
    � ��
 ���� 6'   �� 5�   
    �@�ShowInTaskbar .  6*   �� 5�   
    � �� 5�      �� 5�      " �6"   .R�5�      � .+�5�      �� $ DummyOverlay��5�   -   8��  $	 0.4Q�5�   -   $ 10��5�   -   ��5�   -   �� *PanelContext.ShadowBlur+y�5�   -   �� *
Deactivate+8  5�        5     $ 0.5, 0.5&�5  1   $��20q�5  1     5  1   �� *PanelContext+z�5     �� 5  "   $! 1Q�61   $" 1Q�6<   .��5	     �� #��z��6/   5
     5     5     5     5     5     5     