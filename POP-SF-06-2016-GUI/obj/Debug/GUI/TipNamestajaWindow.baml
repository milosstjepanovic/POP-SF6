   M S B A M L   `   `   `  ����M  IPOP-SF-06-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POP_SF_06_2016_GUI.GUIPOP_SF_06_2016_GUI.GUI  5   	   /    )POP_SF_06_2016_GUI.GUI.TipNamestajaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:POP_SF_06_2016_GUI.GUI     5   	     � Title$  TipNamestajaWindow��5   	   $	��390��6$   $��722.6��61    � 
ResizeMode$ NoResize=�6?    � WindowStartupLocation$ CenterScreen=�6U   $y�Visible=�6z   ��5	      �� 5
   
    �� ImageSource$: 4/POP-SF-06-2016-GUI;component/slike/Background11.jpg��6    �� Opacity$	 1.5Q�6X    � 	Resources 5       �� 
TargetType �� Property �� Value��%^  '��       '��     '�� �    '�� �    �� 5   
   " ��6   .�5      ��  � �� �	#FF0B14886+   �� 5       � ��
 �   �6,   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Italic$�6*   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6,   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6,   5      5       .��5!      � ��5"   
   �� 5#      .+�5%   
   &   System.Windows.Controls.DataGrid  -   5        $��dgTipoviNamestaja��5%      	   AutoGenerateColumns	 . $��0��6�   $
��Left=�6�   $	��276��5&      $	��Top=�6   $	��494��67   
   
IsReadOnly
 .    CanUserAddRows .  $��0,50,0,0q�6�    �� SelectedItem 6l   ��  �� Path$ IzabraniTipNamestaja�6�   �� 5'   
   -   5        $��btnDodajNamestaj��5(      $	��152��5'      $��Right=�6   $��0,50,23,270.8q�5(   H   
���   ����	#FF0B1488$
��Bold"�6�   $��Italic$�6�   .��6�   Dodaj tip namestaja5*      �� 5+   
   -   5        $��btnIzmeniNamestaj��5,      $	��152��5+      $��Right=�6   $��0,108,23,212.8q�5,   J   .��6b   Izmeni tip namestaja6x   �� 5-   
   -   5        $��btnObrisiNamestaj��5.      $	��152��5-      $��Right=�6   $��0,167,23,153.8q�5.   J   .��6b   Obrisi tip namestaja6x   �� 5/   
   -   5        $��btnIzlaz��50      $	��136��5/      $��Right=�6   $��0,286,23,34.8q�50   8   .��6O   Izlaz6V   �� 51   
   $��	Pretrazi:��6   $
��Left=�6$   $��0,19,0,0q�6?   $	��Top=�6Q   $��73��6i   $��25��6t   �� 52   
   -   5        $��
tbPretrazi��52   �   $
��Left=�6   $��23��6-   $��	78,21,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��120��6x   
���   �53   7   �� 54   
   $��Sortiraj po:��6   $
��Left=�6'   $��
308,19,0,0q�6B   $	��Top=�6V   $��89��6n   �� 55   
   -   5        $��cmbSortiranje��55   e   $
��Left=�6   $��
402,22,0,0q�6.   $	��Top=�6B   $��92��6Z   56      57      58      