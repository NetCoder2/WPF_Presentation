   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5%clr-namespace:UI.Controls;assembly=UIUI.Controls  5   	   F BTestProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TestProjectTestProject 5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   ? ;Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null) clr-namespace:Core;assembly=CoreCore 5   	   B >Helpers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullH1clr-namespace:Helpers.Behaviours;assembly=HelpersHelpers.Behaviours 5	   	   #   TestProject.CurrencyConverter   5   	   2Controls%clr-namespace:UI.Controls;assembly=UI  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TestProject     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   1core clr-namespace:Core;assembly=Core     5   	   G	Behaviors1clr-namespace:Helpers.Behaviours;assembly=Helpers     5	   	     � WindowStartupLocation$  CenterScreen=�5   	      PanelWindow#��[  5   	    � ShowInTaskbar .  � Title$ 
Calculator��5   	   $	��430��6   $	��400��6)     Core.DialogCloser   Value 5   	   �� *DialogResult+ � 	Resources 5        SpaceHeight  	RowHeight �� 
TargetType  CurrencyTextBox �� Property �� Value��%�   &	       &	      &	 3     �5   
   7 �6,   �5   
   50 �6+   �� 5   
   " ��6   .�5      ��  � ��$ 30��6'   5      5      .��5      �   CommonMargin#��[ 6    � RowDefinitions 5   
   �� 5      #��[ 6   6B   �� 5      #��[ 6   6D   �� 5       #��[ 6   6B   �� 5!      #��[ 6   6D   �� 5"      #��[ 6   6B   �� 5#      #��[ 6   6D   �� 5$      #��[ 6   6B   �� 5%      #��[ 6   6D   �� 5&      $��50 �6   6*   	 � ColumnDefinitions	 5)   
   �� 5*      $��90 �6   6,   �� 5+      $��20 �6   6,   �� 5,      6!   .+�5/   
   �� $��0��6   $��0��6    ��50      �� *	Flag_EU+51          UI.Controls.BeveledTextBox  53   
   $��2��6#   $��0��63   ��54      �� *
EU_Value+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 56   
   $��0��6   $��2��6    ��57      �� *	Flag_US+58        5:   
   $��2��6#   $��2��63   ��5;      �� *
US_Value+$
 TwoWay=�$ PropertyChanged=��� 5=   
   $��0��6   $��4��6    ��5>      �� *	Flag_UK+5?        5A   
   $��2��6#   $��4��63   ��5B      �� *
UK_Value+$
 TwoWay=�$ PropertyChanged=�.��6]   5C      �� 5E   
   $��0��6   $��6��6    ��5F      �� *	Flag_Ru+5G        5I   
   $��2��5K      $��6��6   ��5J      �� *
RU_Value+$
 TwoWay=�$ PropertyChanged=�.��5K   +   5L      � 5N   
   $��0��6   $��8��6   $��4��6,   .+�5O      �� -   5         ��Name$ CancelButton��5P        CancelButton#���  5O      $��Center=�5Q      $	��102��5S      ��5R      �� *OkCloseDialogCommand+5S      5U      5V      5W      