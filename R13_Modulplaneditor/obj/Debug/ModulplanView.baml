   M S B A M L   `   `   `  ����J  FModulplaneditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ModulplaneditorModulplaneditor  5   	   #    Modulplaneditor.ModulplanView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Modulplaneditor     5   	     � WindowStyle$  
ToolWindow=�5   	    � Title$ Modulplaneditor��5	   	   $	��800��6!    � SizeToContent$ Height=�6-    � WindowStartupLocation$ CenterScreen=�6D    � 	Resources 5
       �� 
TargetType �� Property �� Value   ContainerStyle  LabelInputStyle��%�  'R�       &	  l     &	 �     '�� $    �� 5   
   " R�6   .�5      ��  � ��$	 350��6'   �� 5       � ��$ 8q�6(   5      �� 5   
   " ��6'   .�5      ��  � ��$ 10q�6'   5      �� 5   
   " ��6(   .�5      ��  � ��$ 10q�6'   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ 12(�6)   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5!   
   �� #��[  5"      $��0��5#      .+�5$      � $��0 0 0 5q�5%       5&      �� 5'      $��* �6'   �� 5(      $��2* �6'   .+�5*      �� $��Zum Bearbeiten��5+      �� 5-      $��1��5.      	 �� DisplayMemberPath$	 
Bezeichner��5/      ��50      �� *Module+
 �� SelectedItem
 51      �� *SelectedModulToEdit+53      R� 54      -   5         R�Name$ 
trvInhalte��55      ��56      �� *InhalteSelectedModulToEdit+��58      �� 59       �� ItemsSource 5:      �� *Unterinhalte+.R�5;      ��  �� Orientation$ 
Horizontal=�5<      .+�5=      �� ��5>   !   �� *
Bezeichner+5@      5A      ��5C      �� 5D      " Q�6   .�5E      ��  �@Q�
IsSelected 67   �� *
IsSelected+�� 5F       �@Q�
IsExpanded 67   �� *
IsExpanded+5G      5I      "   Modulplaneditor.InhaltDetail  5J       � DataContext 5K      �� 5M      �� 5N   
   #��[  5O      $��1��5P      .+�5Q      � $��0 0 0 5q�5R       5S      �� 5T      $��* �6'   �� 5U      $��2* �6'   .+�5W      �� $��Zum Anzeigen��5X      �� 5Z      $��1��5[      $	 
Bezeichner��5\      ��5]      �� *Module+
 5^      �� *SelectedModulToView+5`      R� 5a      ��5b      �� *InhalteSelectedModulToView+��5c      �� 5d       5e      �� *Unterinhalte+.R�5f      �� $ 
Horizontal=�5g      .+�5h      �� ��5i   !   �� *
Bezeichner+5k      5l      ��5n      �� 5o      " Q�6   .�5p      ��  �@Q�
IsExpanded . 67   �� 5q       �@J�IsHitTestVisible .  6=   5r      5t      5u      5v      5w      