   M S B A M L   `   `   `  ����@  <Lab91, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab91Lab91  5   	       Lab91.Editing   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab91     5   	   -   5          � Title$  Editing��5   	   $	��490��6   $	��800��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      .+�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	Libraries��5   (      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6      AutoGenerateColumns$ False��6;      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� 	 �� Path$	 Id�  5      $ Adress��6)    69   �� $	 Adress�5        5      -   5        $ Books��5   (   $ * 6   $��1��67   $ False��6G    5        5      $ Id��6)    65   �� $	 Id�  5      $
 Name��6)    67   �� $
	 Name�  5      $ Author��6)    69   �� $	 Author�  5      $ 	LibraryID��6)    6<   �� $	 	LibraryID�5       5!      � 5"   
   $��1��6    5#      �� 5$      $	��40* �6    �� 5%      $	��60* �6    �� 5&      $	��60* �6    �� 5'      $	��37* �6    .+�5)      �� .+�5*      �� .��6   )'ID книги для изменения60   �� 5+      -   5        
 ��Name$
 ID��5+   A   $
��Left=�6   $	��100��65   6O   5,      �� 5-      $��1��6    �� Orientation$ 
Horizontal=�6&   .+�5/      �� $��30 0 0 0q�6   $��Center=�6*   .��6E   Library Adress:6V   �� 50      -   5         ��Name$ LibAddr��50   4   $	��200��6   $��20��6(   6G   51      �� 52      $��2��6   $ 
Horizontal=�6&   .+�53      �� $��30 0 0 0q�6   $��Center=�6*   .��6E   Name:6L   �� 54      -   5        $
 BookName��54   F    �� TextWrapping$
 Wrap=�6   $	��120��6.   $��50��6:   6Z   �� 55      $��30 0 0 0q�6   $��Center=�6*   .��6E   	Author:6N   �� 56      -   5        $
 
BookAuthor��56   F   $
 Wrap=�6   $	��120��6.   $��50��6:   6\   57      �� 58      $ 
Horizontal=�6   $��Right=�62   $��4��6N   .+�59      �� -   5         ��Name$ 
insertDate��59   =   $	��100��6   $��20��6%   $��10q�61   .��6j   Before changing6{   �� 5:      -	   5        $ 
UpdateDate��5:   =   $	��100��6   $��20��6%   $��10q�61   .��6j   Update6r   5;      5<      5=      5>      