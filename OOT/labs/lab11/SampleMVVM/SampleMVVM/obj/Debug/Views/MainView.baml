   M S B A M L   `   `   `  ����E  ASampleMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SampleMVVM.CommandsSampleMVVM.Commands  5      =#clr-namespace:SampleMVVM.ViewModelsSampleMVVM.ViewModels  5          SampleMVVM.Views.MainView   5   	   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      -c!clr-namespace:SampleMVVM.Commands    5      7	viewModel#clr-namespace:SampleMVVM.ViewModels    5        � Title$  Main Window��5      $	��400��6   $	��350��6&    � DataContext 5      )  #SampleMVVM.ViewModels.MainViewModel  5   
   .��5
      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��10 0 0 0q�6   $	��180��6(   $��20��64   
���   ���6T   �� *FIO+�� 5      $��Search��6   $
��50px��5      $
��20px��5      $��10 0 0 0q�5      ��5      �� *Search+5      5      � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $ �� IsSynchronizedWithCurrentItem$
 TrueY�6=   ��6   �� *MedCenterList+��5      �� 5      .R�5      �� 
�������$��1q�66   $��10q�6J   ._�5       �� $��10q�6)   .+�5!   "   �� $
��Bold"�6B   ��6,   �� *Name+6B   �� 5"   "   ��6,   �� *
Department+�� 5#   "   ��6,   �� *
Category+�� 5$   "   ��6,   �� *Specialization+�� 5%   "   $ 
Horizontal=�6-   .+�5&   &   �� $��Осталось:��60   �� 5'   &   $
��Bold"�6T   $
��10,0q�6f   ��60   �� *Count+ �� Mode$ TwoWay=�6f   �� 5(   &   $
��шт��60   5)   #   5*      5+      5,      5.      �� 50      $��1��6   ��6-   �� *MedCenterList+��51      �� 52      .R�53      �� 
�������$��1q�66   $��10q�6J   ._�54      �� $��10q�6)   .+�56   "   �� $��Имя:��6,   �� 57   "   $��0,0,0,10q�6e   ��6*   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6e   �� 59   "   $��Отдел:��6,   �� 5:   "   $��0,0,0,10q�6k   ��6*   �� *
Department+$ PropertyChanged=�6k   �� 5<   "   $��Категория:��6,   �� 5=   "   $��0,0,0,10q�6i   ��6*   �� *
Category+$ PropertyChanged=�6i   �� 5?   "   $!��Специализация:��6,   �� 5@   "   $��0,0,0,10q�6o   ��6*   �� *Specialization+$ PropertyChanged=�6o   �� 5B   "   $ 
Horizontal=�6-   .+�5C   &   �� $��Выдать��6-   $
��10,0q�6b   ��6>   �� *GiveItemCommand+6b   �� 5D   &   $��Забрать��6-   $
��10,0q�6b   ��6?   �� *GetItemCommand+6b   5E   #   5F      5G      5H      5J      5K      5N      5O      