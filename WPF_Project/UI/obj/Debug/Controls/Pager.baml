   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:UI.ControlsUI.Controls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      ? ;Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null) clr-namespace:Core;assembly=CoreCore 5          UI.Controls.Pager   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _Microsoft.Expression.Effects, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35?ee4http://schemas.microsoft.com/expression/2010/effects   5      c	 _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing 	 5      %localclr-namespace:UI.Controls 	 5      3system&clr-namespace:System;assembly=mscorlib 	 5	      +core clr-namespace:Core;assembly=Core 	 5        � 	Resources  5       �� MergedDictionaries �� Source%  Core.BooleanVisibilityConverter   booleanVisibilityConverter  ButtonMargin u� Left u� Right
 u� Top u� Bottom 	 Scale, 	 &Microsoft.Expression.Shapes.BlockArrow �� 
TargetType  
PagerArrow �� BasedOn	 �� Property
 �� Value � Color  WordLightGreen � Offset  PagerButton  
IconButton  ForegroundDarkBrush  LightBlueBrush �� ElementName �� Path 	 PageRadioButton'  !System.Windows.Shell.WindowChrome �� 
TargetType �� Padding ��Name J� RenderTransformOrigin 
 WordBrownBrush �� RelativeSource �� AncestorType �� ScaleX �� ScaleY �� Triggers :� RoutedEvent �� TargetProperty �� 
TargetName W� From	 W� To g� Duration8  2Microsoft.Expression.Media.Effects.ColorToneEffect   	DarkColor   
LightColor    Desaturation!   
ToneAmount" �� Triggers# ]� 
Conditions$ �� Property% �� Value�� 5   
    5      �� 5      $ ../Themes/Colors.xaml?�6%   �� 5      $ ../Themes/Generic.xaml?�6%   %�  &	        &	      &	 U     &	 p     7  &	 %    7  7  7  7  &		     7 
 7  7  7  7    5      6.   u� 5      $ 0Q�6.   $ 5Q�67   $ 0Q�6A   $ 0Q�6I   X�5      1.6Q�6/   �� 5      "  6    6K   Z� .�5      �� 	 � ��

 � d �6+   �� 5      	 � ��$
 Stretch=�66   �� 5      	 �@ ArrowBodySize$

 0.69Q�62   �� 5       	 �@ ArrowheadAngle$
 70Q�63   �� 5!      	 � ��$
 35��6+   �� 5"      	 � ��$
 40��6*   �� 5#      	 � ��
 5$      
� 5%      .��5&      � $ White��6+   � 5'      8   $ 1Q�6S   5(      5*      5+      �� 5.      " ��6   8   .�5/      �� 	 � ��8
  6/   �� 50      	 � ��8
  6/   �� 51      	 � ��$
 0q�6,   �� 52      	 � ��
 6*   �� $ 
LayoutRoot��$ Height��� 53      	 � ��8
  6+   54      �� 58      " 	�6   .�59      ��  	 �@ IsHitTestVisibleInChrome
 . 6J   �� 5:      	 � ��$
 Stretch=�66   �� 5;      	 � ��$
 Stretch=�68   �� 5<      	 �@��IsPressAndHoldEnabled
 .  6A   �� 5=      	 �@J�RenderTransformOrigin$
 0.5, 0.5&�6:   �� 5>      	 � ��$
 1��6,   �� 5?      	 � ��

 ���� 6/   �� 5A      	 � ��
 5B      �� 5C      " 	�6*   .R�5E      �� #��z��6%   $ 	15,0,15,0q�6O   ._�5F   "   �� $ rbText��6(   $ 0.5,0.6&�5G   )   $��Center=�5H   )   $��Center=�5I   )   $��Arial Black)�5M   )   $
