   M S B A M L   `   `   `  ����B  >Helpers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\;clr-namespace:System.Windows.Interactivity;assembly=HelpersSystem.Windows.Interactivity  5      H1clr-namespace:Helpers.Behaviours;assembly=HelpersHelpers.Behaviours  5      = 9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:UI.ControlsUI.Controls 5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   GridSeparator �� 
TargetType  TitleBorder �� Property �� Value3   -System.Windows.Media.Effects.DropShadowEffect    
BlurRadius    ShadowDepth  ShadowColor    Color  InactiveTransparentListItem �� 
TargetType	 �Name
 �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName"  UI.Controls.EnhancedCheckBox   MainRectColor �� CornerRadius J� Effect    Opacity � RowDefinitions �Name � ColumnDefinitions   
TitleLabel   MainLabelColor �� Orientation   AdditionalLabelTitle   AdditionalLabelFontSize    AdditionalLabelTitleColor   AdditionalLabel   AdditionalLabelColor   	CheckSize J� RenderTransformOrigin  �� ScaleX! �� ScaleY" ��Name# P� Property$ P� Value% :� RoutedEvent& �� 
TargetName' �� TargetProperty( W� From	) W� To* g� Duration+ g� AutoReverse  TestingListBox,   AdditionalLabelVisible-   SmallRectColor. d� 	IsChecked/ �� RelativeSource0 �� AncestorType1 �� BasedOn5   /System.Windows.Interactivity.InteractivityItems:   2System.Windows.Interactivity.InteractivityTemplate�2   	Behaviors4   .Helpers.Behaviours.AnimateListBoxItemsBehavior3   Tick4   	Animation5   OpacityAnimation�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      Minteractivity;clr-namespace:System.Windows.Interactivity;assembly=Helpers  5      @
behaviours1clr-namespace:Helpers.Behaviours;assembly=Helpers  5      &controlsclr-namespace:UI.Controls  5        5      �� 5	   
   $ Colors.xaml?�6   �� 5
   
   $ CommonResources.xaml?�6   �� 5   
   $ 	Text.xaml?�6   %�  &	        &	      7  &	 z    '      7  7   7   7   &	 a    7  �5      5 �6*   �� 5      " ��6   .�5   
   ��  � ��$ Stretch=�6.   �� 5   
    � ��
 �����6'   �� 5   
    �@��CornerRadius$ 7��6)   �� 5   
    � �� �#6666666(   �� 5   
    � ��$ 1q�6,   �� 5   
    �@J�Effect 5         5      $ 5Q�5      $ 5Q�5      8   5      5       5"      �� 5%      " ��6   .�5&   
   ��  �@��IsPressAndHoldEnabled .  69   �� 5(   
    � z� 5)      T� 5*      5,      �� 5.   
    � �� 5/      �� 50      " ��6"   .R�51      � $	 Bd��6   #��z��6'   .+�52      � .+�53      �� #��z��54      #��z��55      56      57      
 58      ]� 5;       5<      �� 5=   "    �@��IsSelectionActive .  6R   �� 5>   "    �@��
IsSelected . 6B   ./�5@      �� $ Bd��6%    � ��
 ���� 6K   5A      ]� 5C       5D      �� 5E   "    �@��IsSelectionActive . 6R   �� 5F   "    �@��
IsSelected . 6B   ./�5H      �� $ Bd��6%    � ��
 ���� 6K   5I      ]� 5K       5L      �� 5M   "    �@��IsSelectionActive . 6R   �� 5N   "    �@��
IsSelected .  6B   ./�5P      �� $ Bd��6%    � ��
 ���� 6K   5Q      5T      5V      5W      �� 5[      "  6   .�5\   
   ��  �@J�SnapsToDevicePixels . 60   �� 5]   
    �@ AdditionalLabel$ label��6,   �� 5^   
    � ��$
 20pt(�6%   �� 5_   
    �@ AdditionalLabelTitle$ Title: ��61   �� 5a   
    � �� 5b      �� 5c      "  6"   .R�5e      �� 
���   �$��1q�61   #��z 6E   $ 5��5f       5g         5h      8   $	 0.8Q�6T   ._�5j      �  5k      �� 5l   "   8�� 5m   #   �� 5n   "   $��* �60   5o   #   �� 5p   "   8�� 5q   #   �� 5r   "   $ AdditionalRow��6?   $��0.73* �60   5s   #   �� 5t   "   $ AdditionalRowBottom��60   $��5 �6K   5u   #    5x      �� 5y   "   8�� 5z   #   �� 5|   "   $	��10* �63   5}   #   �� 5�   "   $��* �63   5�   #   .+�5�      �� $��1��6%   $��1��62   
���   �$��1q�5�   %   #��z��5�   %   $ 5��5�   %   ._�5�   "   �� #��z 6,   #��z��5�   8   $
��Bold"�5�   8   $��Times New Roman)�5�   8   #��z 5�   8   $��Center=�5�   9   5�   #   5�      �� 5�      $��3��6)   $��1��66   $ 
Horizontal=�6F   .+�5�   "   �� #��z 6,   #��z 5�   8   $
��Bold"�5�   8   $��Times New Roman)�5�   8   #��z 5�   8   $��Center=�5�   9   $��0,0,5,0q�6T   5�   #   �� 5�   "   #��z 6,   #��z 5�   8   $
��Bold"�5�   8   $��Times New Roman)�5�   8   #��z 5�   8   $��Center=�5�   9   5�   #   5�      � 5�      $��4��6#   $��0��64   $��2��6A    5�   "   �� 5�   &   $��3 �64   5�   '   �� 5�   &   5�   '   .+�5�   "   �� $��1��6-   .+�5�   &   �� $	 100��5�   1   #��z 5�   1   #��z 5�   1   #��z��5�   1   $ 0.5, 0.5&�5�   1   z�5�   *   �� 5�   .   AnimatedScaleTransform��$  1Q�6^   $! 1Q�6i   ._�5�   *   �� $" 	CheckMark��60   $��7q�5�   1   $,��&/UI;component/Images/Buttons/Check.png��5�   1   5�   +   5�   '   5�   #   5�      5�      5�      
 5�      P� 5�      # �@ AdditionalLabelVisible$ .  . �5�      �� $ AdditionalRowBottom��6A    � ��$ 0 �67   6A   5�      P� 5�      # �@ AdditionalLabelVisible$ .  . �5�      �� $ AdditionalRow��6A    � ��$ 0 �67   6A   5�      P� 5�      # �@d�	IsChecked$$ falseY�67   . �5�      �� $ 	CheckMark��6M    � y�$ 	Collapsed=�6;   6M   5�      :� 5�      $:% 4controls:EnhancedCheckBox.PreviewMouseLeftButtonDown��6'   .[�5�      �� .��5�   "   �� .��5�   &   W� $& AnimatedScaleTransform��5�   1   $' ScaleX�5�   1   $( 1X�5�   1   $) 0X�6:   $* 0:0:0.15D�6A   + . 6U   5�   #   5�      5�      5�      5�      5�      �� 5�      " ��6   .�5�   
   ��  � �� 6(   �� *Items+6B   �� 5�   
    �@��SelectedItem 6)   �� *SelectedItem+6J   �� 5�   
    � ��$ Disabled=�6G   6Z   �� 5�   
    � ��
 ���� 6=   �� 5�   
    � ��
 ���� 6>   �� 5�   
    � �� 5�      �� 5      .R�5     � $	 Bd��6   .+�5       $��17(�5     $��Stretch=�5     $ 30Q�5     $��40��5     $��5q�5	  (   , .   5     �� *
AnswerText+- 5     �� *AnswerColor+ 5	     �� *Id+. 5     �� *
IsSelected+/ �� *FindAncestor+"0 ��5     5     5     5     �� 5  
    � �� 5     �� 5     " ��6   81   5     5     �� 5  
    �@ Template 5       5     .R�5       2 5       5     $3 0:0:0.05h�6E   4 5   "   W� 5!  &   $	( 320X�66   $) 0X�6A   $* 0:0:0.15D�6H   5 5#  "   W� 5$  &   $( 0X�66   $) 1X�6?   $* 0:0:0.5D�6F   5&     5(     5)     5+     5-     5/     