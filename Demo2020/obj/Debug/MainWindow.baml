   M S B A M L   `   `   `  ����C  ?Demo2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Demo2020Demo2020  5          Demo2020.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Demo2020     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  	Demo 2020��5      $	��900��5	      $	��450��5
       � WindowState$ 	Maximized=�5      {�5      ��    MessageListener �� Source# [   �� Path$ BindableProperty�.��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��5      $��0��5        � ToolTip$ Monster Manual��5"      ��5!      �� *MonsterManualCommand+.��5#      �� $��96��6   $;��5/Demo2020;component/Resources/Images/BeholderIcon.png��6    5$      �� 5&   
   $��1��5'      $��0��5(      $ 	Equipment��5*      ��5)      �� *EquipmentCommand+.��5+      �� $��96��6   $8��2/Demo2020;component/Resources/Images/ArmorIcon.png��6    5,      �� 5.   
   $��2��5/      $��0��50      $ Magic Items��52      ��51      �� *MagicItemCommand+.��53      �� $��96��6   $<��6/Demo2020;component/Resources/Images/BattleAxeIcon.png��6    54      �� 56   
   $��3��57      $��0��58      $ Loot Tables��5:      ��59      �� *LootCommand+.��5;      �� $��96��6   $6��0/Demo2020;component/Resources/Images/BowIcon.png��6    5<      �� 5>   
   $��4��5?      $��0��5@      $ 
Characters��5B      ��5A      �� *ActorCatalogCommand+.��5C      �� $��96��6   $9��3/Demo2020;component/Resources/Images/KnightIcon.png��6    5D      �� 5G   
   $��6��5H      $��1��5I      ��5J      �� *CurrentViewModel+5K      5L      