��Bold"�6B   8��  ��5J   (   �� *	Content+ �� *TemplatedParent+��5K   (   ��  �� $ UserControlL�$ PagerFontSize�z�5N   &   �� 5O   *   $ 1Q�69   $ 1Q�6D   5Q   #   5R       5T      :� 5V   "   $ RadioButton.Checked��6/   [�5W   &   �� 5X   *   .��5Y   .   �� $ RenderTransform.ScaleX�69   $ rbText��6a   .��5Z   2   W� $ 1X�5[   B   8  $ 0D�5\   B   5]   /   5^   +   �� 5`   *   .��5a   .   �� $ RenderTransform.ScaleY�69   $ rbText��6a   .��5b   2   W� $ 1X�5c   B   8  $ 0D�5d   B   5e   /   5f   +   5i   #   :� 5l   "   $ RadioButton.Unchecked��6/   [�5m   &   �� 5n   *   .��5o   .   �� $ RenderTransform.ScaleX�69   $ rbText��6a   .��5p   2   W� 8  $ 1X�5q   `   $ 0D�5r   B   5s   /   5t   +   �� 5v   *   .��5w   .   �� $ RenderTransform.ScaleY�69   $ rbText��6a   .��5x   2   W� 8  $ 1X�5y   `   $ 0D�5z   B   5{   /   5|   +   5   #   5�      5�      �� 5�      	 �@J�Effect
 5�        5�      $ Black��5�   %   $ White��67   $  0Q�6J   $! 0Q�6[   5�      �� 5�      	 � z�
 5�      �� 5�      $ 1Q�6)   $ 1Q�64   5�      " 5�      ]� 5�      # 5�      �� 5�      $ �@d�	IsChecked$
% TrueY�6=   ./�5�      �� 	 �@J�Effect
 5�        5�   "   $ Black��5�   %   $ White��67   $  0Q�6J   $! 1Q�6[   5�      5�      5�      5�      .��5�      ]� -   5        & ]�Name$& 
LayoutRoot��5�      .+�5�   
   �� -   5        ' ��Name$' FirstPageButton��5�      #���  5�      $��0,0,5,0q�67   y�5�      ��  �� $ UserControlL�$ IsButtonsVisible�( �� 	Converter#( [  .��5�      (� $��10q�6   .��5�      �� ) �� Orientation$) 
Horizontal=�6   .+�5�      �� 
��� d �$��1q�5�      $��4��5�        WordLightGreenBrush#��[ 5�      5�        5�      *   Orientation$
* Left=�6$   #��[ 67   5�      5�      5�      5�      �� 5�   
   -   5        $' PrevPageButton��5�      #���  5�      $��0,0,20,0q�67   y�5�      ��  �� $ UserControlL�$ IsButtonsVisible�#( [  .��5�      (� $��10q�6   .��5�        $
* Left=�6    #��[ 63   5�      5�      5�      �� 5�   
   -   5        $��	pagerList��5�      $��Stretch=�6#   $��0q�5�      $��Stretch=�5�      
������ 
������ $��Center=�5�   @   ��5�      �� 5�      .R�5�      �� $) 
Horizontal=�6!   5�      ��5�      �� 5�      .R�5�      �� $) 
Horizontal=�6!   ��6<   �� $ 
LayoutRoot��$ Height�.+�5�      	� #��[	 6&   $��Bottom=�5�   &   ��5�   &   �� *	PageIndex++ d� 	IsChecked+ 5�   &   �� *
IsSelected+ �� *FindAncestor+" ��5�   &   �� 5�      $
��Left=�6$   $��1��6@   $��0,0,0,0q�6J   ��5�      �� 5�   "   , �� EndPoint$, 0.5,1&�66   - � MappingMode$- RelativeToBoundingBox=�5�   %   . �� 
StartPoint$. 0.5,0&�5�   %   .��5�   &   � $ White��63   $ 1Q�6A   � 5�   &   $ White��63   � 5�   &   $ 	#FFDADADA��63   $	 0.5Q�6E   5�   #   5�      5�      5�      ��5     �� 5     " ��6     InactiveTransparentListItem# [ 6;   5     5     �� 5  
   -   5        $' NextPageButton��5  I   #���  6   $��20,0,5,0q�67   y�5     ��  �� $ UserControlL�$ IsButtonsVisible�#( [  .��5     (� $��10q�6   .��5       $* Right=�6    #��[ 64   5     5     5     �� 5  
   -   5        $' LastPageButton��5  7   #���  6   y�5     ��  �� $ UserControlL�$ IsButtonsVisible�#( [  .��5!     (� $��10q�6   .��5"     �� $) 
Horizontal=�6   .+�5$       $* Right=�6$   #��[ 68   5%     �� 5'     
��� d �$��1q�5)     $��4��5*     #��[ 5+     5,     5-     5.     5/     �� 53  
   #���  6   $y�Hidden=�67   .��54       $* Right=�6   #��[ 60   55     56     58     5;     