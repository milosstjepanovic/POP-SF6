   M S B A M L   `   `   `  ����M  IPOP-SF-06-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POP_SF_06_2016_GUI.GUIPOP_SF_06_2016_GUI.GUI  5   	   0    *POP_SF_06_2016_GUI.GUI.DodatnaUslugaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:POP_SF_06_2016_GUI.GUI     5   	     � Title$  DodatnaUslugaWindow��5   	   $��370.8��6%   $��655.457��64    � 
ResizeMode$ NoResize=�6D    � WindowStartupLocation$ CenterScreen=�6Z   ��5	      �� 5
   
    �� ImageSource$: 4/POP-SF-06-2016-GUI;component/slike/Background11.jpg��6    �� Opacity$	 1.5Q�6X    � 	Resources 5       �� 
TargetType �� Property �� Value��%^  '��       '��     '�� �    '�� �    �� 5   
   " ��6   .�5      ��  � �� �	#FF0B14886+   �� 5       � ��
 �   �6,   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ Italic$�6*   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6,   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6,   5      5       .��5!      � .+�5"   
   &   System.Windows.Controls.DataGrid  -   5        $��dgDodatneUsluge��5"      $
��Left=�6*   $	��269��6E   $	��Top=�6R   $	��447��6j   	   
IsReadOnly	 . 
   CanUserAddRows
 .     AutoGenerateColumns . $��0,49,0,0q�5#   �    �� SelectedItem 6j   ��  �� Path$ IzabranaUsluga�6�   �� 5$   
   -   5        $��btnDodaj��5%      $��Dodaj uslugu��5$      $��Right=�6(   $��0,49,34.8,0q�6D   $	��Top=�6Y   $	��116��6q   $��40��6}   5%   !   �� 5&   
   -   5        $��	btnIzmeni��5'      $��Izmeni uslugu��5&      $��Right=�6)   $��0,108,34.8,0q�6E   $	��Top=�6[   $	��116��6s   $��40��6   5'   "   �� 5(   
   -   5        $��	btnObrisi��5)      $��Obrisi uslugu��5(      $��Right=�6)   $��0,168,34.8,0q�6E   $	��Top=�6[   $	��116��6s   $��40��6   5)   "   �� 5*   
   -   5        $��btnIzlaz��5+      $��Izlaz��5*      $��Right=�6!   $��0,278,34.8,0q�6=   $	��Top=�6S   $	��116��6k   $��40��6w   5+   !   �� 5,   
   $��Sortiraj po:��6   $
��Left=�6'   $��
268,18,0,0q�6B   $	��Top=�6V   �� 5-   
   -   5        $��cmbSortiranje��5-   e   $
��Left=�6   $��
356,21,0,0q�6.   $	��Top=�6B   $��91��6Z   5.      �� 5/   
   $��	Pretrazi:��6   $
��Left=�6$   $��0,18,0,0q�6?   $	��Top=�6Q   $��71��6i   �� 50   
   -   5        $��
tbPretrazi��51      $
��Left=�50      $��23��6-   $��	76,21,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��109��6x   51   $   54      55      