   M S B A M L   `   `   `  ����J  FModulplaneditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ModulplaneditorModulplaneditor  5   	   %    Modulplaneditor.AddInhaltDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Modulplaneditor     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � SizeToContent$ WidthAndHeight=�5	   	    � Title$ Neuer Inhalt��5
   	   .��5      �� $	��350��5   	   $��10q�5   	    � 	Resources 5   
    �� 
TargetType   
TitleStyle �� Property �� Value  
LabelStyle��%D  &	        &	 u     �� 5      " ��6   .�5      ��  � ��$ 20(�6-   �� 5       �@J�Opacity$	 .75Q�6,   5      �� 5      " ��6   .�5      ��  � ��$ 20(�6-   �� 5       � ��$ Right=�68   �� 5       � ��$
 Bold"�6/   �� 5       � ��$
 10 0q�6+   5      5      .+�5   
   �� $��10q�6   .+�5      �� #��[  5      $��Super-Inhalt:��5      �� 5      #��[  5       
�����_���5!      �� *Super.Titel+ �� FallbackValue$ # Root��5"      5$      � 5%   
   $
��0 10q�5&       � ColumnDefinitions 5'      �� 5(      $��* �6#   �� 5)      $��2* �6#   .+�5+      �� #��[ 5,      $��ID��5-      �� 5/      $��1��50      #��[  51      	 �� TextAlignment$	 Right=�52      $
��Bold"�53      $��Center=�54      ��55      �� *ID+57      � 58   
   $
��0 10q�59       5:      �� 5;      $��* �6#   �� 5<      $��2* �6#   .+�5>      �� #��[ 5?      $��Titel��5@      �� 5B      $��1��5C      $��Center=�5E      $
��5 10q�5F      ��5D      �� *Titel+5F      5H      �� 5I   
   $
��0 10q�5J      
 �� Orientation$
 
Horizontal=�5K      $��Right=�5L       5M      ��%|   '��       �� 5N      " ��6   .�5O      ��  � ��$	 8 3q�60   �� 5P       � ��$ 5 0 0 0q�6/   5Q      5R      .+�5S      �� $��	Abbrechen��5T       �� IsCancel . 5U      �� 5W      -   5         ��Name$ 
SaveButton��5X      $��	Speichern��5Y      5Z      5\      5]      5^      