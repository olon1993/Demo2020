   M S B A M L   `   `   `  ����C  ?Demo2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Demo2020.Equipment.ViewsDemo2020.Equipment.Views  5      Q-clr-namespace:Demo2020.Equipment.UserControlsDemo2020.Equipment.UserControls  5      ,    &Demo2020.Equipment.Views.EquipmentView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Demo2020.Equipment.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      <uc-clr-namespace:Demo2020.Equipment.UserControls     5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $��3* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      ]� .+�5      �� $��36��5      
��� � �
������ $��Right=�5!      ��5       �� *AddEquipmentCommand+.��5"      �� $
��Bold"�5#      
�������$	��New��5%      5&      �� 5'      $��Right=�6   ��61   �� *Filter+ �� UpdateSourceTrigger$ PropertyChanged=�5(      �� 5)      $��3,0,0,0q�5*       K� ZIndex$ 10��5+      |�.  
������� J� IsHitTestVisible .  $��	Search...��5/      ��50      �� 51       �� 
TargetType" ��6   .�52      ��  �� Property � y� �� Value$ 	Collapsed=�67    �� Triggers 53      �� 54      	 �� Binding	 6*   �� *Filter.Length+
 �� Value
 06L   .a�55   "   ��  � y�$ Visible=�6?   56      58      5:      �� 5<      $��1��5=      ��5>      �� *	Equipment+$ PropertyChanged=� �� SelectedIndex 5?      �� *SelectedEquipmentIndex+��5@      �� 5A      .R�5B      �� ��6$   �� *Name+$ PropertyChanged=�5C      5E      5F      �� 5H   
   $��1��6   y�6!   �� *IsEditEnabled+$ PropertyChanged=� $   ReverseBoolToVisibilityConverter �� 	Converter# [   �� FallbackValue$ Visible��._�5I      6   0Demo2020.Equipment.UserControls.EquipmentControl   � DataContext 6"   �� *CurrentEquipment+5J      �� 5L   
   $��1��6   y�6!   �� *IsEditEnabled+$ PropertyChanged=�  BoolToVisibilityConverter# [ $ 	Collapsed��._�5M      � 
������� 5N      �� 5O      $��* �6$   �� 5P      $
��Auto �6$   .+�5R      :   4Demo2020.Equipment.UserControls.EditEquipmentControl   6*   �� *CurrentEquipment+5S      5T      �� 5V   
   $��0��5W      $��1��5X      $��36��5Y      $��36��5Z      $��5q�5[      $
��Left=�5\      $	��Top=�5]      
������ 
������ ��5`      �� *ToggleEditCommand+.��5a      �� ��6   �� *EditIconSource+5b      �� 5d   
   $��0��5e      $��1��5f      $��36��5g      $��36��5h      $��5q�5i      $��Right=�5j      $��Bottom=�5k      
������ 
������ ��5n      �� *SaveCommand+.��5o      �� $7��1/Demo2020;component/Resources/Images/SaveIcon.png��6   5p      5r      5s      